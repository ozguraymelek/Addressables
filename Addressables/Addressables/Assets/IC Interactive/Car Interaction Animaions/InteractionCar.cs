using UnityEngine;
using System.Collections;

public class InteractionCar : InteractiveObject {
	public Animation frontLeftDoor;
	public CarPhysics car;
	public CameraOrbitCenterInfo cameraCenter;
	public string animatorTriggerInterrupt;
	public bool isPassenger;

	public override void ReachInteraction (Character character) {
		base.ReachInteraction (character);

		frontLeftDoor.Play ("DoorIn");
		if (!isPassenger) {
			car.cameraController = character.cameraController;
		}
		character.cameraController.ChangeOrbitCenter (cameraCenter);

		character.originalParent.parent = interactionStartCollider.transform;
	}

	public override void StartInteraction (Character character) {
		base.StartInteraction (character);
		if (!isPassenger) {
			car.StartEngine ();
			character.carController = car.carControllerAlt;
		}
	}

	public override void InterruptInteraction (Character character) {
		base.InterruptInteraction (character);
		if (car.GetComponent<Rigidbody>().velocity.magnitude < 5f) {
			character.animator.SetTrigger (Animator.StringToHash (animatorTriggerInterrupt));
			if (!isPassenger) {
				car.OffEngine ();
			}
			frontLeftDoor.Play ("DoorOut");
			character.cameraController.ChangeOrbitCenter (character.cameraCenter);
			character.interaction.SetState (CharacterInteraction.State.InterruptInteraction);
		}
	}
}

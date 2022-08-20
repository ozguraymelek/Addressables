using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Data/New Data")]
public class Data : ScriptableObject
{
    public List<AssetReference> balls;
}

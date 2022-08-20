using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Data data;
    public void Instantiate()
    {
        foreach (var ball in data.balls)
        {
            ball.InstantiateAsync();
        }
    }
}

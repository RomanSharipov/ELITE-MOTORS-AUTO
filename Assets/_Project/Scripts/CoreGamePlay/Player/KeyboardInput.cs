using System;
using UnityEngine;

public class KeyboardInput : Input
{
    public override float Direction => UnityEngine.Input.GetAxis("Horizontal");

    public override event Action Jumped;


    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Jumped?.Invoke();
        }
    }
}
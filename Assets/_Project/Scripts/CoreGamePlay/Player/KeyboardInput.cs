using UnityEngine;
using UnityEngine.Windows;

public class KeyboardInput : Input
{
    public override bool  JumpInput => UnityEngine.Input.GetKeyDown(KeyCode.Space);

    public override float Direction => UnityEngine.Input.GetAxis("Horizontal");
}

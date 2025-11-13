using System;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : Input
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _jumpButton;
    
    public override float Direction => _joystick.Direction.x;

    public override event Action Jumped;


    private void Start()
    {
        _jumpButton.onClick.AddListener(Jump);
    }

    private void OnDestroy()
    {
        _jumpButton.onClick.RemoveListener(Jump);
    }

    private void Jump()
    {
        Jumped?.Invoke();
    }
}
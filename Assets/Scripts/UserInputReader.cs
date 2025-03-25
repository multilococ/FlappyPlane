using System;
using UnityEngine;

public class UserInputReader : MonoBehaviour
{
    private readonly string Jump = nameof(Jump);

    public event Action JumpPressed;

    private void Update()
    {
        if (Input.GetButtonDown(Jump))
        { 
            JumpPressed?.Invoke();
        }
    }
}
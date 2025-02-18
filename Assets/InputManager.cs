using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>(); // Handles movement

    private void Update()
    {
        // Check for Space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

        // Handle movement (A/D keys)
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }

        // Invoke movement event if movement occurred
        if (input != Vector2.zero)
        {
            OnMove?.Invoke(input);
        }
    }
}

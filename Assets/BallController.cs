using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;

    // Name booleans like a question
    private bool isBallLaunched;
    private Rigidbody ballRB;
    [SerializeField] private InputManager inputManager; // Ensure this can be assigned in the Inspector

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();

        // Try to find InputManager in the scene if not manually assigned
        if (inputManager == null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }

        if (inputManager != null)
        {
            inputManager.OnSpacePressed.AddListener(LaunchBall);
        }
        else
        {
            Debug.LogError("InputManager not found! Assign it manually in the Inspector.");
        }
    }

    private void LaunchBall()
    {
        // Now your if check can be framed like a sentence
        // "If ball is launched, then simply return and do nothing"
        if (isBallLaunched) return;

        // "Now that the ball is not launched, set it to true and launch the ball"
        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}

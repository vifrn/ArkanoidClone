using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [Range(0, 20)]
    public float speed = 5f;
    public Camera mainCamera;

    private InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction(Constants.ACTION_MOVE);
    }    

    // Update is called once per frame
    void Update()
    {
        float movementDirection = moveAction.ReadValue<Vector2>().x;

        if (mainCamera == null)
        {
            Debug.Log("Camera not found!");
        } 
        else 
        {
            //This code invalidate the movement in case we have reached the borders of the screen;
            Vector2 hitScreenBounds = ScreenBoundVerifier.HasReachedBorder(mainCamera, transform.position, 50);
            if (hitScreenBounds.x > 0 && movementDirection < 0) 
            {
                movementDirection = 0;
            }

            if (hitScreenBounds.x < 0 && movementDirection > 0)
            {
                movementDirection = 0;
            }

        }

        transform.position += Vector3.right * speed * movementDirection * Time.deltaTime;

    }
}

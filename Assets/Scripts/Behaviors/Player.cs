using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [Range(0, 20)]
    public float speed = 5f;

    InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    

    // Update is called once per frame
    void Update()
    {

        Camera camera = GetComponentInParent<Camera>();

        float movementDirection = moveAction.ReadValue<Vector2>().x;

        if (camera == null)
        {
            Debug.Log("Camera not found!");
        } 
        else 
        {
            //This code invalidate the movement in case we have reached the borders of the screen;
            Vector2 hitScreenBounds = ScreenBoundVerifier.HasReachedBorder(camera, transform.position);
            if (hitScreenBounds.x > 0 && movementDirection > 0) 
            {
                movementDirection = 0;
            }

            if (hitScreenBounds.x < 0 && movementDirection < 0)
            {
                movementDirection = 0;
            }

        }

        //Debug.Log("Movement direction: " + movementDirection);

        transform.position += Vector3.right * speed * movementDirection * Time.deltaTime;


    }
}

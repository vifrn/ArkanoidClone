using UnityEngine;

public class Ball : MonoBehaviour
{

    public Camera mainCamera;

    [Range(0, 20)]
    public float speed = 5f;

    private float randDirectionX = 1;
    private float randDirectionY = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randDirectionX = Random.value;
        randDirectionY = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 hitScreenBorder = ScreenBoundVerifier.HasReachedBorder(mainCamera, transform.position);

        if (hitScreenBorder.x < 0 && randDirectionX > 0) randDirectionX *= -1;
        if (hitScreenBorder.x > 0 && randDirectionX < 0) randDirectionX *= -1;
        if (hitScreenBorder.y < 0 && randDirectionY > 0) randDirectionY *= -1;
        if (hitScreenBorder.y > 0 && randDirectionY < 0) randDirectionY *= -1;

        transform.position += new Vector3(randDirectionX, randDirectionY, 0) * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constants.TAG_PLAYER) {
            randDirectionY *= -1;
        }

        if (collision.gameObject.tag == Constants.TAG_BRICK) {
            Debug.Log("Hit a brick!! Score!");
            randDirectionY *= -1;
        }
    }
}

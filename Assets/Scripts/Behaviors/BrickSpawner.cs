using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{

    public Camera mainCamera;

    public GameObject brickPrefab;
    [Range(0, 100)]
    public int quantity = 10;

    private List<GameObject> bricks = new List<GameObject>();
    private const int MAX_ROW = 15;
    private float brickWidth;
    private float brickHeight;
    private float brickOffset = 0.05f;


    private void Awake()
    {
        for (int i = 0; i < quantity; i++)
        {
            bricks.Add(Instantiate(brickPrefab));
        }

        float brickWidthPx = mainCamera.pixelWidth / MAX_ROW;
        Vector2 pointZero = mainCamera.ScreenToWorldPoint(Vector2.zero);
        Vector2 widthToUnit = mainCamera.ScreenToWorldPoint(new Vector2(brickWidthPx, 0));
        brickWidth = widthToUnit.x - pointZero.x;
        brickHeight = bricks[0].GetComponent<SpriteRenderer>().bounds.size.y;

    }

    void Start()
    {
        int counter = 0;
        int row = 0;
        foreach (var brick in bricks)
        {
            brick.transform.localScale = new Vector3(brickWidth - brickOffset, brick.transform.localScale.y - brickOffset, brick.transform.localScale.z);
            brick.transform.position = new Vector2(
                transform.position.x + brickWidth / 2 + counter * brickWidth,
                transform.position.y - brickHeight / 2 - row * brickHeight);

            counter++;
            if (counter >= MAX_ROW)
            {
                row++;
                counter = counter % MAX_ROW;
            }
        }

    }
}

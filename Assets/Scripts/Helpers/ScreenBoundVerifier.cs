using UnityEngine;

/**
 * Helper class to check if an object has reached the border of the screen
 */
public class ScreenBoundVerifier
{

    public static Vector2 HasReachedBorder(Camera camera, Vector3 position)
    {
        Vector2 screenPos = camera.WorldToScreenPoint(position);

        if (screenPos.x < 0) {
            return Vector2.right;
        }

        if (screenPos.x > camera.pixelWidth)
        {
            return Vector2.left;
        }

        if (screenPos.y < 0)
        {
            return Vector2.up;
        }

        if (screenPos.y > camera.pixelHeight)
        {
            return Vector2.down;
        }

        return Vector2.zero;
    }
    
}

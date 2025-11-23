using UnityEngine;

/**
 * Helper class to check if an object has reached the border of the screen
 */
public class ScreenBoundVerifier
{

    public static Vector2 HasReachedBorder(Camera camera, Vector3 position) {
        return HasReachedBorder(camera, position, 0);
    }

    public static Vector2 HasReachedBorder(Camera camera, Vector3 position, float borderSize)
    {
        Vector2 screenPos = camera.WorldToScreenPoint(position);

        if (screenPos.x < borderSize) {
            return Vector2.right;
        }

        if (screenPos.x > camera.pixelWidth - borderSize)
        {
            return Vector2.left;
        }

        if (screenPos.y < borderSize)
        {
            return Vector2.up;
        }

        if (screenPos.y > camera.pixelHeight - borderSize)
        {
            return Vector2.down;
        }

        return Vector2.zero;
    }
    
}

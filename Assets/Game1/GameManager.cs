using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float enemyBaseSpeed = 20f;

    public float timeToWaitToSpawnEnemies = 3f;

    public float worldTop;
    public float worldBottom;
    public float worldLeft;
    public float worldRight;

    void Start()
    {
        // Get the size of the screen pixels
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // Find the positions of the corners in screen coordinates (in pixels)
        Vector2 topLeft = new Vector2(0, screenSize.y);
        Vector2 topRight = new Vector2(screenSize.x, screenSize.y);
        Vector2 bottomLeft = new Vector2(0, 0);
        Vector2 bottomRight = new Vector2(screenSize.x, 0);

        // Convert the screen positions to world positions (in meters)
        Vector2 worldTopLeft = Camera.main.ScreenToWorldPoint(topLeft);
        Vector2 worldTopRight = Camera.main.ScreenToWorldPoint(topRight);
        Vector2 worldBottomLeft = Camera.main.ScreenToWorldPoint(bottomLeft);
        Vector2 worldBottomRight = Camera.main.ScreenToWorldPoint(bottomRight);

        worldTop = worldTopLeft.y;
        worldBottom = worldBottomRight.y;
        worldLeft = worldTopLeft.x;
        worldRight = worldBottomRight.x;

        // Print the world positions of the corners
        Debug.Log("--- Printing the Coordinates of the screen Boundary ---");
        Debug.Log("Top left: " + worldTopLeft);
        Debug.Log("Top right: " + worldTopRight);
        Debug.Log("Bottom left: " + worldBottomLeft);
        Debug.Log("Bottom right: " + worldBottomRight);
    }
}
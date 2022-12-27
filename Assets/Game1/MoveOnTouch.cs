using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    // The speed at which the sprite will move
    public float playerSpeed = 750f;

    // The sprite's Rigidbody2D component
    [SerializeField] Rigidbody2D player;

    void Start()
    {
        // Get the sprite's Rigidbody2D component
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Check if the screen is being touched
        if (Input.touchCount > 0)
        {
            // Get the first touch on the screen
            Touch touch = Input.GetTouch(0);

            // Get the position of the touch
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Calculate the direction to move the sprite
            Vector2 direction = touchPosition - player.position;

            // Normalize the direction to eliminate the influence of the distance
            // between the sprite and the touch position
            //direction.Normalize();

            // Move the sprite in the direction of the touch
            player.velocity = direction * playerSpeed * Time.deltaTime;
        }
        else
        {
            // If the screen is not being touched, stop the sprite
            player.velocity = Vector2.zero;
        }
    }
}
using UnityEngine;

public class SideToSideMovement : MonoBehaviour
{
    public float speed = 2f;       // Movement speed
    public float distance = 5f;    // Distance to move on each side

    private float originalX;       // Starting position of the GameObject
    private float targetX;         // Target position of the GameObject

    private void Start()
    {
        originalX = transform.position.x;
        targetX = originalX + distance;
    }

    private void Update()
    {
        // Calculate the new position using a ping pong function
        float newX = Mathf.PingPong(Time.time * speed, 2 * distance) - distance + originalX;

        // Move the GameObject to the new position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}

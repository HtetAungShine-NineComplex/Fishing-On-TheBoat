using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_MoveTo : MonoBehaviour
{
    [SerializeField] private float elapsedTime = 0;
    [SerializeField] private float desiredDuration = 5;
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform destroyPoint;

    private void Update()
    {
        moveToward();
    }

    void moveToward()
    {
        elapsedTime += Time.deltaTime;
        float completePercentage = elapsedTime / desiredDuration;
        // Move the object from spawnPoint to destroyPoint
        //transform.position = Vector2.MoveTowards(transform.position, Vector2.Lerp(transform.position, destroyPoint.position, completePercentage), speed Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, destroyPoint.position, speed * Time.deltaTime);

        // Check if the object has reached or passed the destroyPoint
        if (transform.position == destroyPoint.position)
        {
            // Destroy the object or handle other logic (e.g., respawn)
            Destroy(gameObject);
        }
    }
}

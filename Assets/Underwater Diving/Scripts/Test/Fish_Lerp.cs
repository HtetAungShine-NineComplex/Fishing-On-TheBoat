using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Move : MonoBehaviour
{
    [SerializeField] private float elapsedTime = 0;
    [SerializeField] private float desiredDuration = 5;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform destroyPoint;

    private void Update()
    {
        lerp();
    }

    void lerp() //non linear lerp
    {
        elapsedTime += Time.deltaTime;
        float completePercentage = elapsedTime / desiredDuration;
        transform.position = Vector2.Lerp(spawnPoint.position, destroyPoint.position, Mathf.SmoothStep(0, 1, completePercentage));

        if (transform.position == destroyPoint.position)
        {
            // Destroy the object or handle other logic (e.g., respawn)
            Destroy(gameObject);
        }
    }
}

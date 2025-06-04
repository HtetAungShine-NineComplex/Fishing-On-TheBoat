using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _fishPrefabs;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private bool _isRight;

    private float _counter = 0;

    private void Start()
    {

    }

    private void Update()
    {
        _counter += Time.deltaTime;

        if( _counter > _spawnInterval )
        {
            Vector2 randY = new Vector2(transform.position.x, Random.Range(-4f, 1f));

            GameObject fishObj = Instantiate(_fishPrefabs[Random.Range(0, 3)], randY, Quaternion.identity);
            fishObj.GetComponent<Fish>().SetMoveDirection(_isRight);

            _counter = 0;
        }
    }
}

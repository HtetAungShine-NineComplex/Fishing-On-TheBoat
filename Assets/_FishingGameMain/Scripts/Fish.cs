using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _score;
    [SerializeField] private float _upSpeed;

    private bool _canMove = true;

    private void Start()
    {

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(!_canMove)
        {
            return;
        }

        transform.position += transform.right * _moveSpeed * Time.deltaTime;
    }

    public void OnCaught(Transform hookPos)
    {
        _canMove = false;

        transform.parent = hookPos;
        transform.position = hookPos.position;
        transform.rotation = hookPos.rotation;

        if(transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        GLOBALEVENTS.CaughtFishEnd += OnCaughtEnd;
    }

    public void OnCaughtEnd()
    {
        Destroy(gameObject);
        GameManager.Instance.Score += _score;
        GLOBALEVENTS.CaughtFishEnd -= OnCaughtEnd;
    }

    public void SetMoveDirection(bool toRight)
    {
        if(toRight)
        {
            return;
        }
        else
        {
            _moveSpeed *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public float GetUpSpeed()
    {
        return _upSpeed;
    }
}

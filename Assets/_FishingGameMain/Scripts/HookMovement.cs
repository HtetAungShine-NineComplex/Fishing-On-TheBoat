using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField] private float _maxRotation = 55f;
    [SerializeField] private float _minRotation = -55f;
    [SerializeField] private float _rotationSpeed = 5f;

    private float _rotationAngle;
    private bool _isRotateRight;
    private bool _canRotate;

    [SerializeField] private float _normalMoveSpeed = 5f;
    [SerializeField] private float _fishMoveSpeed = 2f;

    [SerializeField] private float _minY = -1.3f;
    private float _initialY;

    private bool _isMovingDown;

    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform _ropeStartPoint;
    [SerializeField] private Transform _ropeEndPoint;

    private bool _caughtFish = false;

    [SerializeField] private Hook _hook;


    private void Start()
    {
        _initialY = transform.position.y;

        _canRotate = true;

        _line.SetPosition(0, _ropeStartPoint.position);

        GLOBALEVENTS.CaughtFish += n => OnCaughtFish();
    }

    private void Update()
    {
        Rotate();
        CheckInputs();
        MoveRope();

        _line.SetPosition(1, _ropeEndPoint.position);
    }

    private void OnDestroy()
    {
        GLOBALEVENTS.CaughtFish -= n => OnCaughtFish();
    }

    private void Rotate()
    {
        if(!_canRotate)
        {
            return;
        }

        if(_isRotateRight)
        {
            _rotationAngle += _rotationSpeed * Time.deltaTime;
        }
        else
        {
            _rotationAngle -= _rotationSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(_rotationAngle, Vector3.forward);

        if(_rotationAngle >= _maxRotation)
        {
            _isRotateRight = false;
        }
        else if(_rotationAngle <= _minRotation)
        {
            _isRotateRight = true;
        }

    }

    private void CheckInputs()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_canRotate)
            {
                _canRotate = false;
                _isMovingDown = true;
                _hook.canCatch = true;
            }
        }
    }

    private void MoveRope()
    {
        if(_canRotate)
        {
            return;
        }

        if(_isMovingDown)
        {
            transform.position -= transform.up * _normalMoveSpeed * Time.deltaTime;
        }
        else
        {
            if(_caughtFish)
            {
                transform.position += transform.up * _fishMoveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += transform.up * _normalMoveSpeed * Time.deltaTime;
            }
            
        }

        if(transform.position.y <= _minY)
        {
            _isMovingDown = false;
            _hook.canCatch = false;
        }

        if(transform.position.y >= _initialY)
        {
            _canRotate = true;
            if(_caughtFish)
            {
                GLOBALEVENTS.InvokeCaughtFishEnd();
                _caughtFish = false;
            }
        }
    }

    private void OnCaughtFish()
    {
        _caughtFish = true;
        _isMovingDown = false;
        _hook.canCatch = false;
    }

    public void SetCaughtSpeed(float fishSpeed)
    {
        _fishMoveSpeed = fishSpeed;
    }
}

using GXPEngine;
using System;

public class Mouse : GameObject
{
    private float _lastX, _currentX;
    private bool _isMoving;
    private float _delayMoveCheck, _nextMoveCheck;


    public Mouse()
	{
        _isMoving = false;

        _currentX = Input.mouseX;

        _nextMoveCheck = 0;
        _delayMoveCheck = 100;
	}

    public void Update()
    {
        if (Time.time > _nextMoveCheck)
        {
            _currentX = Input.mouseX;

            if (_lastX != _currentX)
            {
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }

           

            _lastX = _currentX;
            _nextMoveCheck = Time.time + _delayMoveCheck;
        }
        //Console.WriteLine(_isMoving);
    }

    public bool IsMoving()
    {
        return _isMoving;
    }
}

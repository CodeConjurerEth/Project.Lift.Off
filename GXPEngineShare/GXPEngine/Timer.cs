using GXPEngine;
using System;

public class Timer : GameObject
{

    private int _time;
    Action _ontimeout;

    public Timer(int time, Action ontimeout) 
    {
        _time = time;
        _ontimeout = ontimeout;

    }

    public void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            _ontimeout();
            Destroy();
        }

    }

}

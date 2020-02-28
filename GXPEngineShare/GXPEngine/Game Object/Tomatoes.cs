using GXPEngine;
using System;

public class Tomatoes : AnimationSprite
{
    private float _speedX = 0.7f;
    private float _speedY = 5f;

    private int numberOffFrames = 6;


    public Tomatoes(int _startX, int _startY) : base("TomatoesAnim.png", 5, 3)
    {
        this.x = _startX;
        this.y = _startY;

        scale = 1.8f;
    }

    private void Update()
    {
        movingTomato();
        stoppingTomato();
    }

    private void movingTomato()
    {
        if (this.x > 750)
        {
            x = x - _speedX;
            y = y - _speedY;
        }
        if (this.x <= 750)
        {
            x = x + _speedX;
            y = y - _speedY;
        }

        //animationTomato();
    }

    private void stoppingTomato()
    {
        if (this.y < -100)
        {
            LateDestroy();
        }
    }
    protected void animationTomato()
    {
        int frame = (int)(this.x / 30) % numberOffFrames;
        SetFrame(frame);
    }


    public void Splash()
    {
        LateDestroy();
    }
}
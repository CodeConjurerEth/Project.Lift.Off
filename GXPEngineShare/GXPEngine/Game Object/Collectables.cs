using GXPEngine;
using System;

public class Collectables : AnimationSprite
{
    private int numberOffFrames;
    private int startFrame;
    private float frameInterval;

    private float _animationTimer;

    public bool _isSpawned;


    public Collectables(int _startX, int _startY) : base("collectable.png", 4, 2)
    {
        this.x = _startX;
        this.y = _startY;

        scale = 1.8f;
        numberOffFrames = 6;
        startFrame = 0;
        frameInterval = 200f;
        _animationTimer = 0;

        Timer timer = new Timer(5000, LateDestroy);
        AddChild(timer);

    }

    private void Update()
    {
        animationCollectable();
    }


    protected void animationCollectable()
    {
        _animationTimer += Time.deltaTime;
        int currentFrame = (int)(_animationTimer / frameInterval) % numberOffFrames + startFrame;
        SetFrame(currentFrame);
    }

    public void destroyTheCollectable()
    {
       LateDestroy();
    }
}
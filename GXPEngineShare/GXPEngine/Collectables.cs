using GXPEngine;
using System;

public class Collectables : AnimationSprite
{
    private int numberOffFrames = 6;
    private int startFrame = 0;
    private float frameInterval = 200f;

    private float _animationTimer = 0;

    public bool _isSpawned;


    public Collectables(int _startX, int _startY) : base("collectable.png", 4, 2)
    {
        this.x = _startX;
        this.y = _startY;

        scale = 1.8f;

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
using GXPEngine;
using System;

public class Collectables : AnimationSprite
{
    private float _speedX = 0.7f;
    private float _speedY = 5f;

    private int numberOffFrames = 6;
    private int startFrame = 0;
    private float frameInterval = 200f;

    private float _animationTimer = 0;

    public bool _isSpawned;


    public Collectables(int _startX, int _startY) : base("collectable.png", 4, 2)
    {
        this.x = _startX;
        this.y = _startY;

<<<<<<< HEAD
        scale = 1.8f;


=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
        //scale = .8f;
=======
<<<<<<< HEAD
        scale = 1.8f;
=======
>>>>>>> c2fa3e3c1e6c203e3d3b2f0ef4d784e6ec06e247
        scale = 4.8f;
>>>>>>> d60d7bbc6277040e639965b99dae8cbfdc854620

>>>>>>> 8bec5610d0f70359398fa4d6920939c9e2eb1fb7
        Timer timer = new Timer(5000, LateDestroy);
        AddChild(timer);

        /// Pick up needs to appear at a certain score, and then dissappear after a few seconds;

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
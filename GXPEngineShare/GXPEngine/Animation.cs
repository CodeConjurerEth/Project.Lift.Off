using System;
using GXPEngine;
using GXPEngine.Core;


public class Animation : AnimationSprite
{
    public int leftBoundry = -50;
    public int rightBoundry = 750;

    private int _numbOfFram;
    private int _startFra;
    private float _animationTimer = 0;

    public Animation(string animationFile, int column, int row) : base(animationFile, column, row)
    {

    }



    protected void walkingAnimation(int numberOffFrames)
    {
        _numbOfFram = numberOffFrames;

        int frame = (int)(this.x / 5) % _numbOfFram;
        SetFrame(frame);
    }


    protected void idleAnimation(int numberOfFrames, int startFrame)
    {
        _numbOfFram = numberOfFrames;
        _startFra = startFrame;

        int frame = (int)(this.x / 10) % _numbOfFram;
        SetFrame(_startFra);
    }




    protected void dyingAnimation(int startFrame, int numberOfFrames)
    {
        _numbOfFram = numberOfFrames;
        _startFra = startFrame;
        float frameInterval = 250f;
        float animationTimer = 0.0f;

        animationTimer += Time.deltaTime;
        int currentFrame = (int)(animationTimer / frameInterval) % numberOfFrames + startFrame;
        SetFrame(currentFrame);
    }
}

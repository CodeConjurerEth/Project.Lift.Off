using System;
using GXPEngine;
using GXPEngine.Core;


public class Animation : AnimationSprite
{
    private int _numbOfFram;
    private int _startFra;


    float _frameInterval;
    float _animationTimer;

    public Animation(string animationFile, int column, int row) : base(animationFile, column, row, keepInCache:true)
    {
        _frameInterval = 10;
        _animationTimer = 0.0f;
    }



    protected void walkingAnimation(int numberOffFrames)
    {

        _numbOfFram = numberOffFrames;

        int frame = (int)(this.x / 5) % _numbOfFram;
        SetFrame(frame);
    }

    protected void idleAnimation(int startFrame, int numberOfFrames)
    {
        _numbOfFram = numberOfFrames;
        _startFra = startFrame;


    _animationTimer += Time.deltaTime;
        int currentFrame = (int)(_animationTimer / _frameInterval) % _numbOfFram + _startFra;
        SetFrame(currentFrame);
    }

    protected void almostFallingAnimation(int startFrame, int numberOfFrames)
    {
        _numbOfFram = numberOfFrames;
        _startFra = startFrame;


        _animationTimer += Time.deltaTime;
        int currentFrame = (int)(_animationTimer / _frameInterval) % _numbOfFram + _startFra;
        SetFrame(currentFrame);
    }
}

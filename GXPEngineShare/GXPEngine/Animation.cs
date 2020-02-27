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
<<<<<<< HEAD
        _startFra = 0;
=======
        _frameInterval = 10;
        _animationTimer = 0.0f;
>>>>>>> cca5989b066d381a5c765e7a0558d67d859d90ca
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

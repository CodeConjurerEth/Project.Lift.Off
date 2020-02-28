using System;
using System.Collections.Generic;
using GXPEngine;

public class GameOverScreen : Sprite
{
    private ScoreHUD _scoreHUD;

    public GameOverScreen() : base("Game_Over_Screen.png")
    {
        _scoreHUD = new ScoreHUD();
        AddChild(_scoreHUD);
    }

    //--------------------------------------------------------------
    //              //Destroys Game Over background
    //--------------------------------------------------------------
    private void Update()
    {
        if (Input.GetKeyDown(Key.ENTER))
        {
                LateDestroy();
        }

    }
}

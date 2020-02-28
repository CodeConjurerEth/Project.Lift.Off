using System;
using System.Collections.Generic;
using GXPEngine;

public class GameOverScreen : Sprite
{
    private ScoreHUD _scoreHUD;
    // private ScoreBoard _scoreBoard;

    public GameOverScreen() : base("Game_Over_Screen.png")
    {
        //   _scoreBoard = new ScoreBoard("ScoreBoard.txt");
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

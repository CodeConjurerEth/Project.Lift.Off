using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class ScoreHUD : Canvas
{
    private ScoreBoard _scoreBoard;
    private Font _arialFont;

    public ScoreHUD() : base(1920, 1080)
    {
        _scoreBoard = new ScoreBoard("ScoreBoard.txt");

        _arialFont = new Font("Arial", 100);

        for (int i = 0; i <= _scoreBoard.GetHighScores().Count - 1; i++)
        {
            // graphics.DrawString("test", _arialFont, Brushes.Black, 700, 50);
            if(i<=3)
                graphics.DrawString(_scoreBoard.GetHighScores()[i], _arialFont, Brushes.Red, 760, 500 + i * 100);
        }
    }

}

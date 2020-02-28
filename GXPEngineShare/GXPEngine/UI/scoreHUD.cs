using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;
using System.Drawing.Text;

public class ScoreHUD : Canvas
{
    private ScoreBoard _scoreBoard;
    private Font _font;
    private PrivateFontCollection _fontCollection;

    public ScoreHUD() : base(1920, 1080, false)
    {
        _scoreBoard = new ScoreBoard("ScoreBoard.txt");

        _fontCollection = new PrivateFontCollection();
        _fontCollection.AddFontFile("CarnevaleeFreakshow.ttf");
  
        _font = new Font(_fontCollection.Families[0], 80);

        for (int i = 0; i <= _scoreBoard.GetHighScores().Count - 1; i++)
        {
            if(i<=3)
                graphics.DrawString(_scoreBoard.GetHighScores()[i], _font, Brushes.Red, 830, 550 + i * 90);
        }
    }

}

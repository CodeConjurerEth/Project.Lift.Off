using System;
using System.Drawing;

namespace GXPEngine
{
    public class HUD : Canvas
    {

        private Lives _lives;
        private Player _player;
        private Font _arialFont;

        public HUD(Player player) : base(1920, 1080)
        {
            _lives = new Lives(player);
            _player = player;
            _arialFont = new Font("Arial", 20);

            AddChild(_lives);
        }

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString(_player.ScorePlayer.ToString(), _arialFont, Brushes.White, 50, 16);
           // graphics.DrawString(_player.HighScorePlayer.ToString(), _arialFont, Brushes.White, 400, 16);
           // graphics.DrawString(_player.Highscore1.ToString() , SystemFonts.DefaultFont, Brushes.White, 450, 16);
            //graphics.DrawString(_player.Highscore2.ToString(), SystemFonts.DefaultFont, Brushes.White, 500, 16);
            //graphics.DrawString(_player.Highscore3.ToString(), SystemFonts.DefaultFont, Brushes.White, 550, 16);
        }
    }
}
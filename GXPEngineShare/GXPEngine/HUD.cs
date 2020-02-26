using System;
using System.Drawing;
using System.Collections.Generic;

namespace GXPEngine
{
    public class HUD : Canvas
    {

        private Lives _lives;
        private Player _player;
        private Font _arialFont;
        private Arc _arc;

        public HUD(Player player) : base(1920, 1080)
        {
            _lives = new Lives(player);
            _player = player;
            _arialFont = new Font("Arial", 50);
            _arc = new Arc();

            AddChild(_arc);
            AddChild(_lives);
        } 

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString(_player.ScorePlayer.ToString(), _arialFont, Brushes.White, 50, 16);
            arcFollow();
        }

        private void arcFollow()
        {
            _arc.x = _player.x;
        }
    }
}
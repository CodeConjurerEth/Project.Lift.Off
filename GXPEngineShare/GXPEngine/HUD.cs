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
        private Sprite _arcPointer;

        public HUD(Player player) : base(1920, 1080, false)
        {
            _lives = new Lives(player);
            _player = player;
            _arialFont = new Font("Carnevalee Freakshow", 50);
            _arc = new Arc();

            arcSetup();
            pointerSetup();

            AddChild(_arc);
            AddChild(_arcPointer);
            AddChild(_lives);
        } 

        void Update()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString(_player.ScorePlayer.ToString(), _arialFont, Brushes.White, 50, 16);
            arcFollow();
            pointerFollow();
        }

        private void arcSetup()
        {
            _arc.y = _player.y - _player.height - 20;
        }

        private void pointerSetup()
        {
            _arcPointer = new Sprite("arcpointer.png");
            _arcPointer.SetOrigin(_arcPointer.width / 2, _player.y);
            _arcPointer.y = _player.y;
        }

        private void arcFollow()
        {
            _arc.x = _player.x;
        }

        private void pointerFollow()
        {
            _arcPointer.x = _player.x;

            if (_player.GetMouseX() >= 0 && _player.GetMouseX() <= 1920)
                _arcPointer.rotation = _player.GetMouseX().Map(0, 1920, -_player.GetMaxBalance()/1.5f, _player.GetMaxBalance()/1.5f);
        }
    }
}
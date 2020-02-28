using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;

namespace GXPEngine
{
    public class HUD : Canvas
    {

        private Lives _lives;
        private Player _player;
        private Font _font;
        private Arc _arc;
        private Sprite _arcPointer;
        private PrivateFontCollection _fontCollection;

        public HUD(Player player) : base(1920, 1080, false)
        {
            _player = player;
            _lives = new Lives(player);
            _arc = new Arc();

            _fontCollection = new PrivateFontCollection();
            _fontCollection.AddFontFile("CarnevaleeFreakshow.ttf");

            _font = new Font(_fontCollection.Families[0], 50);

            arcSetup();
            pointerSetup();

            AddChild(_arc);
            AddChild(_arcPointer);
            AddChild(_lives);
        } 

        void Update()
        {
            drawScore();
            arcFollow();
            pointerFollow();
        }

        private void arcSetup()
        {
            _arc.y = _player.y - _player.height - 113 + 20;
        }

        private void pointerSetup()
        {
            _arcPointer = new Sprite("arcpointer.png");
            _arcPointer.width = 10;
            _arcPointer.SetOrigin(_arcPointer.width / 2, _player.y);

            _arcPointer.y = _player.y + 20;
        }

        private void arcFollow()
        {
            _arc.x = _player.x;
        }

        private void pointerFollow()
        {
            _arcPointer.x = _player.x;

            if (_player.GetMouseX() >= 0 && _player.GetMouseX() <= 1920)
                _arcPointer.rotation = _player.GetMouseX().Map(0, 1920, -_player.GetMaxBalance()/1.7f, _player.GetMaxBalance()/1.7f);
        }

        private void drawScore()
        {
            graphics.Clear(Color.Empty);
            graphics.DrawString(_player.ScorePlayer.ToString(), _font, Brushes.White, 75, 50);
        }
    }
}
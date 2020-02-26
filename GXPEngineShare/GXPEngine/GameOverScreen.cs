using System;

namespace GXPEngine
{
    class GameOverScreen : Sprite
    {
        public GameOverScreen() : base("Game_Over_Screen.png")
        {
            
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
}

using System;

namespace GXPEngine
{
    class HowToPlayScreen : Sprite
    {
        public HowToPlayScreen() : base("PinkBackground.png")
        {

        }

        private void Update()
        {
            if (Input.GetKeyDown(Key.ENTER))
            {
                LateDestroy();
            }
        }
    }
}

using System;

namespace GXPEngine
{
    public class StartUpScreen : GameObject
    {
        Button _buttonGoToMainMenu;

        Main_Menu screenHandler;

        Background _backgroundStartUp;

        private bool _hasStarted;

        public StartUpScreen() : base()
        {
            _hasStarted = false;

            _backgroundStartUp = new Background("Startup.png");
            AddChild(_backgroundStartUp);
        }

        private void Update()
        {
            if (Input.GetKeyDown(Key.ENTER))
            {
                if (screenHandler == null)
                {
                    startMenu();
                }
            }

            if (Input.GetKeyDown(Key.M))
            {
                resetLevel();
            }
        }

        private void startMenu()
        {
            if (_hasStarted == false)
            {
                screenHandler = new Main_Menu();
                AddChild(screenHandler);
            }
        }

        private void resetLevel()
        {
            if (screenHandler != null)

            {
                screenHandler.Destroy();
                screenHandler = null;
            }

            _hasStarted = false;
        }
    }
}
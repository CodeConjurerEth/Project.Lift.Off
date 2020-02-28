using System;

namespace GXPEngine
{
    public class StartUpScreen : GameObject
    {
        Button _buttonGoToMainMenu;

        Main_Menu screenHandler;

        Background _backgroundStartUp;

        protected Sound _pressButtonSound;
        protected SoundChannel _backgroundMusic;

        bool playmusic;

        

        private bool _hasStarted;

        public StartUpScreen() : base()
        {
            _pressButtonSound = new Sound("buttonclick.wav");

            _hasStarted = false;


            startMusic();

            _backgroundStartUp = new Background("Startup.png");
            AddChild(_backgroundStartUp);
            Console.WriteLine(_hasStarted);
        }

        void startMusic()
        {
            if (_backgroundMusic == null)
            {
                Sound backgroundMusic = new Sound("backgroundmusic.wav", true, true);
                _backgroundMusic = backgroundMusic.Play();
            }
        }

        private void Update()
        {


            if (Input.GetKeyDown(Key.ENTER))
            {
                
                _backgroundMusic.Stop();
                    startMenu();
            }

            if(Input.GetKeyDown(Key.ENTER) && _hasStarted == false)
            {
                _pressButtonSound.Play();
                _hasStarted = true;
            }

            if (Input.GetKeyDown(Key.M))
            {
                _backgroundMusic.Stop();
                resetLevel();
            }
        }

        private void startMenu()
        {
            if (screenHandler == null)
            {
                screenHandler = new Main_Menu();
                AddChild(screenHandler);
            }
        }


        private void resetLevel()
        {
            if (screenHandler != null)

            {
                _backgroundMusic.Stop();
                screenHandler.Destroy();
                screenHandler = null;
            }

            _hasStarted = false;
        }
    }
}
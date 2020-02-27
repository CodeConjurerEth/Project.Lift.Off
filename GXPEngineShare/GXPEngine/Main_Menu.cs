using System;

namespace GXPEngine
{
    public class Main_Menu : GameObject
    {
        Button _buttonStartGame, _buttonShowInstructions, _buttonArrow1;

        Background _backgroundHowToPlay, _backgroundMenu;

        Level _level;

        const int START     = 1;
        const int HOWTOPL   = 2;


        private bool _hasStarted;

        private bool _backgroundHowToPlayIsShown = false;

        int state;

        public Main_Menu() : base()
        {
            backgroundMenu();

            _hasStarted = false;
            startGameButton();
            howToPlayButton();

            state = 1;

            _buttonArrow1 = new Button("arrow.png");
            AddChild(_buttonArrow1);

            _buttonArrow1.scale = 0.6f;

            _buttonArrow1.Mirror(false, true);
            _buttonArrow1.rotation = -10;

            _buttonArrow1.x = 290;
            _buttonArrow1.y = 810;
        }

        private void Update()
        {
            switchStates();

            if (state == START && Input.GetKeyDown(Key.ENTER))
            {
                startGame();
                hideButtons();
            }
            if (_level == null)
            {
                if (state == HOWTOPL && Input.GetKeyDown(Key.ENTER))
                {
                    hideButtons();
                    backgroundHowToPlay();
                    _backgroundHowToPlayIsShown = true;
                }
            }

            if (_level != null)
            {
                if (_level.isTheGameOver == true && Input.GetKeyDown(Key.ENTER))
                {
                    resetLevel();
                    _buttonArrow1 = new Button("arrow.png");
                    AddChild(_buttonArrow1);
                    _buttonArrow1.Mirror(false, true);
                    _buttonArrow1.scale = 0.6f;
                    _buttonArrow1.rotation = -10;
                    _buttonArrow1.x = 290;
                    _buttonArrow1.y = 810;
                }
            }

            if (_backgroundHowToPlayIsShown == true && Input.GetKeyDown(Key.A))
            {
                resetLevel();
                _buttonArrow1 = new Button("arrow.png");
                AddChild(_buttonArrow1);
                _backgroundHowToPlayIsShown = false;
                _buttonArrow1.Mirror(false, true);
                _buttonArrow1.scale = 0.6f;
                _buttonArrow1.rotation = -10;
                _buttonArrow1.x = 290;
                _buttonArrow1.y = 810;
            }


            if (_level != null)
            {
                if (_level.isTheGameOver == true)
                {
                    backgroundGameOver();
                }
            }
        }

        private void switchStates()
        {
            if (state == HOWTOPL && Input.GetKeyDown(Key.A))
            {
               // Console.WriteLine("state = start");
                state = START;
                _buttonArrow1.Mirror(false, true);
                _buttonArrow1.rotation = -10;

                _buttonArrow1.x = 290;
                _buttonArrow1.y = 810;
            }

            if (state == START && Input.GetKeyDown(Key.D))
            {
                //Console.WriteLine("state = howtoplay");
                state = HOWTOPL;
                _buttonArrow1.Mirror(true, true);
                _buttonArrow1.rotation = 10;
                _buttonArrow1.x = 1420;
                _buttonArrow1.y = 780;
            }
        }

        public void startGameButton()
        {
            _buttonStartGame = new Button("startbutton.png");
            AddChild(_buttonStartGame);

            _buttonStartGame.x = 220;
            _buttonStartGame.y = 630;

        }

        private void howToPlayButton()
        {
            _buttonShowInstructions = new Button("howtoplaybutton.png");
            AddChild(_buttonShowInstructions);

            _buttonShowInstructions.x = 1320;
            _buttonShowInstructions.y = 630;
        }        



        private void hideButtons()
        {
            _buttonStartGame.visible = false;
            _buttonShowInstructions.visible = false;
            _buttonArrow1.visible = false;
            _backgroundMenu.visible = false;
        }

        private void startGame()
        {
            if (_hasStarted == false)
            {
                _level = new Level();
                AddChild(_level);
                _hasStarted = true;
            }
        }

        private void backgroundGameOver()
        {
            GameOverScreen gameover = new GameOverScreen(); 
            AddChild(gameover);
        }

        private void backgroundHowToPlay()
        {
            HowToPlayScreen howToPlayScreen = new HowToPlayScreen();
            AddChild(howToPlayScreen);
        }

        private void backgroundMenu()
        {
            _backgroundMenu = new Background("mainmenubackground.png");
            AddChild(_backgroundMenu);
        }

        private void resetLevel()
        {
            if (_level != null)

            {
                _level.Destroy();
                _level = null;
            }
            if (_backgroundHowToPlay != null)
            {
                _backgroundHowToPlay.Destroy();
                _backgroundHowToPlay = null;
            }
            if (_buttonShowInstructions != null)
            {
                _buttonShowInstructions.Destroy();
                _buttonShowInstructions = null;
            }
            if (_buttonStartGame != null)
            {
                _buttonStartGame.Destroy();
                _buttonStartGame = null;
            }
            if (_buttonArrow1 != null)
            {
                _buttonArrow1.Destroy();
                _buttonArrow1 = null;
            }
            if (_backgroundMenu != null)
            {
                _backgroundMenu.Destroy();
                _backgroundMenu = null;
            }
            backgroundMenu();
            startGameButton();
            howToPlayButton();
            _hasStarted = false;
            state = 1;
        }
        /*
        private void highScore()
        {
            if (_player.GetLives() == -1)
            {
                Console.WriteLine(Highscore1);
                _player.HighScorePlayer = _player.ScorePlayer;

                if (_player.HighScorePlayer > Highscore1)
                {
                    Highscore3 = Highscore2;
                    Highscore2 = Highscore1;
                    Highscore1 = _player.HighScorePlayer;
                }
                else if (_player.HighScorePlayer > Highscore2)
                {
                    Highscore3 = Highscore2;
                    Highscore2 = _player.HighScorePlayer;
                }
                else if (_player.HighScorePlayer > Highscore3)
                {
                    Highscore3 = _player.HighScorePlayer;
                }
            }
        }

        public int HighScore1()
        {
            return Highscore1;
        }

        public int HighScore2()
        {
            return Highscore2;
        }

        public int HighScore3()
        {
            return Highscore3;
        }
        */
    }
}
//using System;
//using GXPEngine;

//public class SceneManager : GameObject
//{
//    //public Menu menu { get; private set; }


//    int state;

//    Button _buttonGoToMainMenu, _buttonStartGame, _buttonShowInstructions, _buttonArrow1;

//    Background _backgroundHowToPlay, _backgroundMenu;

//    Level _level;

//    private bool _hasStarted;


//    public SceneManager()
//    {

//        state = 1;

//        _hasStarted = false;

//    }

//    private void Update()
//    {
//        if (state == 1)
//        {
//            startUpScreen();
//        }

//        if (state == 2)
//        {
//            mainMenu();
//        }
//        if (state == 3)
//        {
//            startLevel();
//        }
//        if (state == 4)
//        {
//            gameOver();
//        }
//    }

//    private void startUpScreen()
//    {
//        StartUpScreen startUpScreen = new StartUpScreen();
//        AddChild(startUpScreen);

//        if (Input.GetKeyDown(Key.ENTER))
//        {
//                state = 2;
//        }
//    }


//    private void mainMenu()
//    {
//        Main_Menu mainmenu = new Main_Menu(_level);
//        AddChild(mainmenu);
//        if (Input.GetKeyDown(Key.Q))
//        {
//            state = 3;
//        }

//    }

//    private void startLevel()
//    {
//        //if (_hasStarted == false)
//        //{
//        //    _level = new Level();
//        //    AddChild(_level);
//        //    _hasStarted = true;
//        //}
//    }

//    private void gameOver()
//    {
//        if (_level != null)
//        {
//            if (_level.isTheGameOver == true)
//            {
//                GameOverScreen gameover = new GameOverScreen();
//                AddChild(gameover);
//            }
//        }
//    }

//    private void hideButtons()
//    {

//    }


//}
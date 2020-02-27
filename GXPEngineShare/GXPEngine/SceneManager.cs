//using System;
//using GXPEngine;

//public class SceneManager : GameObject
//{
//    //public Menu menu { get; private set; }


//    int state;

//    Main_Menu _mainMenu;

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
//    }

//    private void startUpScreen()
//    {
//        StartUpScreen startUpScreen = new StartUpScreen();
//        AddChild(startUpScreen);

//        if (Input.GetKeyDown(Key.ENTER))
//        {
//            state = 2;
//        }
//    }


//    private void mainMenu()
//    {
//        _mainMenu = new Main_Menu();
//        AddChild(_mainMenu);
//    }
//}
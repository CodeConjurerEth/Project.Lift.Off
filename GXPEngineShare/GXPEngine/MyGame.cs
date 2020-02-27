using System;									// System contains a lot of default C# libraries 
using System.Drawing.Text;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

public class ClownBalance : Game
{
    public ClownBalance() : base(1920, 1080, false, true)      // Create a window that's 800x600 and NOT fullscreen
    {

        StartUpScreen startUpScreen = new StartUpScreen();
        AddChild(startUpScreen);

        //Main_Menu mainMenu = new Main_Menu();
        //AddChild(mainMenu);

        //SceneManager scenemanager = new SceneManager();
        //AddChild(scenemanager);


    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new ClownBalance().Start();                  // Create a "MyGame" and start it
    }
}
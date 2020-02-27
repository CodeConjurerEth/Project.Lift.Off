using GXPEngine;
using System;

public class Level : GameObject
{
    //private Player _player;
    //private HUD _HUD
    private Player _player;
    private Background _backgroundLevel;
    private Sprite _crowd;
    Tomatoes tomatoes;
    Flowers flowers;

    Collectables collectablesLeft, collectablesRight;

    private int _nextSpawnTimeLeft;
    private int _nextSpawnTimeRight;
    private int _nextSpawnTimeMiddle;
    private int _nextSpawnTimeWholeScreen;
    private bool _isSpawned;

    public int _collectableCounter;

    Random random;

    private int width = 1920, height = 1080;

    public bool isTheGameOver;
    private ScoreBoard scoreBoard;
    private int nextTimer;
    private int time;
    private int i;
   
    public Level()
	{
        backgroundLevel();
        crowdSetup();
        playerSetup();

        _isSpawned = false;
        scoreBoard = new ScoreBoard("ScoreBoard.txt");
        isTheGameOver = false;
        _collectableCounter = 0;
        i = 0;

        //Timer timer = new Timer(3000, LateDestroy);
        //AddChild(timer);
        random = new Random();

        time = 5000;
      

        HUD hud = new HUD(_player);
        AddChild(hud);

    }

    private void CollectableAppear()
    {
        if(_isSpawned == false)
        { 
            if (_player.ScorePlayer == i*2000 + 1000)
            {

                collectablesLeft = new Collectables(105, 330);
                collectablesRight = new Collectables(1715, 330);

                _isSpawned = true;

                nextTimer = Time.time + time;

                AddChild(collectablesLeft);
                AddChild(collectablesRight);

                
                i++;

               
            }
        }
        if (Time.time >= nextTimer)
            _isSpawned = false;
        Console.WriteLine(_isSpawned);
    }

    private void levelEasy()
    {
        if (Time.time > _nextSpawnTimeLeft)
        {
            flowers = new Flowers(random.Next(0, 1920), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(0, 860), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeLeft = Time.time + random.Next(1000, 3000);
        }
    }

    private void levelMedium()
    {
        if (Time.time > _nextSpawnTimeLeft)
        {
            flowers = new Flowers(random.Next(0, 860), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(0, 860), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeLeft = Time.time + random.Next(1000, 3000);
        }
        if (Time.time > _nextSpawnTimeRight)
        {
            flowers = new Flowers(random.Next(860, 1920), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(860, 1920), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeRight = Time.time + random.Next(1000, 3000);
        }
    }

    private void levelHard()
    {
        if (Time.time > _nextSpawnTimeLeft)
        {
            
            flowers = new Flowers(random.Next(0, 860), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(0, 640), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeLeft = Time.time + random.Next(1000, 3000);
        }
        if (Time.time > _nextSpawnTimeRight)
        {
            flowers = new Flowers(random.Next(860, 1920), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(640, 1280), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeRight = Time.time + random.Next(1000, 2000);
        }
        if (Time.time > _nextSpawnTimeMiddle)
        {

            tomatoes = new Tomatoes(random.Next(1280, 1920), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeMiddle = Time.time + random.Next(1000, 2000);
        }
    }

    private void levelExtreme()
    {
        if (Time.time > _nextSpawnTimeLeft)
        {

            flowers = new Flowers(random.Next(0, 860), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(0, 640), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeLeft = Time.time + random.Next(1000, 2000);
        }
        if (Time.time > _nextSpawnTimeRight)
        {
            flowers = new Flowers(random.Next(860, 1920), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(640, 1280), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeRight = Time.time + random.Next(1000, 2000);
        }
        if (Time.time > _nextSpawnTimeMiddle)
        {

            tomatoes = new Tomatoes(random.Next(1280, 1920), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeMiddle = Time.time + random.Next(1000, 2000);
        }
        if (Time.time > _nextSpawnTimeWholeScreen)
        {

            tomatoes = new Tomatoes(random.Next(0, 1920), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeMiddle = Time.time + random.Next(1000, 2000);
        }
    }

    public void CheckGameOver()
    {
        levelEasy();

        if (_player != null)
        {
            if (_player.LivesPlayer == -1)
            {
                isTheGameOver = true;
                scoreBoard.AddLine(_player.GetScore().ToString());
                Destroy();
            }
        }
    }


    private void Update()
    {
        if (_player.ScorePlayer < 1500)
        {
            levelEasy();
        }
        if (_player.ScorePlayer > 1500 && _player.ScorePlayer < 3000)
        {
            levelMedium();
        }
        if (_player.ScorePlayer > 3000)
        {
            levelHard();
        }



        CollectableAppear();

        CheckGameOver();
    }

    private void playerSetup()
    {
        _player = new Player();

        _player.SetOrigin(512, 1024);
        _player.x = width / 2;
        _player.y = height / 2 - 113;

        AddChild(_player);
    }

    public Player GetPlayer()
    {
        return _player;
    }

    private void backgroundLevel()
    {
        _backgroundLevel = new Background("backgroundLevel.png");
        AddChild(_backgroundLevel);
    }

    private void crowdSetup()
    {
        _crowd = new Sprite("Crowd.png");
        AddChild(_crowd);
    }
  
}

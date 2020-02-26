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
    private int _nextSpawnTimeCollectables;

    public int _collectableCounter = 0;

    Random random = new Random();

    private int width = 1920, height = 1080;

    public bool isTheGameOver;

   
    public Level()
	{
        backgroundLevel();
        crowdSetup();

        _player = new Player();
        playerSetup();
        AddChild(_player);
        isTheGameOver = false;

        //Timer timer = new Timer(3000, LateDestroy);
        //AddChild(timer);

        HUD hud = new HUD(_player);
        AddChild(hud);
    }

    private void CollectableAppear()
    {
        if (_player.ScorePlayer == 400 && _collectableCounter ==0)
        {
            Console.WriteLine(_collectableCounter);
            _collectableCounter++;

            collectablesLeft = new Collectables(105, 330);
            AddChild(collectablesLeft);

            collectablesRight = new Collectables(1715, 330);
            AddChild(collectablesRight);
        }
        if (_player.ScorePlayer == 2000 && _collectableCounter == 1)
        {
            _collectableCounter++;
            collectablesLeft = new Collectables(105, 330);
            AddChild(collectablesLeft);

            collectablesRight = new Collectables(1715, 330);
            AddChild(collectablesRight);
        }
    }

    public void CheckGameOver()
    {
        if (_player != null)
        {
            if (_player.LivesPlayer == -1)
            {
                isTheGameOver = true;
                Destroy();
            }
        }
    }


    private void Update()
    {
        if (Time.time > _nextSpawnTimeLeft)
        {
            flowers = new Flowers(random.Next(0, 860), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(0, 860), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeLeft = Time.time + random.Next(1000, 2000);
        }
        if (Time.time > _nextSpawnTimeRight)
        {
            flowers = new Flowers(random.Next(860, 1920), random.Next(900, 1080));
            AddChild(flowers);

            tomatoes = new Tomatoes(random.Next(860, 1920), random.Next(900, 1080));
            AddChild(tomatoes);

            _nextSpawnTimeRight = Time.time + random.Next(1000, 2000);
        }

        Console.WriteLine(_collectableCounter);

        CollectableAppear();

        CheckGameOver();
    }

    private void playerSetup()
    {
        _player.SetOrigin(512, 1024);
        _player.x = width / 2;
        _player.y = height / 2 - 113;
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

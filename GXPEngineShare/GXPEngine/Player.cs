using GXPEngine;
using System;

public class Player : AnimationSprite
{
    private Mouse _mouseHandler;
    

    private bool _isMoving;

    private float _currentSpeed, _maxSpeed;
    private float _moveSpeed;
    private float _friction;
    
    private float _currentBalance, _maxBalance;
    private float _balanceSpeed;
    private float _balanceDifficulty;

    private bool _windToLeft;
    private float _windSpeed;

    private float _width = 1920, _height = 1080;

    private float _mouseX;

    public int ScorePlayer, HighScorePlayer;
    public int LivesPlayer;

    private int _tomatoPush;
    private int _numbOffFrames;

    private Sprite _hitBox;
    Random random;


    public Player() : base("ForwardAnimation20FPS.png", 8, 3) // monocycle
    {

        _mouseHandler = new Mouse();
        random = new Random();

        scale = 0.3f;

        _tomatoPush = 15;
        _numbOffFrames = 20;
        _isMoving = false;

        _currentSpeed = 0f;
        _moveSpeed = 0.5f;
        _maxSpeed = 15f;
        _friction = 0.2f;

        _currentBalance = 0f;
        _maxBalance = 60f;
        _balanceSpeed = 0.5f; // (movement)
        _balanceDifficulty = 0.5f;  // Bigger == faster (mouse)

        _windToLeft = true;
        _windSpeed = 0.1f;

        ScorePlayer = 0;
        LivesPlayer = 2;

        
        AddChild(_mouseHandler);

        hitBox();
    }

    public int GetScore()
    {
        return ScorePlayer;
    }

    public int GetLives()
    {
        return LivesPlayer;
    }
    private void walkingClown()
    {

        int frame = (int)(this.x / 5) % _numbOffFrames;
        SetFrame(frame);
    }


  
    private void hitBox()
    {
        _hitBox = new Sprite("hitboxplayer.png");
        AddChild(_hitBox);
        _hitBox.alpha = 0.5f;
        _hitBox.SetXY(-180, -980);
    }

    private void handleHitBoxCollisions()
    {
        foreach (GameObject other in _hitBox.GetCollisions())
        {

            if (other is Tomatoes)
            {
                Tomatoes tomato = other as Tomatoes;
                tomato.Splash();
                if (random.Next(2) == 0)
                    _currentBalance -= _tomatoPush;
                else
                    _currentBalance += _tomatoPush;
                
            }
            if (other is Flowers)
            {
                Flowers flowers = other as Flowers;
                flowers.Catched();
                ScorePlayer = ScorePlayer + 200;
            }
            if (other is Collectables)
            {
                Collectables collectables = other as Collectables;
                collectables.destroyTheCollectable();
                ScorePlayer = ScorePlayer + 600;
            }

        }
    }

    private void handleInput()
    {

        _mouseX = Input.mouseX;

        if ((Input.GetKey('d') || Input.GetKey('D')) && (Input.GetKey('a') || Input.GetKey('A')))
        {
            if (_currentSpeed < _maxSpeed - _currentSpeed)
            {
                _currentSpeed += _moveSpeed;
                if (_currentBalance > -_maxBalance)
                {
                    _currentBalance -= _balanceSpeed;
                }
                //walkingClown();
            }
        }
        else if (Input.GetKey('d') || Input.GetKey('D'))
        {
            if (_currentSpeed < _maxSpeed - _currentSpeed)
            {
                _currentSpeed += _moveSpeed;
                if (_currentBalance > -_maxBalance )
                {
                    _currentBalance -= _balanceSpeed;
                }
                walkingClown();
            }
            
        }
        else if (Input.GetKey('a') || Input.GetKey('A'))
        {
            if (_currentSpeed > -_maxSpeed - _currentSpeed)
            {
                _currentSpeed -= _moveSpeed;
                if (_currentBalance < _maxBalance )
                {
                    _currentBalance += _balanceSpeed;
                }
                walkingClown();
            }
        }
    }

    private void balanceClown()
    {
      //  if (_mouseHandler.IsMoving() == true)
        _currentBalance += _mouseX.Map(0, _width, -_balanceDifficulty, _balanceDifficulty);

        if (_currentBalance <= -_maxBalance || _currentBalance >= _maxBalance)
        { 
            LivesPlayer--;
            resetPlayer();
        }
        this.rotation = _currentBalance;

        //else
        //set cursor to middle of screen
    }

    private void movement()
    {
        if (_currentSpeed > 0 && _currentSpeed <= _friction || _currentSpeed < 0 && _currentSpeed >= _friction)
            _isMoving = false;
        else
            _isMoving = true;

        if (_isMoving)
        {
            if (_currentSpeed > 0)
                _currentSpeed -= _friction;
            else if (_currentSpeed < 0)
                _currentSpeed += _friction;

            this.x += _currentSpeed;

        }
        
    }



    private void resetPlayer()
    {
        this.x = _width / 2;
        this.y = _height / 2 - 113;
        _currentBalance = 0;

    }

    private void wind()
    {
        if(_windToLeft == true)
        {
            if (_currentSpeed > -_maxSpeed - _currentSpeed)
            {
                _currentSpeed -= _windSpeed;
                if (_currentBalance < _maxBalance)
                {
                    _currentBalance += _balanceSpeed*_windSpeed;
                }
            }
        }
        else //wind to right
        {
            if (_currentSpeed < _maxSpeed - _currentSpeed)
            {
                _currentSpeed += _windSpeed;
                if (_currentBalance > -_maxBalance)
                {
                    _currentBalance -= _balanceSpeed*_windSpeed;
                }
            }
        }
    }

    public void Update()
    {
        handleInput();
        movement();
        wind();
        balanceClown();
        handleHitBoxCollisions();
    }

}

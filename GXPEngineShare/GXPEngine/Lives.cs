using System;
using GXPEngine;
using GXPEngine.Core;

public class Lives : AnimationSprite
{
    Player _player;
    public Lives(Player player) : base("Life.png", 3, 1)
    {

        _player = player;

        this.x = 1730;
        this.y = -10;
    }

    public void Update()
    {
        SetFrame(_player.GetLives());
        LivesAnimation();

    }

    public void LivesAnimation()
    {

        if (_player.GetLives() == -1)
        {
            LateDestroy();
        }
    }
}

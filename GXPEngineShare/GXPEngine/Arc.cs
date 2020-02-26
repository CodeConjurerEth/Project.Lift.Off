using System;
using GXPEngine;

public class Arc : Sprite
{
    private Sprite _line;

    public Arc() : base("Arc.png")
    {
        this.scale = 0.5f;
        this.SetOrigin(this.width, this.height/4);

        _line = new Sprite("square.png");
        _line.SetOrigin(_line.width / 2, _line.height);
        _line.y = this.y-200;
        _line.x = this.x;
        _line.scale = 3;
        AddChild(_line);
    }

    public void Update()
    {
        
    }
}

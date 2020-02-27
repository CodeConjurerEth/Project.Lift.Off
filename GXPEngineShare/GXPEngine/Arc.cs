using System;
using GXPEngine;

public class Arc : Sprite
{

    public Arc() : base("Arc.png")
    {
        this.scale = 0.5f;
        this.SetOrigin(this.width, this.height/2);

    }

}

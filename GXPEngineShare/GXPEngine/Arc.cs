using System;
using GXPEngine;

public class Arc : Sprite
{
    private Sprite _arcPointer;

    public Arc() : base("Arc.png")
    {
        this.scale = 0.5f;
        this.SetOrigin(this.width, this.height/4);

    }

    public void Update()
    {
        arcPointer();
    }

    private void arcPointer()
    {
        _arcPointer = new Sprite("arcpointer.png");
        AddChild(_arcPointer);
        _arcPointer.SetXY(-20, 50);
    }
}

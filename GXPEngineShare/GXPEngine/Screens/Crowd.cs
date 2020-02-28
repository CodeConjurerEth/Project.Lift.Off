using GXPEngine;
using System;

public class Crowd : Animation
{


    public Crowd() : base("crowdanimation.png", 1, 2)
    {


    }

    private void Update()
    {
        animation();
    }


    private void animation()
    {
        crowdAnimation(0, 2);
    }
  
}
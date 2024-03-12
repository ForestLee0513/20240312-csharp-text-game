using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Player: GameObject
{
    public Player(int newX, int newY)
    {
        shape = 'P';
        x = newX;
        y = newY;
    }

    ~Player() { }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}


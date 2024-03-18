using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Monster: GameObject
{
    public Monster()
    {
        shape = 'M';
        layerOrder = 3000;
    }

    public Monster(int newX, int newY)
    {
        shape = 'M';
        x = newX;
        y = newY;
    }

    ~Monster() { }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Render()
    {
        base.Render();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Wall: GameObject
{
    public Wall(int newX = 0, int newY = 0)
    {
        shape = '*';
        x = newX;
        y = newY;
        layerOrder = 2000;
    }

    ~Wall() { }

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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Goal: GameObject
{
    public Goal(int newX, int newY)
    {
        shape = 'G';
        x = newX;
        y = newY;
        layerOrder = 2000;
    }

    ~Goal() { }

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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Floor: GameObject
{
    public Floor(int newX, int newY)
    {
        shape = ' ';
        x = newX;
        y = newY;
    }

    ~Floor() { }

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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Collider2D : Component
{
    public Collider2D()
    {
        isTrigger = false;
    }

    public bool isTrigger;

    public bool Check(GameObject other)
    {
        if(other.transform.x == transform.x && other.transform.y == transform.y)
        {
            return true;
        }

        return false;
    }
}


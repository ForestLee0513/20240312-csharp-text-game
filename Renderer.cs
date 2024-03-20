public enum RenderOrder
{
    None = 0,
    Floor = 100,
    Wall = 200,
    Goal = 300,
    Player = 400,
    Monster = 500,
}

class Renderer: Component
{
    public RenderOrder renderOrder;
    public Renderer()
    {
        renderOrder = RenderOrder.None;
    }

    ~Renderer()
    {

    }

    public virtual void Render()
    {

    }
}

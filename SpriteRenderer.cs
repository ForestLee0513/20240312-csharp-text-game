class SpriteRenderer: Renderer
{
    public char shape;
    public SpriteRenderer()
    {
    }

    public override void Render()
    {
        base.Render();
        Console.SetCursorPosition(transform.x, transform.y);
        Console.Write(shape);
    }
}
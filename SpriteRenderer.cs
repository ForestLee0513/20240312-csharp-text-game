class SpriteRenderer: Renderer
{
    public char shape;
    public SpriteRenderer()
    {
    }

    public override void Render()
    {
        if (transform != null)
        {
            Console.SetCursorPosition(transform.x, transform.y);
            Console.Write(shape);
        }
    }
}
using SDL2;
using System.Security;

public enum RenderOrder
{
    None = 0,
    Floor = 100,
    Wall = 200,
    Goal = 300,
    Player = 400,
    Monster = 500,
}

class SpriteRenderer: Renderer
{
    public char shape;
    public RenderOrder renderOrder;
    public string textureName;
    public bool isMultiple = false;
    public int spriteCount = 1;
    ulong currentTime = 0;
    public int currentXIndex = 1;
    public int currentYIndex = 1;
    protected ulong executeTime = 200;

    public SDL.SDL_Color colorKey;

    public SpriteRenderer()
    {
        renderOrder = RenderOrder.None;
        textureName = "";
        colorKey.r = 255;
        colorKey.g = 255;
        colorKey.b = 255;
        colorKey.a = 255;
    }

    public void Load(string _textureName)
    {

        textureName = _textureName;
        ResourceManager.Load(textureName, colorKey);
    }

    public override void Update()
    {
        if(isMultiple)
        {
            base.Update();
            currentTime += Engine.GetInstance().deltaTime;

            if(currentTime >= executeTime)
            {
                currentXIndex++;
                currentXIndex = currentXIndex % spriteCount;
                currentTime = 0;
            }
        }
    }

    public override void Render()
    {
        SDL.SDL_GetTicks64();
        if (transform != null)
        {
            //Console.SetCursorPosition(transform.x, transform.y);
            //Console.Write(shape);

            Engine myEngine = Engine.GetInstance();
            SDL.SDL_Rect myRect = new SDL.SDL_Rect();
            myRect.x = transform.x*30;
            myRect.y = transform.y*30;
            myRect.w = 30;
            myRect.h = 30;

            //unsafe
            //{
            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            uint format = 0;
            int access = 0;
            SDL.SDL_QueryTexture(ResourceManager.Find(textureName), out format, out access, out rect.w, out rect.h);
            if(isMultiple)
            {
                int SpriteSizeX = rect.w / spriteCount;
                int SpriteSizeY = rect.h / spriteCount;
                rect.x = SpriteSizeX * currentXIndex;
                rect.y = SpriteSizeY * currentYIndex;
                rect.w = SpriteSizeX;
                rect.h = SpriteSizeY;
            }
            else
            {
                rect.x = 0;
                rect.y = 0;
            }

            SDL.SDL_Rect destRect = new SDL.SDL_Rect();
            destRect = myRect;

            SDL.SDL_RenderCopy(myEngine.myRenderer, ResourceManager.Find(textureName), ref rect, ref destRect);
            //}
        }
    }
}
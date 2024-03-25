using SDL2;

internal class ResourceManager
{
    protected static Dictionary<string, IntPtr> Databases = new Dictionary<string, IntPtr>();

    public static IntPtr Load(string fileName, SDL.SDL_Color _colorKey)
    {
        if (Databases.ContainsKey(fileName) == false)
        {
            string dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
            unsafe
            {
                // LoadTexture
                SDL.SDL_Surface* mySurface = (SDL.SDL_Surface*)SDL.SDL_LoadBMP(dir + "/../data/assets/" + fileName + ".bmp");

                SDL.SDL_SetColorKey((IntPtr)mySurface, 1, SDL.SDL_MapRGBA(mySurface -> format , _colorKey.r, _colorKey.g, _colorKey.b, _colorKey.a));
                IntPtr myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, (IntPtr)mySurface);
                Databases[fileName] = myTexture;
                SDL.SDL_FreeSurface((IntPtr)mySurface);
            }
        }


        return Databases[fileName];
    }


    public static IntPtr Find(string fileName)
    {
        return Databases[fileName];
    }
}

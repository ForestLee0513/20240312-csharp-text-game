using SDL2;

class Input
{
    public static Dictionary<string, KeyList> inputMap = new Dictionary<string, KeyList>();

    public struct KeyList {
        public SDL.SDL_Keycode key;
        public SDL.SDL_Keycode altKey;
        
        public KeyList(SDL.SDL_Keycode newKey, SDL.SDL_Keycode newAltKey) {
            key = newKey;
            altKey = newAltKey;
        }
    }

    public static void Init()
    {
        // editor 설정
        inputMap = new Dictionary<string, KeyList>()
        {
            { "Up", new KeyList(SDL.SDL_Keycode.SDLK_w, SDL.SDL_Keycode.SDLK_UP) },
            { "Down", new KeyList(SDL.SDL_Keycode.SDLK_s, SDL.SDL_Keycode.SDLK_DOWN) },
            { "Left", new KeyList(SDL.SDL_Keycode.SDLK_a, SDL.SDL_Keycode.SDLK_LEFT) },
            { "Right", new KeyList(SDL.SDL_Keycode.SDLK_d, SDL.SDL_Keycode.SDLK_RIGHT) },
            { "Exit", new KeyList(SDL.SDL_Keycode.SDLK_ESCAPE, SDL.SDL_Keycode.SDLK_q) }
        };
    }

    public static bool GetKey(SDL.SDL_Keycode checkKeyCode)
    {
        return Engine.GetInstance().myEvent.key.keysym.sym == checkKeyCode;
    }

    public static bool GetButton(string buttonName)
    {
        return inputMap[buttonName].key == Engine.GetInstance().myEvent.key.keysym.sym || inputMap[buttonName].altKey == Engine.GetInstance().myEvent.key.keysym.sym;
    }

    public Input()
    {

    }

    ~Input()
    {

    }
}

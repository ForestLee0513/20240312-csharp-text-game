class Input
{
    public static ConsoleKeyInfo keyInfo;
    public static Dictionary<string, KeyList> inputMap = new Dictionary<string, KeyList>();

    public struct KeyList {
        public ConsoleKey key;
        public ConsoleKey altKey;
        
        public KeyList(ConsoleKey newKey, ConsoleKey newAltKey) {
            key = newKey;
            altKey = newAltKey;
        }
    }

    public static void Init()
    {
        // editor 설정
        inputMap = new Dictionary<string, KeyList>()
        {
            { "Up", new KeyList(ConsoleKey.W, ConsoleKey.UpArrow) },
            { "Down", new KeyList(ConsoleKey.S, ConsoleKey.DownArrow) },
            { "Left", new KeyList(ConsoleKey.A, ConsoleKey.LeftArrow) },
            { "Right", new KeyList(ConsoleKey.D, ConsoleKey.RightArrow) },
        };
    }

    public static bool GetKey(ConsoleKey checkKeyCode)
    {
        return keyInfo.Key == checkKeyCode; 
    }

    public static bool GetButton(string buttonName)
    {
        return inputMap[buttonName].key == keyInfo.Key || inputMap[buttonName].altKey == keyInfo.Key;
    }

    public Input()
    {

    }

    ~Input()
    {

    }
}

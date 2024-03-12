class Input
{
    public static ConsoleKeyInfo keyInfo;
    public static Dictionary<string, ConsoleKey[]> inputMap = new Dictionary<string, ConsoleKey[]>();

    public static void Init()
    {
        // editor 설정
        inputMap["Up"] = [ConsoleKey.W, ConsoleKey.UpArrow];
        inputMap["Down"] = [ConsoleKey.S, ConsoleKey.DownArrow];
        inputMap["Left"] = [ConsoleKey.A, ConsoleKey.LeftArrow];
        inputMap["Right"] = [ConsoleKey.D, ConsoleKey.RightArrow];
    }

    public static bool GetKey(ConsoleKey checkKeyCode)
    {
        return keyInfo.Key == checkKeyCode; 
    }

    public static bool GetButton(string buttonName)
    {
        return inputMap[buttonName].Contains(keyInfo.Key);
    }

    public Input()
    {

    }

    ~Input()
    {

    }
}

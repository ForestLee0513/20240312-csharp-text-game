using System.Data;

internal class Engine
{
    public List<GameObject> gameObjects;
    public bool isRunning;
    public Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }

    public void Init()
    {

        string[] map = new string[10];
        map[0] = "**********";
        map[1] = "*P       *";
        map[2] = "*        *";
        map[3] = "*        *";
        map[4] = "*   M    *";
        map[5] = "*        *";
        map[6] = "*        *";
        map[7] = "*        *";
        map[8] = "*       G*";
        map[9] = "**********";

        for (int y = 0; y < 10; ++y)
        {
            for(int x = 0; x < 10; ++x)
            {
                if(map[y][x] == '*')
                {
                    Instantiate(new Wall(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    Instantiate(new Player(x, y));
                }
                else if (map[y][x] == 'M')
                {
                    Instantiate(new Monster(x, y));
                }
                else if (map[y][x] == 'G')
                {
                    Instantiate(new Goal(x, y));
                }
                else if (map[y][x] == ' ')
                {
                    Instantiate(new Floor(x, y));
                }
            }
        }
        //Load();
    }

    public void Run()
    {
        while(isRunning)
        {
            Input();
            Update();
            Render();
        } // frame
    }


    public void Term()
    {
        gameObjects.Clear();
    }

    //public GameObject Instanticate<T>() where T : GameObject
    //{
    //    return new T();
    //}

    public GameObject Instantiate(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);
        return newGameObject;
    }

    protected void Input()
    {
        Console.ReadKey();
    }

    protected void Update()
    {

    }

    protected void Render()
    {
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.Render();
        }
    }
}
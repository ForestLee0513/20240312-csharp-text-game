using System.Data;
using System.Runtime.Intrinsics.Arm;

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
        Input.Init();
    }


    public void LoadScene(string sceneName)
    {
#if DEBUG
        string dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
        string[] map = File.ReadAllLines(dir + "/../data/" + sceneName + ".map");
#else
#endif
        // 1
        //string dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.FullName;
        //string[] map = File.ReadAllLines(dir + "/../data/level1.map");
        // 2
        //string[] map = File.ReadAllLines("./data/level1.map");
        // 3
        //string[] map = File.ReadAllLines("../../../data/" + sceneName + ".map");


        for (int y = 0; y < map.Length; ++y)
        {
            for (int x = 0; x < map[y].Length; ++x)
            {
                if (map[y][x] == '*')
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

        // 레이어 순서에 따른 정렬
        gameObjects.Sort();
        //gameObjects = gameObjects.OrderBy(gameObject => gameObject.layer).ToList();
    }

    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
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

    protected void ProcessInput()
    {
        Input.keyInfo = Console.ReadKey();
    }

    protected void Update()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Update();
        }
    }

    protected void Render()
    {
        Console.Clear();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Render();
        }
    }
}
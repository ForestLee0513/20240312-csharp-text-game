using System.ComponentModel;
using System.Data;
using System.Runtime.Intrinsics.Arm;

internal class Engine
{
    public List<GameObject> gameObjects;
    public bool isRunning;

    protected Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }

    static private Engine? instance;
    static public Engine GetInstance()
    {
        if (instance == null)
        {
            instance = new Engine();
        }

        return instance;
    }


    public void Init()
    {
        Input.Init();
    }

    public void Stop()
    {
        isRunning = false;
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
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    SpriteRenderer? renderer = newGameObject.GetComponent<SpriteRenderer>();
                    if(renderer != null)
                    {
                        renderer.shape = '*';
                    }
                }
                else if (map[y][x] == 'P')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Player";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    SpriteRenderer? renderer = newGameObject.GetComponent<SpriteRenderer>();
                    if (renderer != null)
                    {
                        renderer.shape = 'P';
                    }
                    newGameObject.AddComponent<PlayerController>();
                }
                else if (map[y][x] == 'M')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    SpriteRenderer? renderer = newGameObject.GetComponent<SpriteRenderer>();
                    if (renderer != null)
                    {
                        renderer.shape = 'M';
                    }
                }
                else if (map[y][x] == 'G')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    SpriteRenderer? renderer = newGameObject.GetComponent<SpriteRenderer>();
                    if (renderer != null)
                    {
                        renderer.shape = 'G';
                    }
                }
                else if (map[y][x] == ' ')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    //newGameObject.AddComponent<SpriteRenderer>();
                    //newGameObject.GetComponent<SpriteRenderer>().shape = ' ';
                }
            }
        }

        // 레이어 순서에 따른 정렬
        //gameObjects.Sort();
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
        foreach (GameObject gameObjects in gameObjects)
        {
            foreach (Component component in gameObjects.components)
            {
                component.Update();
            }
        }
    }

    protected void Render()
    {
        Console.Clear();
        foreach (GameObject gameObject in gameObjects)
        {
            Renderer? renderer = gameObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.Render();
            }
        }
    }
}
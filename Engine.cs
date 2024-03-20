using System.ComponentModel;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

internal class Engine
{
    public List<GameObject> gameObjects;
    public bool isRunning;
    public bool isNextLoading = false;
    public string nextSceneName = string.Empty;

    public void NextLoadScene(string _nextSceneName)
    {
        isNextLoading = true;
        nextSceneName = _nextSceneName;
    }

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
        string[] map = File.ReadAllLines(dir + "/../data/" + sceneName);
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
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.shape = '*';
                    renderer.renderOrder = RenderOrder.Wall;
                    newGameObject.AddComponent<Collider2D>();
                }
                else if (map[y][x] == 'P')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Player";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.shape = 'P';
                    renderer.renderOrder = RenderOrder.Player;
                    
                    newGameObject.AddComponent<PlayerController>();
                    newGameObject.AddComponent<Collider2D>();
                }
                else if (map[y][x] == 'M')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.shape = 'M';
                    renderer.renderOrder = RenderOrder.Monster;
                    Collider2D collider = newGameObject.AddComponent<Collider2D>();
                    collider.isTrigger = true;

                }
                else if (map[y][x] == 'G')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.shape = 'G';
                    renderer.renderOrder = RenderOrder.Goal;
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;
                }
                else if (map[y][x] == ' ')
                {
                    GameObject newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.shape = ' ';
                    renderer.renderOrder = RenderOrder.Floor;
                }
            }
        }

        GameObject GameManagerObject = Instantiate<GameObject>();
        GameManagerObject.name = "GameManager";
        GameManagerObject.AddComponent<GameManager>();

        // 레이어 순서에 따른 정렬
        //gameObjects.Sort();
        //gameObjects = gameObjects.OrderBy(gameObject => gameObject.layer).ToList();
        RenderSort();
    }

    void RenderSort()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            for (int j = i + 1;  j < gameObjects.Count; j++)
            {
                SpriteRenderer? prevSpriteRenderer = gameObjects[i].GetComponent<SpriteRenderer>();
                SpriteRenderer? nextSpriteRenderer = gameObjects[j].GetComponent<SpriteRenderer>();

                if(prevSpriteRenderer != null && nextSpriteRenderer != null)
                {
                    if ((int)prevSpriteRenderer.renderOrder > (int)nextSpriteRenderer.renderOrder)
                    {
                        GameObject tempGameObject = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = tempGameObject;
                    }
                }
            }
        }
    }

    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
            if (isNextLoading)
            {
                gameObjects.Clear();
                LoadScene(nextSceneName);
                isNextLoading = false;
                nextSceneName = string.Empty;
            }
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

    public GameObject Instantiate<T>() where T : GameObject, new()
    {
        T newObject = new T();
        gameObjects.Add(newObject);

        return newObject;
    }

    protected void ProcessInput()
    {
        Input.keyInfo = Console.ReadKey();
    }

    public GameObject? Find(string name)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if(gameObject.name == name)
            {
                return gameObject;
            }
        }

        return null;
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
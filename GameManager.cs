class GameManager: Component
{
    public bool isGameOver;
    public bool isNextLevel;

    protected Timer gameOverTimer;
    protected Timer completeTimer;

    public GameManager()
    {
        isGameOver = false;
        isNextLevel = false;
        gameOverTimer = new Timer();
        gameOverTimer.SetTimer(3000, ProcessGameOver);
        completeTimer = new Timer();
        completeTimer.SetTimer(2000, ProcessComplete);
    }

    public void ProcessGameOver()
    {
        Engine.GetInstance().Stop();
        Console.Clear();
        Console.WriteLine("Game Over");
    }

    public void ProcessComplete()
    {
        Console.Clear();
        Console.WriteLine("Congraturation.");
        Engine.GetInstance().NextLoadScene("level2.map");
    }

    public override void Update()
    {
        if(isGameOver)
        {
            gameOverTimer.Update();
        }
        if (isNextLevel)
        {
            completeTimer.Update();
        }
    }
}

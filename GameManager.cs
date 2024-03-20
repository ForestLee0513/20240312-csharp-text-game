class GameManager: Component
{
    public bool isGameOver = false;
    public bool isNextLevel = false;
    public override void Update()
    {
        if(isGameOver)
        {
            Engine.GetInstance().Stop();
            Console.Clear();
            Console.WriteLine("Game Over");
        }
        if (isNextLevel)
        {
            Console.Clear();
            Console.WriteLine("Congraturation.");
            Console.ReadKey();
            Engine.GetInstance().NextLoadScene("level2.map");
        }
    }
}

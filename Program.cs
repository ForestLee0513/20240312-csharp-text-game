internal class Program
{
    static void Main(string[] args)
    {
        Engine engine = new Engine();

        engine.Init();
        engine.LoadScene("level2");
        engine.Run();
        //engine.Term();
    }
}

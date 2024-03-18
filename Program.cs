using System.ComponentModel;

public class Parent
{
    public virtual void Pay()
    {
        Console.WriteLine("대신 지불한다.");
    }
}

public class Child1: Parent
{
    public override void Pay()
    {
        base.Pay();
        Console.WriteLine("지불한다.");
    }
}

public class Child2: Parent
{
    public void Run()
    {
        Console.WriteLine("도망간다");
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        //List<Parent> lists = new List<Parent>();

        //lists.Add(new Parent());
        //lists.Add(new Child1());
        //lists.Add(new Child2());

        //for(int i = 0; i < lists.Count; i++)
        //{
        //    Child2 child2 = lists[i] as Child2;

        //    if(child2 != null)
        //    {
        //        child2.Run();
        //    }

        //    //if (lists[i].GetType() == typeof(Child2))
        //    //{
        //    //    ((Child2)lists[i]).Run();
        //    //}
        //}

        Engine engine = Engine.GetInstance();

        engine.Init();
        engine.LoadScene("level2");
        engine.Run();

        //engine.Term();
    }
}

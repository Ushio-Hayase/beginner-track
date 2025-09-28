public abstract class Parent
{
    protected string _name;

    public abstract void Method();
}


public class Child1 : Parent
{
    private string id_;

    protected int x { get; set; }

    public Child1()
    {
        id_ = "ds";
        base._name = "112";
    }

    ~Child1()
    {

    }


    public sealed override void Method()
    {
        Console.WriteLine("1");
    }

    public virtual void Method2()
    {
    }

    public class Child1_1
    {
        public int y { get; set; }
    }
}

public class Child2 : Parent
{

    public Child2()
    {
        base._name = "112";
    }

    ~Child2()
    {

    }


    public override void Method()
    {
        Console.WriteLine("2");
    }
}


public class Test
{

    public static int Main(string[] args)
    {
        Parent p = new Child1();

        p.Method();

        p = new Child2();

        p.Method();

        return 0;
    }
}

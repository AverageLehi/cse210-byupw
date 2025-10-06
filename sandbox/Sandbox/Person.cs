public class Person
{
    protected string _name;

    public Person(string name)
    {
        _name = name;
    }
    
    public string GetName()
    {
        return _name;
    }
}
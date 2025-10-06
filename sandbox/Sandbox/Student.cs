public class Student : Person
{
    private string _number;

    // calling the parent constructor using "base"!
    public Student(string name, string number) : base(name)
    {
      _number = number;
    }

    public string GetNumber()
    {
        return _number;
    }
    
    //
    //string name = base.GetName();
    //Console.WriteLine($"Student name : {name}")
}
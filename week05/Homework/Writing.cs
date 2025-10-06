public class Writing : Assignment
{
    private string _title;
    public Writing(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }
    public string GetWritingInformation()
    {
        string topic = base.GetTopic();
        return $"{topic}\n{_title}";
    }
}
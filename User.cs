public class User
{
    public string Name { get; set; }
    public string Id { get; set; }

    public User(string name, string id = "")
    {
        Name = name;
        Id = id;
    }
}
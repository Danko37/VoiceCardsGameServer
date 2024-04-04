public class UsersService
{
    private List<User> _users = new List<User>();

    public void SetUer(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}
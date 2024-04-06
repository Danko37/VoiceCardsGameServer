using System.Net;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

public class UsersService
{
    /// <summary>
    /// todo логика связанная с инициализацией и действием с firebase перенести в отдельный сервис
    /// </summary>
    IFirebaseConfig _config = new FirebaseConfig
    {
        AuthSecret= "j3qUnOdTTE37MtXVdp3He0DpZ8EvJbtp95cw2Mlo", 
        BasePath = "https://cardsvoice-43e41-default-rtdb.europe-west1.firebasedatabase.app"
    };
    IFirebaseClient _client;

    public UsersService()
    {
        _client = new FireSharp.FirebaseClient(_config);
    }

    public bool CreateUser(User user)
    {
        PushResponse response = _client.Push("Users/", user);
        user.Id = response.Result.name;
        SetResponse setResponse = _client.Set($"Users/{user.Id}", user);

        return setResponse.StatusCode == HttpStatusCode.OK;
    }

    /*public List<User> GetAllUsers()
    {

    }

    public User GetUser(string uniqueId)
    {

    }*/
}
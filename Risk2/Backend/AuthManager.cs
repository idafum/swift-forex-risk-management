using System.Diagnostics;
using Risk2.Data.Models;
using Risk2.Data.Repositories;

namespace Risk2.Backend;

public class AuthManager
{
    private readonly UserRepository _userRepo;

    public AuthManager(UserRepository userRepo) //Inserted Using DI
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// Login Handler
    /// verify Info from the database for login and reply to the request
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<User?> HandleLoginRequest(string username, string password)
    {
        User? user = await _userRepo.GetUserByCredentialsAsync(username, password);

        //Logging: Maybe log the time a user logged in..
        if (user == null)
        {
            Debug.WriteLine($"[In Account Manager]: User{username} does not exist");
        }
        return user;
    }
}
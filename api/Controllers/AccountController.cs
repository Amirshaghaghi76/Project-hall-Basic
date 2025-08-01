using System.Linq.Expressions;
using api.Models;
using api.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;

    public AccountController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        // Use 'client' (MongoDB Client) to get the database with the name defined in settings (appsettings.json), and assign it to the 'database' variable

        _collection = database.GetCollection<AppUser>(_collectionName);
        // Get the "users" collection from the database, typed to AppUser, and assign it to _collection
    }
    [HttpPost("register")]
    // public async Task<ActionResult<AppUser>> Create(AppUser userInput){}
    public async Task<ActionResult<AppUser>> Create(AppUser userInput, CancellationToken cancellationToken)
    {
        try
        {
            //create a CancellationTokenSource to limit operation time to 10 seconds.
            // use 'Using var'for automatic disposal of resourse after use.
            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            //combine user cancelleationtoken and timeout token, creating a new cancellationtoken
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCts.Token);

            if (userInput.Password != userInput.ConfrimPassword)
                BadRequest("Password dont match!");

            bool doesexist = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()).AnyAsync(linkedCts.Token);
            //check if Email/Username is Taken
            //use cancellation token herew to respect timeout or cancel

            if (doesexist)
                return BadRequest("Email/Username is Taken.");

            //if user/email does not exist, create a new AppUser.
            AppUser appUser = new(
                Id: null,
                Name: userInput.Name,
                Email: userInput.Email.ToLower().Trim(),
                Password: userInput.Password,
                ConfrimPassword: userInput.ConfrimPassword
            );

            // insert user into database if collection is valid
            if (_collection is not null)
            {
                // _collection.InsertOne(appUser, null, cancellationToken);
                // await _collection.InsertOneAsync(appUser, null, timeoutCts.Token);
                await _collection.InsertOneAsync(appUser, null, linkedCts.Token);
            }

            // await Task.Delay(15000, linkedCts.Token); test to error 408

            return appUser;
        }

        catch (OperationCanceledException)
        {
            return StatusCode(408, "Your connection was too slow. Pelese check your internet and try again");
        }
    }
}


using api.Models;
using api.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMongoCollection<AppUser> _collection;
    // Dependency Injection
    public UserController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<AppUser>("users");
    }
    [HttpPost("register")]
    public ActionResult<AppUser> Create(AppUser userInput)
    {
        AppUser user = _collection.Find(user => user.Email == userInput.Email.ToLower()).FirstOrDefault();

        if (user == null)
        {
            user = new AppUser(
       Id: null,
       Name: userInput.Name.Trim(),
       PassWord: userInput.PassWord.Trim(),
       ConfrimPassword: userInput.ConfrimPassword.Trim(),
       Email: userInput.Email.ToLower().Trim(),
       Age: userInput.Age
              );

            _collection.InsertOne(user);

            return user;
        }

        return BadRequest("This Email is already registered");
    }

    [HttpGet("get-by-email/{emailInput}")]
    public ActionResult<AppUser> GetBYEmail(string emailInput)
    {
        AppUser user = _collection.Find<AppUser>(doc => doc.Email == emailInput).FirstOrDefault();

        if (user is null)
        {
            return NotFound("No user with this email exist.");
        }

        return user;
    }

    [HttpGet]
    public ActionResult<List<AppUser>> GetAll()
    {
        List<AppUser> users = _collection.Find<AppUser>(new BsonDocument()).ToList();
        if (!users.Any())
        {
            return NoContent();
        }
        return users;
    }

    [HttpPut("update/{userId}")]
    public ActionResult<UpdateResult> UpdateUser(string userId, AppUser userIn)
    {
        var UpdateUser = Builders<AppUser>.Update
        .Set((AppUser doc) => doc.Name, userIn.Name.ToLower())
        .Set((AppUser doc) => doc.PassWord, userIn.PassWord)
        .Set((AppUser doc) => doc.ConfrimPassword, userIn.ConfrimPassword)
        .Set((AppUser doc) => doc.Age, userIn.Age);

        return _collection.UpdateOne<AppUser>(doc => doc.Id == userId, UpdateUser);
    }

    [HttpDelete("delete/{userId}")]
    public ActionResult<DeleteResult> Delete(string userId)
    {
        return _collection.DeleteOne<AppUser>(doc => doc.Id == userId);
    }
}

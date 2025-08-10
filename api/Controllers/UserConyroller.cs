using MongoDB.Bson;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private const string _collectionName = "users";
    private readonly IMongoCollection<AppUser>? _collection;

    public UserController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        // Use 'client' (MongoDB Client) to get the database with the name defined in settings (appsettings.json), and assign it to the 'database' variable

        _collection = database.GetCollection<AppUser>(_collectionName);
        // Get the "users" collection from the database, typed to AppUser, and assign it to _collection
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetAll(CancellationToken cancellationToken)
    {

        List<AppUser> appUsers = await _collection.Find<AppUser>(new BsonDocument()).ToListAsync(cancellationToken);

        if (appUsers.Count == 0)
            return NoContent();

        return appUsers;
    }

    [HttpGet("get-by-id/{userId}")]
    public async Task<ActionResult<AppUser>> GetById(string userId, CancellationToken cancellationToken)
    {
        AppUser appUser = await _collection.Find<AppUser>(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (appUser is null)
            return NotFound();

        return appUser;
    }
}
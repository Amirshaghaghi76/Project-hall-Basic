
namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdviceController : ControllerBase
{
    private readonly IMongoCollection<Advice> _collection;
    public AdviceController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Advice>("consultations");
    }
    [HttpPost("register")]
    public ActionResult<Advice> Create(Advice userInput)
    {
        Advice advice = new Advice(
            Id: null,
             PhoneNumber: userInput.PhoneNumber
        );

        _collection.InsertOne(advice);

        return advice;
    }

    [HttpGet("get-by-phone/{phone}")]
    public ActionResult<Advice> Get(string phone)
    {
        Advice advice = _collection.Find(advice =>
        advice.PhoneNumber == phone).FirstOrDefault();

        if (advice == null)
        {
            return NotFound("There is no Such phone number");
        }

        return advice;
    }

    [HttpGet]
    public ActionResult<List<Advice>> GetAll()
    {
        List<Advice> advices = _collection.Find<Advice>(new BsonDocument()).ToList();

        if (!advices.Any())
        {
            return Ok("The list is empty.");
        }

        return advices;
    }

}


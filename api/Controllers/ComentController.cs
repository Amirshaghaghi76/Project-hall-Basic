using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api.Models;

[ApiController]
[Route("api/[controller]")]
public class ComentController : ControllerBase
{
    private readonly IMongoCollection<Coment> _collection;
    public ComentController(IMongoClient client, IMongoDbSettings dbSettings)
    {
        var dbName = client.GetDatabase(dbSettings.DatabaseName);
        _collection = dbName.GetCollection<Coment>("consultations");
    }

    [HttpPost("register")]

    public ActionResult<Coment> Create(Coment userInput)
    {
        Coment coment = new Coment(
    Name: userInput.Name,
    PhoneNumber: userInput.PhoneNumber,
    Opinion: userInput.Opinion

        );
        _collection.InsertOne(coment);

        return coment;
    }
}

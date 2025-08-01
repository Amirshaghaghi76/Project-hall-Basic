using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record AppUser
(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
     string Name,
     string Email,
     string Password,
     string ConfrimPassword
);


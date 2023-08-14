using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Advice
(
[property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
 [MinLength(11), MaxLength(11)] string PhoneNumber
);

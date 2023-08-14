using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record Hall
(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
     [MinLength(3), MaxLength(9)] string Name,
     [MinLength(3), MaxLength(8)] string City,
     [MinLength(4), MaxLength(10)] string PriceLevel,
     [Range(50, 2000)] int Capacity,
     string PhoneNumber,
     bool Parking,
     bool WeddingRoom,
     bool FreeWifi,
     bool Cofe,
     bool Elevator
     // bool Lighting
    );

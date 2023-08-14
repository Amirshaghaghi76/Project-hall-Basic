using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record AppUser
(
    [property:BsonId, BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] string?Id,
    [MinLength(3), MaxLength(10)] string Name,
    [MinLength(6), MaxLength(15)] string PassWord,
    [MinLength(6), MaxLength(15)] string ConfrimPassword,
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage = "Bad Email Format.")] string Email,
    [Range(18, 99)] int Age
);

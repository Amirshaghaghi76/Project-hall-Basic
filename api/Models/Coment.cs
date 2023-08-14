using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models;

public record Coment
(
    [MinLength(3),MaxLength(8)] string Name,
    [MinLength(11),MaxLength(11)] string PhoneNumber,
    [MinLength(3), MaxLength(60)] string Opinion
);

namespace api.Dtos;

public record RegisterDto
(
     [Length(3, 10)] string Name,
     [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
     [DataType(DataType.Password),Length(5,10)] string Password,
     [DataType(DataType.Password), Length(5, 10)] string ConfrimPassword
);

public record LoginDto(
    string Email,
    string Password
);


namespace DTOs
{
    public record UserDTO
        (
            int UserId,
            string UserName,
            string Password,
            string FirstName,
            string LastName
        );
}

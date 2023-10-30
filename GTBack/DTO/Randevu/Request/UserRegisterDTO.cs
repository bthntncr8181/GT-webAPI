namespace GTBack.Core.DTO;

public class UserRegisterDTO:BaseRegisterDTO
{

    public int UserTypeId { get; set; }
    public int CompanyId { get; set; }
    public string Password { get; set; }
}
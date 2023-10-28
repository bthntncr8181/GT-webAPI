namespace GTBack.Core.DTO;

public class UserRegisterDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int UserTypeId { get; set; }
    public string Mail { get; set; }
    public int CompanyId { get; set; }
    public bool isDeleted { get; set; }
    public string Password { get; set; }
}
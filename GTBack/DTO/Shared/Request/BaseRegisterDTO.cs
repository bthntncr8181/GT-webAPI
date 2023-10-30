namespace GTBack.Core.DTO;

public class BaseRegisterDTO
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public int? UserTypeId { get; set; }
    
}
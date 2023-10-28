namespace GTBack.Core.DTO.Restourant.Request;

public class ClientRegisterRequestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public bool IsDeleted { get; set; }
    public string Password { get; set; }
}
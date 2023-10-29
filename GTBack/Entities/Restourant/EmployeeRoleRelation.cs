namespace GTBack.Core.Entities.Restourant;

public class EmployeeRoleRelation:BaseEntity
{
    public int EmployeeId { get; set; }
    public string RoleId { get; set; }
    public Employee Employee { get; set; }
    public Role Role { get; set; }
    

}
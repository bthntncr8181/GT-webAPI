namespace GTBack.Core.Entities.Restourant;

public class EmployeeOrderRelation:BaseEntity
{
    public  int EmployeeId { get; set; }
    public  int AdditionId { get; set; }
    public  Employee Employee { get; set; }
    public  Addition Addition { get; set; }

}
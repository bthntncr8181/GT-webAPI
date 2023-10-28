namespace GTBack.Core.Entities.Restourant;

public class EmployeeAdditionRelation:BaseEntity
{
    
    
    public  int EmployeeId { get; set; }
    public  int Additionıd { get; set; }
    public  Employee Employee { get; set; }
    public  Addition Addition { get; set; }

}
namespace GTBack.Core.Entities.Restourant;

public class ShiftControl:BaseEntity
{
    public DateTime EnterDate { get; set; }
    public DateTime LeaveDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

}
namespace GTBack.Core.Entities.Restourant;

public class Reservation:BaseEntity
{       
    public DateTime ReservationDateTime { get; set; }
    public DateTime ReservationCancelDate { get; set; }
    public int? Deposit { get; set; }
    public int UserId { get; set; }
    public int? TableId { get; set; }
    public int EmployeeId { get; set; }
    public User User { get; set; }
    public Employee Employee { get; set; }
    public Table? Table { get; set; }


    
}
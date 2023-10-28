namespace GTBack.Core.Entities.Restourant;

public class Addition:BaseEntity
{
    public String Name { get; set; }
    public int TableNumber { get; set; }
    public int ActiveId { get; set; }
    public int Capacity { get; set; }
    public int TableId { get; set; }
    public int? UserId { get; set; }
    public Table Table { get; set; }
    public User? User { get; set; }
    public  virtual  TableArea TableArea { get; set; }
    public  virtual  ICollection<Order>? Order { get; set; }
    public  virtual  ICollection<Payment>? Payment { get; set; }
    
}
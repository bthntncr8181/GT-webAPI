namespace GTBack.Core.Entities.Restourant;

public class Table:BaseEntity
{
    public String Name { get; set; }
    public int TableNumber { get; set; }
    public int ActiveId { get; set; }
    public int Capacity { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public  virtual  TableArea TableArea { get; set; }
    public  virtual  ICollection<Reservation>? Reservation { get; set; }
    public  virtual  ICollection<Addition>? Addition { get; set; }
    
}
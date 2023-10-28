namespace GTBack.Core.Entities.Restourant;

public class Company :BaseEntity
{
    public String Name { get; set; }
    public String Address { get; set; }
    public String Mail { get; set; }
    public String Phone { get; set; }
    public float Lat { get; set; }
    public float Lng { get; set; }
    public int MenuId { get; set; }
    public  Menu Menu { get; set; }
    public  virtual  ICollection<Department> Department { get; set; }
    public  virtual  ICollection<TableArea> TableArea { get; set; }
}
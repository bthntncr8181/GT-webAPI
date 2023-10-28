namespace GTBack.Core.Entities.Restourant;

public class MenuItem:BaseEntity
{
    public String Name { get; set; }
    public int CompanyId { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public String Image { get; set; }
    public String Description { get; set; }
    public String Contains { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public  virtual  ICollection<ExtraMenuItem> ExtraMenuItem { get; set; }
}
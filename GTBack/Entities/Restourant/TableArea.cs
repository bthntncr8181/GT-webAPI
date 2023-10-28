namespace GTBack.Core.Entities.Restourant;

public class TableArea:BaseEntity
{
    public String Name { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public  virtual  ICollection<Table>? Table { get; set; }
}
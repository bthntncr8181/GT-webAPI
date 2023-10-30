namespace GTBack.Core.Entities.Restourant;

public class TableArea:BaseEntity
{
    public String Name { get; set; }
    public long CompanyId { get; set; }
    public RestoCompany RestoCompany { get; set; }
    public  virtual  ICollection<Table>? Table { get; set; }
}
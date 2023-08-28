namespace GTBack.Core.Entities;

public class EventTypeCompanyRelation:BaseEntity
{
 
    public int EventId { get; set; }
    public int CompanyId { get; set; }
    public virtual Event Event{ get; set; }
    public virtual Company Company { get; set; }


}
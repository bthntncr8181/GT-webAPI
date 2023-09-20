namespace GTBack.Core.Entities;

public class EventTypeCompanyRelation:BaseEntity
{
 
    public int EventTypeId { get; set; }
    public int CompanyId { get; set; }
    public virtual EventType EventType{ get; set; }
    public virtual Company Company { get; set; }


}
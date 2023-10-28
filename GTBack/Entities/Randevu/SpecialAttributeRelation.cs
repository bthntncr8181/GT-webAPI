namespace GTBack.Core.Entities;

public class SpecialAttributeRelation:BaseEntity
{
    public int AdminUserId { get; set; }
    public int ClientUserId { get; set; }
    
    public virtual User AdminUser { get; set; }

    
    public virtual User ClientUser { get; set; }
    
    public int SpecialAttributeId { get; set; }

}
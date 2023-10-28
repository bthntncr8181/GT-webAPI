namespace GTBack.Core.Entities.Restourant;

public class Order:BaseEntity
{
    public String Name { get; set; }
    public String OrderNote { get; set; }
    public int? ExtraMenuItemId { get; set; }
    public int AdditionId { get; set; }
    public int OrderStatus { get; set; }
    public int OrderStartDate { get; set; }
    public int OrderDeliveredDate { get; set; }
    public ExtraMenuItem? ExtraMenuItem { get; set; }
    public Employee? Employee { get; set; }
    public Addition Addition { get; set; }
} 
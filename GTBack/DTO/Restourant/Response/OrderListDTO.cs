namespace GTBack.Core.DTO.Restourant.Response;

public class OrderListDTO
{
    public long Id { get; set; }
    public String Name { get; set; }
    public String OrderNote { get; set; }
    public long? ExtraMenuItemId { get; set; }
    public long AdditionId { get; set; }
    public long EmployeeId { get; set; }
    public int OrderStatus { get; set; }
    public DateTime OrderStartDate { get; set; }
    public DateTime OrderDeliveredDate { get; set; }
}
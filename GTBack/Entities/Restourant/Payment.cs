namespace GTBack.Core.Entities.Restourant;

public class Payment:BaseEntity
{
    public  int AdditionId { get; set; }
    public  int AmountPaid { get; set; }
    public  int PaymentMethod { get; set; }
    public  DateTime PaymentDate { get; set; }
    public  Addition Addition { get; set; }
    
}
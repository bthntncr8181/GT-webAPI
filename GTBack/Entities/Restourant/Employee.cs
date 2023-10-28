namespace GTBack.Core.Entities.Restourant;

public class Employee
{
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Address { get; set; }
    public String Mail { get; set; }
    public String Phone { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
    public int Salary { get; set; }
    public int DeviceId { get; set; }
    public int DepartmentId { get; set; }
    public int CurrencyId { get; set; }
    public  Department Department { get; set; }
    public  Currency Currency { get; set; }
    public  Device Device { get; set; }
    public  virtual  ICollection<Table> Table { get; set; }
    public  virtual  ICollection<Addition> Addition { get; set; }
    public  virtual  ICollection<Reservation> Reservation { get; set; }
    public  virtual  ICollection<ShiftControl> ShiftControl { get; set; }
}
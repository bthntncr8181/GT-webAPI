namespace GTBack.Core.DTO.Restourant.Request;

public class EmployeeRegisterDTO:BaseDTO
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Surname { get; set; }
    public String Address { get; set; }
    public String Mail { get; set; }
    public String Phone { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
    public int SalaryType { get; set; }
    public int Salary { get; set; }
    public int? DeviceId { get; set; }
    public int DepartmentId { get; set; }
    public int CurrencyId { get; set; }
}


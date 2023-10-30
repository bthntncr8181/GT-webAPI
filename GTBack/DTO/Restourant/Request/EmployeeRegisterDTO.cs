namespace GTBack.Core.DTO.Restourant.Request;

public class EmployeeRegisterDTO:BaseRegisterDTO
{

    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }
    public int SalaryType { get; set; }
    public int Salary { get; set; }
    public int? DeviceId { get; set; }
    public int DepartmentId { get; set; }
    public int CurrencyId { get; set; }
}


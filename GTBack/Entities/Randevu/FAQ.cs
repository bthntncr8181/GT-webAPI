

using System.ComponentModel.DataAnnotations.Schema;

namespace GTBack.Core.Entities;

public class FAQ:BaseEntity
{
    public String Question { get; set; }
    public String Answer { get; set; }
    public int Like { get; set; }
    public int CompanyId { get; set; }
    
    public int SenderUserId { get; set; }
    public int? AnsweredUserId { get; set; }
    public  User SenderUser { get; set; }
    public  User? AnsweredUser { get; set; }
    public  Company Company { get; set; }
    
}
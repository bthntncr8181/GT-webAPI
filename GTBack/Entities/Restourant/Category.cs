
namespace GTBack.Core.Entities.Restourant;

public class Category
{
    public String Name { get; set; }
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    public string Image { get; set; }
    public  virtual  ICollection<MenuItem>? MenuItem { get; set; }
}
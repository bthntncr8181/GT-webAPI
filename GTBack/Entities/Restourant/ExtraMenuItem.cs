namespace GTBack.Core.Entities.Restourant;

public class ExtraMenuItem
{
    public String Name { get; set; }
    public int CompanyId { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public String Description { get; set; }
    public String Contains { get; set; }
    public String Image { get; set; }
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}
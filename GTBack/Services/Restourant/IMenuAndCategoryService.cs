using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Results;

namespace GTBack.Core.Services.Restourant;

public interface IMenuAndCategoryService
{
    Task<IResults> MenuCreate(MenuCreateDTO model);
    Task<IResults> CategoryAdd(CategoryAddOrUpdateDTO model);
    Task<IResults> MenuItemAdd(MenuItemAddOrUpdateDTO model);
    Task<IResults> ExtraMenuItemAdd(ExtraMenuItemAddOrUpdateDTO model);
    Task<IResults> MenuDelete(int id);
    Task<IResults> CategoryDelete(int id);
    Task<IResults> MenuItemDelete(int id);
    Task<IResults> ExtraMenuItemDelete(int id);
    Task<IDataResults<ICollection<CategoryListDTO>>> AllCategoryListByCompanyId();
    Task<IDataResults<ICollection<MenuItemListDTO>>> MenuItemListByCategoryId(int categoryId);
    Task<IDataResults<ICollection<ExtraMenuItemListDTO>>> ExtraMenuItemByMenuItemId(int menuItemId);
    Task<IDataResults<ICollection<MenuItemListDTO>>> AllMenuItemsByCompanyId();

}
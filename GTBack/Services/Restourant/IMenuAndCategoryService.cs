using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Results;

namespace GTBack.Core.Services.Restourant;

public interface IMenuAndCategoryService
{
    Task<IResults> MenuCreate(MenuCreateDTO model);
    Task<IResults> CategoryAdd(CategoryAddDTO model);
    Task<IResults> MenuItemAdd(MenuItemAddDTO model);
    Task<IResults> ExtraMenuItemAdd(ExtraMenuItemAddDTO model);

}
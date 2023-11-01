using System.Security.Claims;
using AutoMapper;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Entities.Restourant;
using GTBack.Core.Results;
using GTBack.Core.Services;
using GTBack.Core.Services.Restourant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GTBack.Service.Services.RestourantServices;

public class MenuAndCategoryService : IMenuAndCategoryService
{
    private readonly IService<Menu> _menuService;
    private readonly IService<MenuItem> _menuItemService;
    private readonly IService<Category> _categoryService;
    private readonly IService<ExtraMenuItem> _extraMenuItemService;
    private readonly ClaimsPrincipal? _loggedUser;
    private readonly IMapper _mapper;

    public MenuAndCategoryService(
        IHttpContextAccessor httpContextAccessor, IService<Menu> menuService, IService<MenuItem> menuItemService,
        IService<Category> categoryService, IService<ExtraMenuItem> extraMenuItemService,
        IMapper mapper)
    {
        _mapper = mapper;
        _menuService = menuService;
        _menuItemService = menuItemService;
        _categoryService = categoryService;
        _extraMenuItemService = extraMenuItemService;
        _loggedUser = httpContextAccessor.HttpContext?.User;
    }

    public async Task<IResults> MenuCreate(MenuCreateDTO model)
    {
        var response = _mapper.Map<Menu>(model);
        await _menuService.AddAsync(response);
        return new SuccessResult();
    }

    public async Task<IResults> CategoryAdd(CategoryAddOrUpdateDTO model)
    {
        if (model.Id != 0)
        {
            var response = _mapper.Map<Category>(model);
            await _categoryService.AddAsync(response);
            return new SuccessResult();
        }
        else
        {
            var response = _mapper.Map<Category>(model);
            await _categoryService.UpdateAsync(response);
            return new SuccessResult();
        }
    }

    public async Task<IResults> MenuItemAdd(MenuItemAddOrUpdateDTO model)
    {
        if (model.Id != 0)
        {
            var response = _mapper.Map<MenuItem>(model);
            await _menuItemService.AddAsync(response);
            return new SuccessResult();
        }
        else
        {
            var response = _mapper.Map<MenuItem>(model);
            await _menuItemService.UpdateAsync(response);
            return new SuccessResult();
        }
    }

    public async Task<IResults> ExtraMenuItemAdd(ExtraMenuItemAddOrUpdateDTO model)
    {
        if (model.Id != 0)
        {
            var response = _mapper.Map<ExtraMenuItem>(model);
            await _extraMenuItemService.AddAsync(response);
            return new SuccessResult();
        }
        else
        {
            var response = _mapper.Map<ExtraMenuItem>(model);
            await _extraMenuItemService.UpdateAsync(response);
            return new SuccessResult();
        }
    }

    public async Task<IResults> MenuDelete(int id)
    {
        var menu = await _menuService.Where(x => x.Id == id).FirstOrDefaultAsync();
        menu.IsDeleted = true;
        await _menuService.UpdateAsync(menu);
        return new SuccessResult();
    }

    public async Task<IResults> CategoryDelete(int id)
    {
        var category = await _categoryService.Where(x => x.Id == id).FirstOrDefaultAsync();
        category.IsDeleted = true;
        await _categoryService.UpdateAsync(category);
        return new SuccessResult();
    }

    public async Task<IResults> MenuItemDelete(int id)
    {
        var menu = await _menuItemService.Where(x => x.Id == id).FirstOrDefaultAsync();
        menu.IsDeleted = true;
        await _menuItemService.UpdateAsync(menu);
        return new SuccessResult();
    }

    public async Task<IResults> ExtraMenuItemDelete(int id)
    {
        var menu = await _extraMenuItemService.Where(x => x.Id == id).FirstOrDefaultAsync();
        menu.IsDeleted = true;
        await _extraMenuItemService.UpdateAsync(menu);
        return new SuccessResult();
    }

    public int? GetLoggedCompanyId()
    {
        var userRoleString = _loggedUser.FindFirstValue("companyId");
        if (int.TryParse(userRoleString, out var userId))
        {
            return userId;
        }

        return null;
    }

    public async Task<IDataResults<ICollection<CategoryListDTO>>> AllCategoryListByCompanyId()
    {
        var companyId = GetLoggedCompanyId();
        var menu = await _menuService.Where(x => x.RestoCompanyId == companyId).FirstOrDefaultAsync();
        var categories = await _categoryService.Where(x => x.MenuId == menu.Id&&!x.IsDeleted).ToListAsync();
        
        var response = _mapper.Map<ICollection<CategoryListDTO>>(categories);
        return new SuccessDataResult<ICollection<CategoryListDTO>>(response);
    }
    

    public async Task<IDataResults<ICollection<MenuItemListDTO>>> MenuItemListByCategoryId(int categoryId)
    {
        var menuItems = await _menuItemService.Where(x => x.CategoryId == categoryId&&!x.IsDeleted).ToListAsync();
        var response = _mapper.Map<ICollection<MenuItemListDTO>>(menuItems);
        return new SuccessDataResult<ICollection<MenuItemListDTO>>(response);
    }

    public async Task<IDataResults<ICollection<ExtraMenuItemListDTO>>> ExtraMenuItemByMenuItemId(int menuItemId)
    {
        var menuItems = await _extraMenuItemService.Where(x => x.MenuItemId == menuItemId&&!x.IsDeleted).ToListAsync();
        var response = _mapper.Map<ICollection<ExtraMenuItemListDTO>>(menuItems);
        return new SuccessDataResult<ICollection<ExtraMenuItemListDTO>>(response);
    }

    public async Task<IDataResults<ICollection<MenuItemListDTO>>> AllMenuItemsByCompanyId()
    {
        List<MenuItem> menuItems = new List<MenuItem>();
        var companyId = GetLoggedCompanyId();
        var menu = await _menuService.Where(x => x.RestoCompanyId == companyId).FirstOrDefaultAsync();
        var categories = await _categoryService.Where(x => x.MenuId == menu.Id&&!x.IsDeleted).ToListAsync();
        
        foreach (var category in categories)
        {
            var menuItemsTemp = await _menuItemService.Where(x => x.CategoryId == category.Id&&!x.IsDeleted).ToListAsync();

            menuItems.AddRange(menuItemsTemp);
        }
        
        var response = _mapper.Map<ICollection<MenuItemListDTO>>(menuItems);
        return new SuccessDataResult<ICollection<MenuItemListDTO>>(response);
    }
}
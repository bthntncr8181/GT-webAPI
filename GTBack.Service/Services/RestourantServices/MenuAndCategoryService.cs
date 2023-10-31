using System.Security.Claims;
using AutoMapper;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Entities.Restourant;
using GTBack.Core.Results;
using GTBack.Core.Services;
using GTBack.Core.Services.Restourant;
using Microsoft.AspNetCore.Http;

namespace GTBack.Service.Services.RestourantServices;

public class MenuAndCategoryService:IMenuAndCategoryService
{
    
    
    private readonly IService<Menu> _menuService;
    private readonly IService<MenuItem> _menuItemService;
    private readonly IService<Category> _categoryService;
    private readonly IService<ExtraMenuItem> _extraMenuItemService;
    private readonly ClaimsPrincipal? _loggedUser;
    private readonly IMapper _mapper;

    public MenuAndCategoryService(
        IHttpContextAccessor httpContextAccessor, IService<Menu> menuService, IService<MenuItem> menuItemService, IService<Category> categoryService, IService<ExtraMenuItem> extraMenuItemService,
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

    public async Task<IResults> CategoryAdd(CategoryAddDTO model)
    {
        var response = _mapper.Map<Category>(model);
        await _categoryService.AddAsync(response);
        return new SuccessResult();
    }

    public async Task<IResults> MenuItemAdd(MenuItemAddDTO model)
    {
        var response = _mapper.Map<MenuItem>(model);
        await _menuItemService.AddAsync(response);
        return new SuccessResult();
    }

    public async Task<IResults> ExtraMenuItemAdd(ExtraMenuItemAddDTO model)
    {
        var response = _mapper.Map<ExtraMenuItem>(model);
        await _extraMenuItemService.AddAsync(response);
        return new SuccessResult();
    }
}
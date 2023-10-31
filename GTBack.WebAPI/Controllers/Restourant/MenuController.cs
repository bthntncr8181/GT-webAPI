using AutoMapper;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.DTO.Restourant.Response;
using GTBack.Core.Services;
using GTBack.Core.Services.Restourant;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers.Restourant;

public class MenuController: CustomRestourantBaseController
{
    private readonly IMapper _mapper;
    private readonly IMenuAndCategoryService _service;

    public MenuController( IMapper mapper,IRoleService<RoleCreateDTO,RoleListDTO> roleService,IMenuAndCategoryService service)
    {
        _service = service;
        _mapper = mapper;
    }
    
         
    [HttpPost("CreatMenu")]
    public async Task<IActionResult> CreateMenu(MenuCreateDTO model)
    {
        return ApiResult(await _service.MenuCreate(model));
    }
    
   
    
    [HttpPost("CategoryAdd")]
    public async Task<IActionResult> CategoryAdd(CategoryAddDTO model)
    {
        return ApiResult(await _service.CategoryAdd(model));
    }
    
    [HttpPost("MenuItemAdd")]
    public async Task<IActionResult> MenuItemAdd(MenuItemAddDTO model)
    {
        return ApiResult(await _service.MenuItemAdd(model));
    }
    
    [HttpPost("ExtraMenuItemAdd")]
    public async Task<IActionResult> ExtraMenuItemAdd(ExtraMenuItemAddDTO model)
    {
        return ApiResult(await _service.ExtraMenuItemAdd(model));
    }
    
   
}
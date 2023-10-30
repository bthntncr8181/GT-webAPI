using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.DTO.Restourant.Response;
using GTBack.Core.Entities.Restourant;
using GTBack.Core.Services;
using GTBack.Core.Services.Restourant;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers.Restourant;

public class RoleController: CustomRestourantBaseController
{
    private readonly IMapper _mapper;
    private readonly IRoleService<RoleCreateDTO,RoleListDTO> _roleService;

    public RoleController( IMapper mapper,IRoleService<RoleCreateDTO,RoleListDTO> roleService,IEmployeeService employeeService)
    {
        _roleService = roleService;
        _mapper = mapper;
    }
    
         
    [HttpPost("Create")]
    public async Task<IActionResult> Create(RoleCreateDTO role)
    {
        return ApiResult(await _roleService.Create(role));
    }
    
    [HttpPost("List")]
    public async Task<IActionResult> Create()
    {
        return ApiResult(await _roleService.List());
    }
}
using AutoMapper;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Enums.Restourant;
using GTBack.Core.Services.Restourant;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers.Restourant;

public class AdditionAndOrderController: CustomRestourantBaseController
{
    private readonly IMapper _mapper;
    private readonly IAdditionAndOrderService _service;

    public AdditionAndOrderController( IMapper mapper,IAdditionAndOrderService service)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpPost("AdditionAddOrUpdate")]
    public async Task<IActionResult> AdditionAddOrUpdate(AdditionAddOrUpdateDTO model)
    {
        return ApiResult(await _service.AdditionAddOrUpdate(model));
    }
    
   
    
    [HttpPost("OrderAddOrUpdate")]
    public async Task<IActionResult> OrderAddOrUpdate(OrderAddOrUpdateDTO model)
    {
        return ApiResult(await _service.OrderAddOrUpdate(model));
    }
    
    
    [HttpPost("ChangeOrderStatus")]
    public async Task<IActionResult> ChangeOrderStatus(ChangeOrderStatusDTO model)
    {
        return ApiResult(await _service.ChangeOrderStatus(model));
    }
    
    [HttpPost("CloseAddition")]
    public async Task<IActionResult> CloseAddition([FromQuery]long additionId)
    {
        return ApiResult(await _service.CloseAddition(additionId));
    }
    
    [HttpGet("AllAdditionList")]
    public async Task<IActionResult> AllAdditionList(int activeStatus)
    {
        return ApiResult(await _service.AllAdditionList(activeStatus));
    }
    
    
    
    [HttpGet("OrderListByAdditionId")]
    public async Task<IActionResult> OrderListByAdditionId(long additionId)
    {
        return ApiResult(await _service.OrderListByAdditionId(additionId));
    }
    
    [HttpGet("ActiveOrderListByAdditionId")]
    public async Task<IActionResult> ActiveOrderListByAdditionId(long additionId)
    {
        return ApiResult(await _service.ActiveOrderListByAdditionId(additionId));
    }
    
    
    [HttpGet("AllOrderListByOrderStatus")]
    public async Task<IActionResult> AllOrderListByOrderStatus(OrderStatus orderStatus)
    {
        return ApiResult(await _service.AllOrderListByOrderStatus(orderStatus));
    }
    
   
    
    [HttpDelete("AdditionDelete")]
    public async Task<IActionResult> AdditionDelete(int id)
    {
        return ApiResult(await _service.AdditionDelete(id));
    }
    
    [HttpDelete("OrderDelete")]
    public async Task<IActionResult> OrderDelete(int id)
    {
        return ApiResult(await _service.OrderDelete(id));
    }
}
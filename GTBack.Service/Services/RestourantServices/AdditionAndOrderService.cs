using System.Security.Claims;
using AutoMapper;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.DTO.Restourant.Response;
using GTBack.Core.Entities.Restourant;
using GTBack.Core.Enums.Restourant;
using GTBack.Core.Results;
using GTBack.Core.Services;
using GTBack.Core.Services.Restourant;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GTBack.Service.Services.RestourantServices;

public class AdditionAndOrderService : IAdditionAndOrderService
{
    private readonly IService<Addition> _additionService;
    private readonly IService<Order> _orderService;
    private readonly IService<Table> _tableService;
    private readonly IService<OrderProcess> _orderProcessService;
    private readonly IService<TableArea> _tableAreaService;
    private readonly ITableAndAreaService _tableAndAreaService;
    private readonly IMapper _mapper;
    private readonly ClaimsPrincipal? _loggedUser;


    public AdditionAndOrderService(
        IHttpContextAccessor httpContextAccessor, IService<OrderProcess> orderProcessService,
        IService<Table> tableService, IService<TableArea> tableAreaService,
        ITableAndAreaService tableAndAreaService, IService<Addition> additionService, IService<Order> orderService,
        IMapper mapper)
    {
        _mapper = mapper;
        _orderService = orderService;
        _tableAndAreaService = tableAndAreaService;
        _additionService = additionService;
        _orderProcessService = orderProcessService;
        _tableService = tableService;
        _tableAreaService = tableAreaService;
        _loggedUser = httpContextAccessor.HttpContext?.User;
    }

    public async Task<IResults> AdditionAddOrUpdate(AdditionAddOrUpdateDTO model)
    {
        model.IsClosed = false;
        if (model.Id != 0)
        {
            
           
            var response = _mapper.Map<Addition>(model);
            await _additionService.AddAsync(response);
            return new SuccessResult();
        }
        else
        {
            var response = _mapper.Map<Addition>(model);
            await _additionService.UpdateAsync(response);
            return new SuccessResult();
        }
    }

    public async Task<IResults> OrderAddOrUpdate(OrderAddOrUpdateDTO model)
    {
        if (model.Id != 0)
        {
            
           
            var response = _mapper.Map<Order>(model);
           var addedOrder= await _orderService.AddAsync(response);
            
            var orderProcess = new OrderProcess()
            {
                InitialOrderStatus =OrderStatus.ORDERED,
                FinishedOrderStatus = OrderStatus.ORDERED,
                ChangeDate = DateTime.UtcNow,
                ChangeNote = addedOrder.OrderNote,
                OrderId = addedOrder.Id,
                EmployeeId = GetLoggedUserId()
            };
            
             await _orderProcessService.AddAsync(orderProcess);

            return new SuccessResult();
        }
        else
        {
            var response = _mapper.Map<Order>(model);
            await _orderService.UpdateAsync(response);
            return new SuccessResult();
        }
    }

    public async Task<IResults> OrderDelete(long id)
    {
        var order = await _orderService.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (order != null)
        {
            order.IsDeleted = true;
            await _orderService.UpdateAsync(order);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Order Not Found");
        }
    }

    public async Task<IResults> AdditionDelete(long id)
    {
        var addition = await _additionService.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (addition != null)
        {
            addition.IsDeleted = true;
            await _additionService.UpdateAsync(addition);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Addition Not Found");
        }
    }

    public async Task<IDataResults<ICollection<AdditionListDTO>>> AllAdditionList(int isActive)
    {
        var companyId = GetLoggedCompanyId();
        var tableRepo = _tableService.Where(x => !x.IsDeleted);
        var tableAreaRepo = _tableAreaService.Where(x => !x.IsDeleted);
        var additionRepo = _additionService.Where(x => !x.IsDeleted);

        if (isActive == 0)
        {
            additionRepo = _additionService.Where(x => !x.IsDeleted && !x.IsClosed);
        }
        else if (isActive == 1)
        {
            additionRepo = _additionService.Where(x => !x.IsDeleted && x.IsClosed);
        }
        else
        {
            additionRepo = _additionService.Where(x => !x.IsDeleted);
        }

        var query = from addition in additionRepo
            join table in tableRepo on addition.TableId equals table.Id into tableLeft
            from table in tableLeft.DefaultIfEmpty()
            join tableArea in tableAreaRepo on table.TableAreaId equals tableArea.Id into tableAreaLeft
            from tableArea in tableAreaLeft.DefaultIfEmpty()
            select new AdditionListDTO()
            {
                Id = addition.Id,
                Name = addition.Name,
                TableNumber = table.TableNumber,
                TableId = table.Id,
                ClientId = addition.ClientId,
                IsClosed = addition.IsClosed,
                ClosedDate = addition.ClosedDate,
                TableAreaId = tableArea.Id,
                TableAreaName = tableArea.Name,
                CreatedDate = addition.CreatedDate
            };

        var response = _mapper.Map<ICollection<AdditionListDTO>>(await query.ToListAsync());
        return new SuccessDataResult<ICollection<AdditionListDTO>>(response);
    }


    public async Task<IDataResults<ICollection<OrderListDTO>>> OrderListByAdditionId(long additionId)
    {
        var orderList = await _orderService.Where(x => x.AdditionId == additionId).ToListAsync();
        var response = _mapper.Map<ICollection<OrderListDTO>>(orderList);
        return new SuccessDataResult<ICollection<OrderListDTO>>(response);
    }

    public async Task<IDataResults<ICollection<OrderListDTO>>> ActiveOrderListByAdditionId(long additionId)
    {
        var orderList = await _orderService.Where(x =>
            !x.IsDeleted && x.AdditionId == additionId && (x.OrderStatus.Equals(OrderStatus.DELİVERED) ||
                                                           x.OrderStatus.Equals(OrderStatus.CANCELED))).ToListAsync();
        var response = _mapper.Map<ICollection<OrderListDTO>>(orderList);
        return new SuccessDataResult<ICollection<OrderListDTO>>(response);
    }

    public async Task<IDataResults<ICollection<OrderListDTO>>> AllOrderListByOrderStatus(OrderStatus orderStatus)
    {
        var orderList = await _orderService.Where(x => !x.IsDeleted && x.OrderStatus.Equals(orderStatus)).ToListAsync();
        var response = _mapper.Map<ICollection<OrderListDTO>>(orderList);
        return new SuccessDataResult<ICollection<OrderListDTO>>(response);
    }

    public async Task<IResults> ChangeOrderStatus(ChangeOrderStatusDTO model)
    {
        var order = await _orderService.Where(x => !x.IsDeleted && x.Id == model.OrderId).FirstOrDefaultAsync();
        if (order != null)
        {
            var orderProcess = new OrderProcess()
            {
                InitialOrderStatus = order.OrderStatus,
                FinishedOrderStatus = model.OrderStatus,
                ChangeDate = DateTime.UtcNow,
                ChangeNote = model.ChangeNote,
                OrderId = order.Id,
                EmployeeId = GetLoggedUserId()
            };

            order.OrderStatus = model.OrderStatus;

            if (model.OrderStatus == OrderStatus.DELİVERED)
            {
                order.OrderDeliveredDate = DateTime.UtcNow;
            }


            await _orderProcessService.AddAsync(orderProcess);
            await _orderService.UpdateAsync(order);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Order Not Found");
        }
    }

    public async Task<IResults> CloseAddition(long additionId)
    {
        var addition = await _additionService.Where(x => !x.IsDeleted && x.Id == additionId).FirstOrDefaultAsync();
        if (addition != null)
        {
            addition.IsClosed = true;
            addition.ClosedDate = DateTime.UtcNow;
            await _additionService.UpdateAsync(addition);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Addition Not Found");
        }
    }


    private long? GetLoggedCompanyId()
    {
        var userRoleString = _loggedUser.FindFirstValue("companyId");
        if (long.TryParse(userRoleString, out var userId))
        {
            return userId;
        }

        return null;
    }

    private long GetLoggedUserId()
    {
        var userRoleString = _loggedUser.FindFirstValue("Id");
        if (long.TryParse(userRoleString, out var userId))
        {
            return userId;
        }

        return 0;
    }
}
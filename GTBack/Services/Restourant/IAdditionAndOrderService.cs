using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.DTO.Restourant.Response;
using GTBack.Core.Enums.Restourant;
using GTBack.Core.Results;

namespace GTBack.Core.Services.Restourant;

public interface IAdditionAndOrderService
{
    Task<IResults> AdditionAddOrUpdate(AdditionAddOrUpdateDTO model);
    Task<IResults> OrderAddOrUpdate(OrderAddOrUpdateDTO model);

    Task<IResults> OrderDelete(long id);
    Task<IResults> AdditionDelete(long id);

    Task<IDataResults<ICollection<AdditionListDTO>>> AllAdditionList(int isActive);
    Task<IDataResults<ICollection<OrderListDTO>>> OrderListByAdditionId(long additionId);
    Task<IDataResults<ICollection<OrderListDTO>>> ActiveOrderListByAdditionId(long additionId);
    Task<IDataResults<ICollection<OrderListDTO>>> AllOrderListByOrderStatus(OrderStatus orderStatus);
    
    Task<IResults>  ChangeOrderStatus(ChangeOrderStatusDTO model);
    Task<IResults>  CloseAddition(long additionId);
}
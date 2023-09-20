using GTBack.Core.DTO;
using GTBack.Core.Results;

namespace GTBack.Core.Services;

public interface IEventService
{ 
    // id tokendan dönecek
    // Task<IDataResults<EventListAdminResponseDto>> GetListByAdminId();
    // id tokendan dönecek
    Task<IDataResults<ICollection<EventListClientResponseDto>>> ListEventsByUserId(DateTime date);
    Task<IDataResults<ICollection<EventListClientResponseDto>>> ListEventsByUserIdByWeek(DateTime date);
    Task<IDataResults<ICollection<EventToMonthDTO>>> GetListDayByClientId(DateTime date);
    
    Task<IResults>  CreateEvent(EventAddRequestDTO eventId);
    
    
}
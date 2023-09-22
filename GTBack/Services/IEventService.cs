using GTBack.Core.DTO;
using GTBack.Core.Results;

namespace GTBack.Core.Services;

public interface IEventService
{ 
  
    Task<IDataResults<ICollection<EventListClientResponseDto>>> ListEventsByUserId(DateTime date);
    Task<IDataResults<ICollection<EventListClientResponseDto>>> ListEventsByUserIdByDay(DateTime date);
    Task<IDataResults<ICollection<EventToMonthDTO>>> GetListDayByClientId(DateTime date);
    Task<IResults> ChangeEventTime(ChageEventTimeDto eventTime);
    Task<IResults>  CreateEvent(EventAddRequestDTO eventId);
    Task<IDataResults<EventByEventId>> EventDetailByEventId(int eventId);


}
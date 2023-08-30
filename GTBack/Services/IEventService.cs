using GTBack.Core.DTO;
using GTBack.Core.Results;

namespace GTBack.Core.Services;

public interface IEventService
{ 
    // id tokendan dönecek
    // Task<IDataResults<EventListAdminResponseDto>> GetListByAdminId();
    // id tokendan dönecek
    Task<IDataResults<ICollection<EventListClientResponseDto>>> GetListByClientId();
    //
    // Task<IDataResults<EventDetailResponseDto>> GetEventDetailById(int eventId);
    
    Task<IResults>  createEvent(EventAddRequestDTO eventId);
    
    // Task<IResults> deleteEvent(int  eventId);
    //
    // Task<IResults> updateEvent(EventUpdateRequestDTO eventId);
    
    

    
    


    
}
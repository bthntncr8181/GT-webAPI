using GTBack.Core.Results;

namespace GTBack.Core.Services;

public interface IGenericService<T1,T2>
{
    Task<IDataResults<T1>> Create(T1 model);
    Task<IDataResults<T1>> Update(T1 model,int id);
    Task<IResults> Delete(int id);
    Task<IDataResults<ICollection<T2>>> List();
}

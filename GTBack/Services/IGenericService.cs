using GTBack.Core.Results;

namespace GTBack.Core.Services;

public interface IGenericService<T>
{
    Task<IDataResults<T>> Create(T model);
    Task<IDataResults<T>> Update(T model,int id);
    Task<IResults> Delete(int id);
    Task<IResults> List();
}

using System.Collections.Generic;

namespace BLL.Services
{
    public interface IService<T>
    {
        T Create(T t);

        T Update(T t);

        IEnumerable<T> GetAll();
        T GetById(int Id);

        bool Delete(int Id);
    }
}

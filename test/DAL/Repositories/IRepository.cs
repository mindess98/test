using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        T Create(T t);

        T Update(T t);

        ICollection<T> GetAll();
        T GetById(int Id);

        bool Delete(int Id);
    }
}

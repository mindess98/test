using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitsOfWork
{
    public interface IUnitofWork<T> : IDisposable
    {
        IRepository<T> Repository { get; }

        int Complete();
    }
}

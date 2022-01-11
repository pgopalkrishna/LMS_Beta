using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Interfaces
{
    interface IRepository<T> : IDisposable where T : class
    {
        Task Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task<IEnumerable<T>> GetList();
        //Task<IQueryable<T>> GetList2();
        Task<T> GetById(int Id);
        Task<int> SaveChanges();
    }
}

using LMSDAL;
using LMSService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _Context;
        private readonly DbSet<T> _DbSet;

        public Repository(ApplicationContext context)
        {
            _Context = context;
            _DbSet = context.Set<T>();
        }

        public async Task Add(T obj)
        {
            await _DbSet.AddAsync(obj);
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await _DbSet.ToListAsync();
        }
        public async Task<T> GetById(int Id)
        {
            return await _DbSet.FindAsync(Id);
        }

        public void Update(T obj)
        {
            _DbSet.Update(obj);
        }

        public void Delete(T obj)
        {
            _DbSet.Remove(obj);
        }

        public async Task<int> SaveChanges()
        {
            return await _Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

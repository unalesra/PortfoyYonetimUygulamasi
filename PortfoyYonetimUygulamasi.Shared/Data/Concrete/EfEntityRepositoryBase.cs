﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Shared.Data.Abstract;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Shared.Data.Concrete
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

       
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); }); //remove async olmadığı için task oluşturuldu
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> Predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();//.AsNoTracking();

            if (Predicate != null)
            {
                query = query.Where(Predicate); //.AsNoTracking();
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> Predicate)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();//.AsNoTracking();

            if (Predicate != null)
            {
                query = query.Where(Predicate); //.AsNoTracking();
            }
            return await query.SingleOrDefaultAsync();
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity);});
            return entity;
        }
        public  void DetachEntity()
        {
             _context.ChangeTracker.Clear();
        }
    }
}

using GreenHouseFull.Core.Entities;
using GreenHouseFull.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseFull.Core.Repos
{
    public abstract class EFRepoBase<TContext, TEntity> : ISelectableRepo<TEntity>, IUpdatableRepo<TEntity>, IInsertableRepo<TEntity>, IDeletableRepo<TEntity> where TEntity : MyEntityBase where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public EFRepoBase(TContext context)
        {
            _context = context;
        }

        public EFRepoBase()
        {
            _context = new TContext();
        }

        public TEntity Add(TEntity item)
        {
            return _context.Set<TEntity>().Add(item);
        }

        public List<TEntity> AddRange(List<TEntity> items)
        {
            return _context.Set<TEntity>().AddRange(items).ToList();
        }

        public TEntity Delete(TEntity item)
        {
            return _context.Set<TEntity>().Remove(item);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public List<TEntity> GetBy(Func<TEntity, bool> whereCondition)
        {
            return _context.Set<TEntity>().Where(whereCondition).ToList();
        }

        public TEntity GetByFirst(Func<TEntity, bool> whereCondition)
        {
            return _context.Set<TEntity>().Where(whereCondition).FirstOrDefault();
        }

        public TEntity GetByID(object ID)
        {
            return _context.Set<TEntity>().Find(ID);
        }

        public int SaveMyChanges()
        {
            return _context.SaveChanges();
        }

        public TEntity Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return _context.Set<TEntity>().Attach(item);
        }
    }
}

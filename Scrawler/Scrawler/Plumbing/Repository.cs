using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;
using Mindscape.LightSpeed.Logging;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Plumbing
{

    public class Repository<T> : IRepository<T> where T : Entity<int>
    {
        private readonly LightSpeedContext<ScrawlerUnitOfWork> _context;
        public Repository()
        {
            _context = new LightSpeedContext<ScrawlerUnitOfWork>
            {
                ConnectionString =
                                  @"Server=tcp:bc2wsegi5e.database.windows.net,1433;Database=ScrawlerDB;User ID=devacademy@bc2wsegi5e;Password=15WalterStreet;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;",
                IdentityMethod = IdentityMethod.IdentityColumn,
                QuoteIdentifiers = true,
                Logger = new TraceLogger()
            };
        }

        public IList<T> Get(Expression<Func<T, bool>> predicate)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                return unitOfWork.Query<T>().Where(predicate).ToList();
            }
        }

        public IList<T> GetAll()
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                return unitOfWork.Find<T>();
            }
        }

        public void Add(T entity)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                if (entity.Id > 0)
                    unitOfWork.Attach(entity);
                else
                    unitOfWork.Add(entity);
            }
        }

        public void DeleteAll()
        {
            foreach (var entity in GetAll())
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                unitOfWork.Remove(entity);
            }
        }

        public T FindById(int id)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                return unitOfWork.FindById<T>(id);
            }
        }

        public void SaveChanges()
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                unitOfWork.SaveChanges();
            }
        }

        public void Dispose()
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                unitOfWork.Dispose();
            }
        }
    }
}
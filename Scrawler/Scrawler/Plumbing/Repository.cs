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
        private readonly ScrawlerUnitOfWork _unitOfWork;

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
            _unitOfWork = _context.CreateUnitOfWork();
        }

        public IList<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Query<T>().Where(predicate).ToList();
        }

        public IList<T> GetAll()
        {
            return _unitOfWork.Find<T>();
        }

        public void Add(T entity)
        {
            if (entity.Id > 0)
                _unitOfWork.Attach(entity);
            else
                _unitOfWork.Add(entity);
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
            _unitOfWork.Remove(entity);
        }

        public T FindById(int id)
        {
            return _unitOfWork.FindById<T>(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
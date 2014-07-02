using Mindscape.LightSpeed;
using System;
using System.Collections.Generic;
using System.Linq;
using Mindscape.LightSpeed.Linq;
using System.Linq.Expressions;
using Mindscape.LightSpeed.Logging;

namespace Scrawler.Plumbing
{
    public class Repository<T> where T : Entity<int>
    {
        public Repository()
        {
            var context = new LightSpeedContext<ScrawlerUnitOfWork>
            {
                ConnectionString = @"server=.\sqlexpress;database=Scrawler;Trusted_Connection=True;",
                IdentityMethod = IdentityMethod.IdentityColumn,
                QuoteIdentifiers = true
            };

            context.Logger = new ConsoleLogger();

            _unitOfWork = context.CreateUnitOfWork();
        }
        private readonly IUnitOfWork _unitOfWork;

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
                _unitOfWork.Attach(entity, AttachMode.Import);
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
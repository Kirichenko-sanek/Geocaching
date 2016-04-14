using System;
using System.Linq;
using Geocaching.Core;
using Geocaching.Interfases.Manager;
using Geocaching.Interfases.Repository;
using Geocaching.Interfases.Validator;

namespace Geocaching.BL.Manager
{
    public class Manager<T> : IManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;

        public Manager(IRepository<T> repository, IValidator<T> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public void Add(T entity)
        {
            if (!_validator.IsValid(entity))
                throw new Exception("Entity is not valid.");
            _repository.Add(entity);
            _repository.Save();
        }

        public void Delete(T entity)
        {
            if (!_validator.IsValid(entity))
                throw new Exception("Entity is not valid.");

            _repository.Delete(entity);
            _repository.Save();
        }

        public void Update(T entity)
        {
            if (!_validator.IsExists(entity.id))
                throw new Exception("Entity doesn't exist.");
            _repository.Update(entity);
            _repository.Save();
        }

        public IQueryable<T> GetAll()
        {

            return _repository.GetAll();
        }

        public void Save()
        {
            _repository.Save();
        }

        public T GetById(long id)
        {
            if (!_validator.IsExists(id))
                throw new Exception("Entity doesn't exist.");
            return _repository.GetByID(id);
        }
    }
}

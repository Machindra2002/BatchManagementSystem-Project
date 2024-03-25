using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        batch_managementDBEntities db;
        public Repository(batch_managementDBEntities db)
        {
            this.db = db;
        }
        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            Save();
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            db.Set<TEntity>().Remove(entity);
            Save();
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            return entity;
        }

        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            try
            {
              db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Log or print validation error details
                        Console.WriteLine($"Entity: {validationErrors.Entry.Entity.GetType().Name}");
                        Console.WriteLine($"Property: {validationError.PropertyName}");
                        Console.WriteLine($"Error: {validationError.ErrorMessage}");
                    }
                }
                throw; // Rethrow the exception or handle it accordingly
            }
        }
    }
}

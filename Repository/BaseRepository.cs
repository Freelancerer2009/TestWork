using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T> where T : class
    {
        private DbSet<T> Local => Context.Set<T>();
        internal readonly WebDatabaseContext Context;
        private object lockObj = new object();
        public BaseRepository(WebDatabaseContext context)
        {
            Context = context;
        }

        public virtual void Add(T item)
        {
            if(item != null)
            {
                Local.Add(item);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public virtual void Delete(int id)
        {
            if(id > 0)
            {
                T instance = Local.Find(id);
                if (instance != null)
                    Local.Remove(instance);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public virtual T GetById(int id)
        {
            if (id > 0)
            {
                return Local.Find(id);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public virtual IEnumerable<T> GetList()
        {
            return Local.ToList();
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public async virtual void SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public virtual void Update(T item)
        {
            if (item == null)
                throw new NullReferenceException();

            var entry = Context.Entry(item);

            if (entry != null)
                entry.State = EntityState.Modified;
        }
    }
}

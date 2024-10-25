using DataAccessLayer.Models;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.GameAnalyticsRepository
{
    public class GamesODataRepository<T> : GamesDataAccessBase, IDisposable where T : class, IId
    {
        public GamesODataRepository()
        {
            this.Connection = this.NewDataConnection();
        }

        private DataConnection Connection;
        public IQueryable<T> Get()
        {
            return this.Connection.GetTable<T>();            
        }

        public Task<int> Update( T record)
        {
            var exists = Connection.GetTable<T>().Where(x =>  x.Id == record.Id)?.FirstOrDefault();
            if(exists != null)
                return Connection.UpdateAsync<T>(record);

            return new Task<int>( () => -1); // Fake task.
        }

        public void Dispose()
        {
            Connection.Dispose();
            Connection = null;
        }
    }
}

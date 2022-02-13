using RadioFitCalendar.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RadioFitCalendar.Services
{
    public class AchievementDataStore : IDataStore<Achievement>
    {
        readonly SQLiteAsyncConnection database;

        public AchievementDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.ReadWrite);
            database.CreateTableAsync<Achievement>().Wait();
        }

        public Task<int> AddAsync(Achievement item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> DeleteAsync(string id)
        {
            return database.DeleteAsync(id);
        }

        public Task<Achievement> GetAsync(string id)
        {
            return database.Table<Achievement>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<Achievement> GetAsync(int type, string date)
        {
            return database.Table<Achievement>().Where(x => x.Type == type && x.Date == date).FirstOrDefaultAsync();
        }

        public Task<int> UpdateAsync(Achievement item)
        {
            return database.UpdateAsync(item);
        }

        public Task<List<Achievement>> GetListAsync()
        {
            return database.Table<Achievement>().ToListAsync();
        }

        public Task<int> TruncateAsync()
        {
            return database.DeleteAllAsync<Achievement>();
        }
    }
}

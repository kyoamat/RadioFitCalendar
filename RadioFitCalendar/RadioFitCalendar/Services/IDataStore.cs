using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadioFitCalendar.Services
{
    public interface IDataStore<T>
    {
        Task<int> AddAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(string id);
        Task<T> GetAsync(string id);
        Task<T> GetAsync(int type, string date);
        Task<List<T>> GetListAsync();
        Task<int> TruncateAsync();
    }
}

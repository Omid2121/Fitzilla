using Fitzilla.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzilla.App.Services
{
    public interface IDataStore<T, C>
    {
        //TODO: Add the URLs for the API calls
#if DEBUG
        internal static readonly string API_URL = "https://localhost:44305/api/";
#else
        internal static readonly string API_URL = "";
#endif

        Task<bool> AddItemAsync(C item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}

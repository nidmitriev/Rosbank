using System.Collections.Generic;
using System.Threading.Tasks;
using RosbankHelpCenter.API.Models;

namespace RosbankHelpCenter.API.Data
{
    public interface IDatingRepository 
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}
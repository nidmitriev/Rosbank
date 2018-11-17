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
         Task<IEnumerable<Question>> GetQuestions();
         Task<User> GetUser(int id);
         Task<IEnumerable<Question>> GetQuestion(bool type);
         Task<IEnumerable<Question>> GetQuestion(string user_question);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RosbankHelpCenter.API.Models;
using RosbankHelpCenter.API.DifferentSource;
using System.Linq;

namespace RosbankHelpCenter.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly int AmountOfSugestions = 3;
        private readonly int AmountOfPopularQuestsForView = 6;
        private readonly DataContext _context;

        public DatingRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }

        ///возвращаем все вопросы данного типа
        public async Task<IEnumerable<Question>> GetQuestion(bool type)
        {
            var question = from quest in (await _context.Questions.ToListAsync()) 
            where quest.Type==type select quest;
            return question;
        }
        ///возвращаем енумератор, тк есть случай выборки саджестов
        public async Task<IEnumerable<Question>> GetQuestion(string user_question)
        {
            //  реализовать алгоритм анализа сообщений
            var question = await _context.Questions.FirstOrDefaultAsync(u => u.Quest == user_question);

            // реализация отметки популярности
            if (question != null)
            {
                question.IndexOfPop++;
                await SaveAll();
            }
            else
            {
                //генерим саджесты и возвращаем
                var sugests = (await _context.Questions.ToArrayAsync())
                .OrderByDescending(q => LevenshteinDistance.LevenshteinDistanceCompute(q.Quest, user_question));
                return sugests.Take(AmountOfSugestions);
            }
            return new List<Question>() { question };
        }
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            //будем возвращать соответственно популярности
            var questions = (await _context.Questions.ToListAsync()).OrderByDescending(q => q.IndexOfPop);

            return questions.Take(AmountOfPopularQuestsForView);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
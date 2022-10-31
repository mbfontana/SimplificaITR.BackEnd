using SimplificaITR.BackEnd.Data;
using SimplificaITR.BackEnd.Models;

namespace SimplificaITR.BackEnd.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Add(User user);
        bool Save();
        bool Update(User user);
        bool Delete(User user);
        User GetByEmail(string email);
    }
    public class UserRepository : IUserRepository
    {
        private SimplificaITRContext _context;

        public UserRepository(SimplificaITRContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email.Equals(email));
        }

        public bool Add(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Remove(user);
            return Save();
        }
    }
}

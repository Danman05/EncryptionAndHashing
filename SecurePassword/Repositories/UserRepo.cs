using SecurePassword.Interface;

namespace SecurePassword.Repositories
{
    public class UserRepo : IUserRepo
    {
        public User? GetOne(int id)
        {
            using dataContext dataContext = new dataContext();
            User? user = dataContext.Users.Find(id);
            return user != null ? user : null;
        }

        public ICollection<User> GetAll()
        {
            using dataContext dataContext = new dataContext();
            return dataContext.Users.ToList();
        }

        public void Create(User user)
        {
            using dataContext dataContext = new dataContext();
            dataContext.Users.Add(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            using dataContext dataContext = new dataContext();
            dataContext.Users.Remove(user);
        }
    }
}

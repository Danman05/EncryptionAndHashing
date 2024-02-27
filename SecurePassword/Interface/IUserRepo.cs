using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword.Interface
{
    public interface IUserRepo
    {
        User? GetOne(int id);
        ICollection<User> GetAll();
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        
    }
}

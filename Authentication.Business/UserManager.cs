using Aunthentication.DAL;
using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Business
{
    public class UserManager
    {
        UserRepository repo = new UserRepository();

        public void Add(User user)
        {
            repo.AddUser(user);
        }

        public User GetbyId(int id)
        {
            return repo.GetbyId(id);
        }

        public void Update(User user)
        {
            repo.UpdateUser(user);
        }

        public void Delete(int id)
        {
            repo.DeleteUser(id);
        }

        public List<User> GetAll()
        {
            return repo.GetAll();
        }

        public bool Validate(string login, string password)
        {
            bool Trve = false;
            var users = repo.ValidateUser(login, password);
            Trve = users.Count == 1 ? true : false;
            return Trve;
        }

        public void AddRoles(User user)
        {
            throw new NotImplementedException();
        }
    }
}

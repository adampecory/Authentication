using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aunthentication.DAL
{
    public class UserRepository
    {
        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="user">User</param>
        public void AddUser(User user)
        {
            string procname = "spUserAdd";
            SqlParameter pLogin = new SqlParameter("@Login", user.Login);
            SqlParameter pPassword = new SqlParameter("@Password", user.Password);
            SqlParameter pEmail = new SqlParameter("@Email", user.Email);
            SqlParameter pTel = new SqlParameter("@Tel", user.Tel);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pLogin, pPassword, pEmail, pTel });

            //TODO : Ajour du role "MEMBRE" par défaut
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="user">User</param>
        public void UpdateUser(User user)
        {
            string procname = "spUserUpdate";
            SqlParameter pId = new SqlParameter("@Id", user.Id);
            SqlParameter pLogin = new SqlParameter("@Login", user.Login);
            SqlParameter pPassword = new SqlParameter("@Password", user.Password);
            SqlParameter pEmail = new SqlParameter("@Email", user.Email);
            SqlParameter pTel = new SqlParameter("@Tel", user.Tel);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pId, pLogin, pPassword, pEmail, pTel });
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User Id</param>
        public void DeleteUser(int id)
        {
            string procname = "spUserDelete";
            SqlParameter pId = new SqlParameter("@Id", id);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pId });
        }

        /// <summary>
        /// VAlidate a User
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public List<User> ValidateUser(string login, string password)
        {
            string procname = "spUserValidate";
            SqlParameter pPassword = new SqlParameter("@Id", password);
            SqlParameter pLogin = new SqlParameter("@Login", login);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pLogin, pPassword});
            var users = GetUsers(DT);
            return users;
        }

        /// <summary>
        /// Get a user by his Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public User GetbyId(int id)
        {
            string procname = "spUserGetbyId";
            SqlParameter pId = new SqlParameter("@Id", id);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pId });
            var users = GetUsers(DT);
            return users.FirstOrDefault();
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            string procname = "spUserGet";
            DataTable DT = Database.ExcecuteReader(procname);
            var users = GetUsers(DT);
            return users;
        }

        /// <summary>
        /// Get a User by his Login
        /// </summary>
        /// <param name="login">User Login</param>
        /// <returns></returns>
        public List<User> GetbyLogin(string login)
        {
            string procname = "spUserValidate";
            SqlParameter pLogin = new SqlParameter("@Login", login);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pLogin });
            var users = GetUsers(DT);
            return users;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        private List<User> GetUsers(DataTable DT)
        {
            var users = new List<User>();
            foreach(DataRow row in DT.Rows)
            {
                users.Add(new User
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Login = row["Login"].ToString(),
                    Tel = row["Tel"].ToString(),
                    Email = row["Email"].ToString(), 
                    Password = row["Password"].ToString()
                });                
            }
            return users;
        }
    }
}

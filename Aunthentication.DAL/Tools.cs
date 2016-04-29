using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aunthentication.DAL
{
    public class Tools
    {
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public static List<User> GetUsers(DataTable DT)
        {
            var users = new List<User>();
            foreach (DataRow row in DT.Rows)
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

        /// <summary>
        /// Retourne une liste de role à partir d'un DATATABLE
        /// </summary>
        /// <param name="DT">Datatable</param>
        /// <returns></returns>
        public static List<Role> GetRoles(DataTable DT)
        {
            List<Role> roles = new List<Role>();
            foreach (DataRow row in DT.Rows)
            {
                roles.Add(new Role { Id = int.Parse(row["Id"].ToString()), Name = row["Name"].ToString() });
            }
            return roles;
        }  
    }
}

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
    public class UserRoleRepository
    {
        public void AddUserToRole(int userId, int roleId)
        {
            string procname = "spURAddUserToRole";
            SqlParameter pUserId = new SqlParameter("@ID_USER", userId);
            SqlParameter pRoleId = new SqlParameter("@ID_ROLE", roleId);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pUserId, pRoleId});            
        }

        public List<Role> GetRolesbyUserLogin(string login)
        {
            string procname = "spURGetRolesbyUser";
            SqlParameter pLogin = new SqlParameter("@Login", login);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pLogin });
            return Tools.GetRoles(DT);

        }

        public List<Role> GetRolesbyUserId(int id)
        {
            string procname = "spURGetRolesbyUser";
            SqlParameter pId = new SqlParameter("@UserId", id);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pId });
            return Tools.GetRoles(DT);
        }

        public List<User> GetUsersbyRoleId(int roleId)
        {
            string procname = "spURGetUsersbyRoleId";
            SqlParameter pId = new SqlParameter("@RoleId", roleId);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pId });
            return Tools.GetUsers(DT);
        }


    }
}

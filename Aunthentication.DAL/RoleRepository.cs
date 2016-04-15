using Authentication.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Aunthentication.DAL
{
    public class RoleRepository
    {
        /// <summary>
        /// Ajouter un role
        /// </summary>
        /// <param name="role">Role</param>
        public void AddRole(Role role)
        {
            string procname = "spRoleAdd";
            var pName = new SqlParameter("@Name", role.Name);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pName });
        }

        /// <summary>
        /// Mettre à jour un Role
        /// </summary>
        /// <param name="role">Role</param>
        public void UpdateRole(Role role)
        {
            string procname = "spRoleUpdate";
            var pId = new SqlParameter("@Id", role.Id);
            var pName = new SqlParameter("@Name", role.Name);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pId, pName });
        }

        /// <summary>
        /// Liste de tous les roles
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            string procname = "spRoleGet";
            DataTable DT = Database.ExcecuteReader(procname);
            var roles = GetRoles(DT);
            return roles;
        }


        /// <summary>
        /// Retourne un role à partir de son Id
        /// </summary>
        /// <param name="id">Role Id</param>
        /// <returns></returns>
        public Role GetRoleById(int id)
        {
            string procname = "spRoleGetbyId";
            var pId = new SqlParameter("@Id", id);
            DataTable DT = Database.ExcecuteReader(procname, new SqlParameter[] { pId });
            var roles = GetRoles(DT);
            return roles[0];
        }

        /// <summary>
        /// Supprime un role
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteRole(int Id)
        {
            var procname = "spRoleDelete";
            var pId = new SqlParameter("@Id", Id);
            Database.ExcecuteNonQuery(procname, new SqlParameter[] { pId });
        }

        /// <summary>
        /// Retourne une liste de role à partir d'un DATATABLE
        /// </summary>
        /// <param name="DT">Datatable</param>
        /// <returns></returns>
        private List<Role> GetRoles(DataTable DT)
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

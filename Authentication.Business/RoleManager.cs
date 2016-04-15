using Aunthentication.DAL;
using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Business
{
    public class RoleManager
    {
        public RoleRepository repo = new RoleRepository();

        public void AddRole(Role role)
        {
            repo.AddRole(role);
        }

        public void DeleteRole(int roleID)
        {
            repo.DeleteRole(roleID);
        }

        public void UpdateRole(Role role)
        {
            repo.UpdateRole(role);
        }

        public Role GetRolebyId(int id)
        {
            return repo.GetRoleById(id);
        }

        public List<Role> GetAllRoles()
        {
            return repo.GetRoles();
        }

        public void AddRolestoUser(User user, List<Role> roles)
        {
            throw new NotImplementedException();
        }
    }
}

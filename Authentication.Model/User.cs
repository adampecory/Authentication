using System.Collections.Generic;

namespace Authentication.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}

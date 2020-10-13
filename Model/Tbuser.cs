using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BookAndShelve.Model
{
    public class Tbuser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
       
        
        public List<TbBookAndShelve> BookAndShelves { get; set; }
        public List<TbUserRole> userRoles { get; set; }
        public List<Tbshelve> Shelves { get; set; }
    }
}

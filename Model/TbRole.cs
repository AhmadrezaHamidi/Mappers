using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndShelve.Model
{
    public class TbRole : IdentityRole
    {
       public List<TbUserRole> userRoles { get; set; }
    }
}

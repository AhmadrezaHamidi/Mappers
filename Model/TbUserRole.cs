using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndShelve.Model
{
    public class TbUserRole : IdentityUserRole<string>
    {
        public Tbuser User { get; set; }
        public TbRole Role { get; set; }
    }
}

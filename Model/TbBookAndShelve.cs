using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndShelve.Model
{
    public class TbBookAndShelve
    {
        public int Id { get; set; }
        public int BookID { get; set; }
        public int Shelved { get; set; }
        public tbBook book { get; set; }
        public Tbshelve shelve { get; set; }
    }
}

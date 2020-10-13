using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndShelve.Model
{
    public  class tbBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public List<TbBookAndShelve> BookAndShelves { get; set; }
    }
}

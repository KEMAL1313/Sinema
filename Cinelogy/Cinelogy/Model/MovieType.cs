using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinelogy.Model
{
    public class MovieType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }

    }
}

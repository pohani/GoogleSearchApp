using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class KeyWord
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }
}

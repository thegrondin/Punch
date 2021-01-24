using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punch.Models
{
    public class UserTask
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



    }
}

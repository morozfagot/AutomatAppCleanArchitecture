using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatApp.Domain.Entities
{
    public class AutomatCase
    {
        public int Id { get; set; }
        public int AutomatId { get; set; }
        public Automat? Automat { get; set; }
    }
}

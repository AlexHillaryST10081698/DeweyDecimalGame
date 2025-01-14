using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalApplication.Classes
{
    public class DeweyNumbers
    {
        public string CallNumbers { get; set; }
        public string Description { get; set; }
        public DeweyNumbers(string cnumbers, string descriptions) 
        {
            this.CallNumbers = cnumbers;
            this.Description = descriptions;
        }
    }
    
}

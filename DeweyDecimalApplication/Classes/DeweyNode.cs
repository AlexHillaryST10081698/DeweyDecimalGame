using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalApplication.Classes
{
    public class DeweyNode
    {
        public string CallNumbers { get; set; }
        public string Description { get; set; }
        public List<DeweyNode> Children { get; set; }
        // Add the following property
        public int AssociatedPictureBoxIndex { get; set; }

        // Add the following property
        public DeweyNode AssociatedLevel1Entry { get; set; }
        public DeweyNode AssociatedLevel2Entry { get; set; }
    }

}

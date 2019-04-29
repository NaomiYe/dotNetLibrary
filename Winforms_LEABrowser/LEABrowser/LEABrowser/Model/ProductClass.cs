using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEABrowser.Model
{
    public enum ProductType { Call = 1, SMS = 2 };
    public class ProductClass
    {
        public int ID { get; set; }
        public ProductType Type { get; set; }
        public Bitmap TypeIcon { get; set; }
        public DateTime CreationDate { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int InvestigationID { get; set; }
    }
}

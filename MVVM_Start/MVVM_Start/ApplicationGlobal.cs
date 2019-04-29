using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Start
{
    public class ApplicationGlobal
    {
        #region singleton parameters

        private static ApplicationGlobal instance;

        // will have the singleton getter
        public static ApplicationGlobal ApplicationGlobalInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationGlobal();
                }
                return instance;
            }
        }

        # endregion singleton parameters

        public List<string> BooksTypes = new List<string>() { "", "E-Book", "Printed" };
        public List<string> AvilableTypes = new List<string>() { "", "Yes", "No" };
    }
}

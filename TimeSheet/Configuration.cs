using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    [Serializable]
    public class Configuration
    {
        public string excelLocation;
        public string name;
        public int selectedProject;
        public int selectedActivity;
    }
}

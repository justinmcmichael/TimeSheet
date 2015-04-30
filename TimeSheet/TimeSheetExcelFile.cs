using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace TimeSheet
{
    class TimeSheetSourceData
    {
        private List<string> m_projects = new List<string>();
        private List<string> m_activities = new List<string>();

        string filename { get; set; }

        public List<string> projects {
            get {
                return m_projects;
            }
        }

        ~TimeSheetSourceData() {
            if (excelApp != null) {
                try
                {
                    excelApp.Quit();
                }
                catch (Exception ex)
                {
                    // nothing to do, this is just for cleanup
                }
            }
        }

        public List<string> activities {
            get {
                return m_activities;
            } 
        }

        private Application excelApp = null;

        public void LoadFile(string excelFileName)
        {
            try
            {
                if (excelFileName != "" && excelFileName != null)
                {
                    ExcelFile ef = new ExcelFile(excelFileName, 1);
                    string shouldBeProjects = ef[1, 1];
                    if (shouldBeProjects == "Projects")
                    {
                        projects.Clear();
                        activities.Clear();
                        FillFromExcel(ef, 2, 1, m_projects);
                    }

                    string shouldBeActivities = ef[1, 3];
                    if (shouldBeActivities == "Activities")
                    {
                        FillFromExcel(ef, 2, 3, m_activities);
                    }
                    ef.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine("Exception processing excel file " + ex.Message); }
        }

        private void FillFromExcel(ExcelFile ef, int row, int col, List<string> target, int misses = 1)
        {
            int missed = 0;
            for (; ; row++)
            {
                string value = ef[row, col];
                if (value == "")
                {
                    missed++;
                    if (missed > misses) break;
                }
                else
                {
                    target.Add(value);
                    missed = 0;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace TimeSheet
{
    class ExcelFile
    {
        private Microsoft.Office.Interop.Excel.Application m_excelApp = null;
        private Microsoft.Office.Interop.Excel.Workbook m_book = null;
        private Microsoft.Office.Interop.Excel.Worksheet m_sheet = null;
        private bool m_docOpened = false;
        public ExcelFile(string filename, int sheetNumber, bool create = false)
        {
            try
            {
                m_excelApp = new Microsoft.Office.Interop.Excel.Application();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Could not start excel. Is it installed? " +ex.Message);
                m_excelApp = null;
                return;
            }
            
            try
            {
                bool fileExists = System.IO.File.Exists(filename);
                if (create && !fileExists)
                {
                    m_book = m_excelApp.Workbooks.Add();
                    m_book.SaveAs(filename);
                }
                else
                {
                    m_book = m_excelApp.Workbooks.Open(filename, true);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Unable to open " + filename + ": " + ex2.Message);
                //m_excelApp.Quit();
                return;
            }

            try
            {
                m_sheet = m_book.Sheets[sheetNumber];
            }
            catch (Exception ex3)
            {
                MessageBox.Show("Unable to open worksheet: " + ex3.Message);
                //m_excelApp.Quit();
                //throw new Exception("Unable to open sheet " + sheetNumber.ToString());
                return;
            }

            m_docOpened = true;
        }

        private void ReleaseComObj(object o) {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
        }

        public void Close()
        {
            if (m_sheet != null)
            {
                ReleaseComObj(m_sheet);
            }
            if (m_book != null)
            {
                //m_book.Close();
                ReleaseComObj(m_book);
            }
            if (m_excelApp != null)
            {
                m_excelApp.Quit();
                //ReleaseComObj(m_excelApp);
            }
            m_docOpened = false;
        }

        ~ExcelFile()
        {
            if (m_docOpened == true)
            {
                throw new Exception("Error, ExcelFile instance not closed!");
            }
        }

        bool IsOpen
        {
            get
            {
                return m_docOpened;
            }
        }

        public void Save()
        {
            if (m_excelApp != null && m_book != null && m_docOpened)
            {
                m_book.Save();
            }
        }

        public string this[int row, int col]
        {
            get
            {
                if (m_docOpened && m_sheet != null)
                {
                    Range r = m_sheet.Cells[row, col];
                    return r.Text as string;
                } 
                return "";
            }

            set
            {
                if (m_docOpened && m_sheet != null)
                {
                    m_sheet.Cells[row, col] = value;
                }
            }
        }
    }
}

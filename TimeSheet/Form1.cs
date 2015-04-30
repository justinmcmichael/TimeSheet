using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSheet
{
    public partial class MainEntryForm : Form
    {
        private TimeSheetSourceData m_excelTimeSheetSrcData = new TimeSheetSourceData();
        private Configuration m_config = null;
        private string m_outputDirectory = "";
        private ExcelFile m_outputIRAPxl = null;
        private ExcelFile m_outputSREDxl = null;


        public MainEntryForm()
        {
            InitializeComponent();
            Stream src = null;
            bool configLoaded = false;
            try
            {
                src = new FileStream("config.bin", FileMode.Open, FileAccess.Read);
                IFormatter form = (IFormatter)new BinaryFormatter();
                m_config = form.Deserialize(src) as Configuration;
                src.Close();
                excelFileLocation.Text = m_config.excelLocation;
                userName.Text = m_config.name;
                configLoaded = true;

                datePicker.Value = DateTime.Today;

                if (File.Exists(excelFileLocation.Text))
                {
                    FileInfo fi = new FileInfo(excelFileLocation.Text);
                    m_outputDirectory = fi.Directory.ToString();
                }
            }
            catch (FileNotFoundException) { }
            catch (SerializationException) { }
            catch (Exception ex)
            {
                MessageBox.Show("Oops! There was a problem loading config.bin, sorry!\n" + ex.Message);
            }
            finally { if (src != null) src.Close(); }
            if (configLoaded)
            {
                LoadSettingsFromExcel();
                //m_outputExcelFile = new ExcelFile()
            }
        }

        private void LoadSettingsFromExcel() {
            try
            {
                projectChooser.Items.Clear();
                activityChooser.Items.Clear();
                m_excelTimeSheetSrcData.LoadFile(excelFileLocation.Text);
                foreach (string item in m_excelTimeSheetSrcData.projects)
                {
                    projectChooser.Items.Add(item);
                }
                foreach (string item in m_excelTimeSheetSrcData.activities)
                {
                    activityChooser.Items.Add(item);
                }
                activityChooser.SelectedIndex = 0;
                projectChooser.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening excel file " + excelFileLocation.Text + ". " + ex.Message);
            }
        }

        private void submitRecord_Click(object sender, EventArgs e)
        {
            string name = userName.Text;
            string excelFile = excelFileLocation.Text;
            if (name == "")
            {
                MessageBox.Show("Error: You must enter your name (first_last).");
                userName.Focus();
                return;
            }
            if (excelFile == "")
            {
                MessageBox.Show("Error: Choose your timesheet excel file.");
                chooseExcelFile.Focus();
                //LoadSettingsFromExcel();
                return;
            }

            if (m_config == null) {
                SaveConfiguration();
            }

            if (hoursEntry.Text == "")
            {
                MessageBox.Show("Oops! You forgot to specify the number of hours worked!");
                return;
            }
            try
            {
                float dummy;
                float.TryParse(hoursEntry.Text, out dummy);
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show("Oops! Hours field is not a number!");
                return;
            }

            string path = m_outputDirectory;

            if (m_outputIRAPxl == null)
            {
                m_outputIRAPxl = OpenExcelTimesheetFile(path, name, "IRAP");
            }
            if (m_outputSREDxl == null)
            {
                m_outputSREDxl = OpenExcelTimesheetFile(path, name, "SRED");
            }

            string project = projectChooser.SelectedItem as string;
            string activity = activityChooser.SelectedItem as string;
            string hours = hoursEntry.Text;
            string issues = issuesList.Text;
            string date = datePicker.Value.ToShortDateString();
            if (isIRAP.Checked == true)
                SaveData(m_outputIRAPxl, date, project, activity, hours, issues);
            else
                SaveData(m_outputSREDxl, date, "SRED", activity, hours, issues);
            hoursEntry.Text = "";
            hoursEntry.Focus();
        }

        private void SaveData(ExcelFile ef, string date, string project, string activity, string hours, string issues)
        {
            if (ef == null) return; // TODO: Throw would be better here?
            if (ef[1, 1] == "" && ef[1, 2] == "")
            {
                ef[1, 1] = "Date";
                ef[1, 2] = "Project";
                ef[1, 3] = "Acitivity";
                ef[1, 4] = "Hours";
                ef[1, 5] = "Notes/Issues";
            }

            int row = 1;
            while (true)
            {
                if (ef[row, 1] == "") break;
                row++;
            }
            ef[row, 1] = date;
            ef[row, 2] = project;
            ef[row, 3] = activity;
            ef[row, 4] = hours;
            ef[row, 5] = issues;
        }

        private ExcelFile OpenExcelTimesheetFile(string path, string name, string prefix)
        {
            string fileName = path + @"\" + prefix + "_" + name + ".xlsx";
            ExcelFile newFile;

            try
            {
                newFile = new ExcelFile(fileName, 1, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open/create file named " + fileName);
                return null;
            }
            
            return newFile;
        }

        

        private void SaveConfiguration()
        {
            m_config = new Configuration();
            m_config.excelLocation = excelFileLocation.Text;
            m_config.name = userName.Text;
            m_config.selectedActivity = activityChooser.SelectedIndex;
            m_config.selectedProject = projectChooser.SelectedIndex;
            Stream dst = new FileStream("config.bin", FileMode.OpenOrCreate, FileAccess.Write);
            IFormatter form = (IFormatter)new BinaryFormatter();
            form.Serialize(dst, (object)m_config);
            dst.Close();
        }


        private void chooseExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "(Excel Workbooks)|*.xlsx|(Excel Files)|*.xls";
            dlg.FilterIndex = 1;
            dlg.Multiselect = false;
            DialogResult result = dlg.ShowDialog();

            if (result.ToString() == "OK")
            {
                String filename = dlg.FileName;
                excelFileLocation.Text = filename;
                SaveConfiguration();
                LoadSettingsFromExcel();
                FileInfo fi = new FileInfo(filename);
                m_outputDirectory = fi.Directory.ToString();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveData(m_outputIRAPxl, "IRAP");
            SaveData(m_outputSREDxl, "SRED");

            base.OnFormClosing(e);
        }

        private void SaveData(ExcelFile target, string type)
        {
            try
            {
                if (target != null)
                {
                    target.Save();
                    target.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving/closing " + type + " file " + e.Message);
            }
        }

        private void isIRAP_CheckedChanged(object sender, EventArgs e)
        {
            if (isIRAP.Checked)
            {
                projectChooser.Enabled = true;
            }
            else
            {
                projectChooser.Enabled = false;
            }
        }
    }
}

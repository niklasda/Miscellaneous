
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Dahlex.Settings;
using DahlexThemeEditor;

namespace Dahlex
{
    public partial class fOptions : Form
    {
        public fOptions()
        {
            InitializeComponent();
        }
        
        private Options lastOldOptions;
        
        public DialogResult ShowMe(Options oldOptions)
        {
            lastOldOptions = oldOptions;
            
            tbName.Text = oldOptions.PlayerName;
            cbSmartRobots.Checked = oldOptions.SmartRobots;
            cbToxicHeaps.Checked = oldOptions.ToxicHeaps;
            numStartLevel.Value = oldOptions.StartLevel;
            numStartBombs.Value = oldOptions.StartBombs;
            numStartTeleports.Value = oldOptions.StartTeleports;

            showThemeNames(oldOptions.ThemeName);

            return ShowDialog();
        }

        private void showThemeNames(string selectedTheme)
        {
            string cfg = ConfigurationManager.AppSettings["themesfolder"];

            string themesFolder = @Application.StartupPath + @"\" + cfg + @"\";
            DirectoryInfo themesFolderInfo = new DirectoryInfo(themesFolder);
            DirectoryInfo[] dinfs = themesFolderInfo.GetDirectories();
            int index = 0;
            foreach(DirectoryInfo di in dinfs)
            {
                cbThemes.Items.Add(di);
                if(di.Name.Equals(selectedTheme))
                {
                    cbThemes.SelectedIndex = index;
                }
                index++;
            }
        }

        public Options GetOptions()
        {
            Options options = new Options();
            options.PlayerName = tbName.Text;
            options.ThemeName = cbThemes.Text;
            options.SmartRobots = cbSmartRobots.Checked;
            options.ToxicHeaps = cbToxicHeaps.Checked;
            options.StartLevel = (int)numStartLevel.Value;
            options.StartBombs = (int)numStartBombs.Value;
            options.StartTeleports = (int)numStartTeleports.Value;

            options.BoardSize = lastOldOptions.BoardSize;
 
            return options;
        }

        private void bSave_Click(object sender, System.EventArgs e)
        {
            OptionsManager om = new OptionsManager();
            om.SaveLocalOptions( GetOptions() );
        }

        private void bLaunchEditor_Click(object sender, System.EventArgs e)
        {
            DirectoryInfo dir = cbThemes.SelectedItem as DirectoryInfo;
            fDahlexThemeEditor editor = new fDahlexThemeEditor(true, dir);
            editor.Show();
        }

    }
}
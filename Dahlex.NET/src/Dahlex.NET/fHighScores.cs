using System.Windows.Forms;
using Dahlex.HighScores;
using Dahlex.Settings;

namespace Dahlex
{
    public partial class fHighScores : Form
    {
        private fHighScores()
        {
            InitializeComponent();
        }

        private static Options _gameOptions;
        public static void ShowMe(Options gameOptions)
        {
            _gameOptions = gameOptions;
            fHighScores highScores = new fHighScores();
            highScores.ShowDialog();
        }

        private void fHighScores_Load(object sender, System.EventArgs e)
        {
            HighScoreManager man = new HighScoreManager(_gameOptions);
            ListViewItem[] items = man.GetHighScoresForListView();
            
            lvLocal.Items.AddRange(items);
         
        }
    }
}
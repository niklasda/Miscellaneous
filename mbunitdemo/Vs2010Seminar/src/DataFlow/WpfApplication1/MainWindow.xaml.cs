using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Navigation;
using ClassLibrary1;
using ClassLibrary1.EF;
using ClassLibrary1.PLinq;
using ClassLibrary1.News;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IList<Person> plist = new List<Person>();
            plist.Add(new Person());
            DataAccess da = new DataAccess();
            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.ItemsSource = plist;
            dataGrid1.ItemsSource = da.GetAll().ToList();
            
            setupJump();
        }
        private void setupJump()
        {
            if (!TaskbarManager.IsPlatformSupported)
            {
                MessageBox.Show("This demo requires to be run on Windows 7", "Demo needs Windows 7");
                Environment.Exit(0);
            }

            // Path to Windows system folder
            string systemFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.System);
            string path = Path.Combine(systemFolder, "notepad.exe");

            JumpList jumpList = JumpList.CreateJumpList();

            JumpListLink link = new JumpListLink(path, "Open Notepad");

            link.IconReference = new IconReference(Path.Combine(systemFolder, "notepad.exe"), 0);

            jumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
            jumpList.AddUserTasks(link);
            
            // extension needs to be registered
            jumpList.AddToRecent("MyRecentFile.MyExt");
            jumpList.Refresh();
        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            calendar1.SelectedDate = datePicker1.SelectedDate;
        }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            datePicker1.SelectedDate = calendar1.SelectedDate;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ArgsStuff ns = new ArgsStuff();
            for (int i = 0; i < 10*1000*1000*20; i++)
            {
                ns.MyMethod("asdasd", 123);
            }
        }
    }
}

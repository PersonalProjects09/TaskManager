using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskLib;

namespace Task_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GUITaskController controller;

        private TaskDetailGUI SelectedTask => controller.TaskList[TaskListBox.SelectedIndex];

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += new RoutedEventHandler(CheckVersion);

            InitializeComponent();

            controller = new GUITaskController();
            //Generate task list with event handlers from this window
            controller.GenerateTaskList(this);

            TaskListBox.ItemsSource = controller.TaskList;
            TaskListBox.KeyDown += new KeyEventHandler(TaskListBox_KeyDown);
            PasswordListBox.KeyDown += new KeyEventHandler(PasswordListBox_KeyDown);

            TaskListBox.SelectedIndex = 0;
        }

        #region KeyDowns
        private void TaskListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                controller.RunTask(TaskListBox.SelectedIndex);
                //SelectedTask.RunTask();
            }
        }

        private void PasswordListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.C) &&
                (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                CopyPassword();
            }
        }
        #endregion

        #region Buttons
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            controller.RunTask(TaskListBox.SelectedIndex);
            //SelectedTask.RunTask();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTask.EditOptions != null)
            {
                SelectedTask.EditOptions.EditTask.Run();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnPasswordCopy_Click(object sender, RoutedEventArgs e)
        {
            CopyPassword();
        }

        #endregion

        #region TaskEditHandlers
        public void EditLinks()
        {
            TaskMethods.StartProcess("Resources\\Links.txt");
        }

        public void OpenLog()
        {
            TaskMethods.StartProcess("C:\\Windows\\Logs\\CBS\\CBS.log");
        }

        #endregion

        #region TaskCompleteHandlers
        public void LoadWIFIPasswords()
        {
            //https://youtu.be/prVHU1fLR20?t=126

            var contents = File.ReadAllLines(TaskMethods.CD + "/Data/passwords.txt");

            List<string> partsList = new List<string>();
            foreach (string line in contents)
            {
                var parts = line.Split(":");

                //If both entries are valid (not null)
                if (!(String.IsNullOrWhiteSpace(parts[0]) || String.IsNullOrWhiteSpace(parts[1])))
                {
                    parts[0] = parts[0].Trim();
                    parts[1] = parts[1].Trim();

                    partsList.Add("Wifi Network: " + parts[0]);
                    partsList.Add("Password: " + parts[1]);
                }
            }

            btnPasswordCopy.Background = btnEdit.Background;
            PasswordListBox.Visibility = Visibility.Visible;
            btnPasswordCopy.Visibility = Visibility.Visible;
            PasswordListBox.ItemsSource = partsList;
        }

        #endregion

        private void CheckVersion(object sender, RoutedEventArgs e)
        {
            if (!VersionChecker.IsLatestVersion())
            {
                MessageBoxResult result = MessageBox.Show("Update now?",
                    "Update needed!", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    VersionChecker.Update();
                    Close();
                }    
            }
        }

        private void CopyPassword()
        {
            if (PasswordListBox.SelectedItem != null)
            {
                btnPasswordCopy.Background = Brushes.LightGreen;
                Clipboard.SetText(PasswordListBox.SelectedItem.ToString());
            }
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PasswordListBox.Visibility = Visibility.Collapsed;
            btnPasswordCopy.Visibility = Visibility.Collapsed;
            PasswordListBox.ItemsSource = null;

            if (SelectedTask.EditOptions != null)
            {
                btnEdit.Visibility = Visibility.Visible;
                btnEdit.Content = SelectedTask.EditOptions.EditText;
            }
            else
            {
                btnEdit.Visibility = Visibility.Collapsed;
            }
            if (SelectedTask.RequiresAdmin)
            {
                btnRun.Content = "Run Selected Task (A)";
            }
            else
            {
                btnRun.Content = "Run Selected Task";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
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
        private string PasswordList { get; set; }

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Loaded += new RoutedEventHandler(CheckVersion);
            Closed += MainWindow_Closed;

            InitializeComponent();

            controller = new GUITaskController();
            //Generate task list with event handlers from this window
            controller.GenerateTaskList(this);

            TaskListBox.ItemsSource = controller.TaskList;
            TaskListBox.KeyDown += new KeyEventHandler(TaskListBox_KeyDown);
            PasswordListBox.KeyDown += new KeyEventHandler(PasswordListBox_KeyDown);

            TaskListBox.SelectedIndex = 0;
            PasswordList = String.Empty;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            File.Delete(TaskMethods.CD + "/Data/Passwords.txt");
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
            string path = "Resources\\Links.txt";
            if (File.Exists(path))
            {
                TaskMethods.StartProcess(path);
            }
            else
            {
                FileStream f = File.Create(path);
                f.Close();
                TaskMethods.StartProcess(path);
            }
                
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

            var contents = File.ReadAllLines(TaskMethods.CD + "/Data/Passwords.txt");

            List<string> partsList = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (string line in contents)
            {
                var parts = line.Split(":");

                //If both entries are valid (not null)
                if (!(String.IsNullOrWhiteSpace(parts[0]) || String.IsNullOrWhiteSpace(parts[1])))
                {
                    parts[0] = parts[0].Trim();
                    parts[1] = parts[1].Trim();

                    partsList.Add("Wifi Network: " + parts[0]);
                    sb.Append(parts[0] + ": ");
                    partsList.Add("Password: " + parts[1]);
                    sb.AppendLine(parts[1]);
                }
            }

            btnPasswordCopy.Background = btnEdit.Background;
            PasswordListBox.Visibility = Visibility.Visible;
            btnPasswordCopy.Visibility = Visibility.Visible;
            PasswordListBox.ItemsSource = partsList;
            PasswordList = sb.ToString();
        }

        #endregion

        private void CheckVersion(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(CheckVersionThreaded);
            thread.Start();
        }

        private void CheckVersionThreaded()
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
            btnPasswordCopy.Background = Brushes.LightGreen;
            Clipboard.SetText(PasswordList);
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

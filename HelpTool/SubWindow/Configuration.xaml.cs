using HelpTool.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace HelpTool.SubWindow
{
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SharedObjects.DbHost = Host.Text;
                SharedObjects.DbName = DbName.Text;
                SharedObjects.DbNameLogin = DbNameLogin.Text;
                SharedObjects.DbUser = DbUser.Text;
                SharedObjects.DbPass = DbPassword.Password;
                SharedObjects.Context!.Database.SetConnectionString("Server=" + SharedObjects.DbHost + "; Database=" + SharedObjects.DbName + "; Uid=" + SharedObjects.DbUser + "; Pwd=" + SharedObjects.DbPass);
                if (SharedObjects.Context!.Database.CanConnect())
                {
                    SharedObjects.IsConfigured = true;
                    MessageBox.Show(Functions.Word("Success_DbConnect"), Functions.Word("Success"), MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show(Functions.Word("Error_DbCredConnection"), Functions.Word("Error"), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

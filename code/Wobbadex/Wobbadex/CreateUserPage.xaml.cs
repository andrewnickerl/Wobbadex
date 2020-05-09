using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WobbadexClassLibrary;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Wobbadex
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateUserPage : Page
    {
        private readonly string connectionString =
        @"Server = DESKTOP-QA4COAS\SQLEXPRESS; Database = Wobbadex; Trusted_Connection = True";

        public CreateUserPage()
        {
            this.InitializeComponent();
        }

        private void CreateAccount(object sender, RoutedEventArgs e)
        {
            /*creates repository of users and searches to ensure no duplicate
            usernames will be allowed to be created in the database*/
            bool uniqueUser = true;
            UserRepository userRepository = new UserRepository();
            foreach(var user in userRepository.GetRepo())
            {
                if(usernameBox.Text == user.UserName)
                {
                    uniqueUser = false;
                }
            }

            if (pwBox.Password != ""
                && pwBox.Password == confirmPwBox.Password
                && pwBox.Password.Length >= 8
                && uniqueUser == true)
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO wobbaUsers (username, password_hash) " +
                        $"VALUES (\'{usernameBox.Text}\', \'{ToHash(pwBox.Password)}\')";
                    command.ExecuteNonQuery();
                }
                SolidColorBrush greenBrush = new SolidColorBrush(Colors.Green);
                statusText.Foreground = greenBrush;
                statusText.Text = "Account created successfully. Returning to the login page.";

                this.Frame.Navigate(typeof(MainPage), null);
            }
            else if (uniqueUser == false)
            {
                SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                statusText.Foreground = redBrush;

                statusText.Text = "That username is already taken.";
                pwBox.Password = "";
                confirmPwBox.Password = "";
            }
            else if (pwBox.Password != confirmPwBox.Password)
            {
                SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                statusText.Foreground = redBrush;

                statusText.Text = "Passwords must match.";
                pwBox.Password = "";
                confirmPwBox.Password = "";
            }            
            else
            {
                SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                statusText.Foreground = redBrush;

                statusText.Text = "Please enter a valid password " +
                    "(8 or more alphanumeric characters).";
                pwBox.Password = "";
                confirmPwBox.Password = "";
            }            
        }

        public string ToHash(string pw)
        {
            byte[] b = Encoding.ASCII.GetBytes(pw);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }
    }
}

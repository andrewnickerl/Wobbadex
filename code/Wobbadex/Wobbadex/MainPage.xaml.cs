using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WobbadexClassLibrary;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.UI;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Wobbadex
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            if(userRepository.GetRepo().Exists(u => u.UserName == $"{usernameBox.Text}"))
            {    
                WobbaUser user = userRepository.GetRepo()
                    .Find(u => u.UserName == $"{usernameBox.Text}");

                if (user.PwHash == ToHash(pwBox.Password))
                {
                    this.Frame.Navigate(typeof(SearchPage), null);
                }
                else
                {
                    SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                    statusText.Foreground = redBrush;

                    statusText.Text = "Invalid credentials. " +
                        "Please try again or create a new account.";
                    pwBox.Password = "";
                }
            }
            else
            {
                SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                statusText.Foreground = redBrush;

                statusText.Text = "Invalid credentials. " +
                    "Please try again or create a new account.";
                pwBox.Password = "";
            }
                     
        }

        public string ToHash(string pw)
        {
            byte[] b = Encoding.ASCII.GetBytes(pw);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        private void CreateUser(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateUserPage), null);
        }       
    }
}

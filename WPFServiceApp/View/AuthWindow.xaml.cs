using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFServiceApp.ViewModel;

namespace WPFServiceApp.View
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            this.DataContext = new AuthViewModel(this);

            this.Background = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
            InitializeComponent();

            string themeName = "AuthTheme";

            var uri = new Uri(@"View/" + themeName + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
//using ConfigMgrExample.ConfigManagers;


namespace ConfigMgrExample
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var persons = (ConfigMgrExample.ConfigManagers.PersonConfigurationManager)ConfigurationManager.GetSection("persons");
            foreach(ConfigMgrExample.ConfigManagers.Person person in persons.Persons)
            {
                lstPersons.Items.Add(person.Name);
            }
        }
    }
}

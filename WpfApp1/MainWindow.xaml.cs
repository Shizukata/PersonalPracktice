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
using WpfApp1.GroupZ;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> personList = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            FillPlace();
            LvPersons.ItemsSource = personList.ToList();
        }
        public void FillPlace()
        {
            personList.Add(new Person
            {
                Name="Бивень", 
                Age="5",
                City="KaZan"
            });
            personList.Add(new Person
            {
                Name = "Мамонт",
                Age = "50",
                City = "Kazan"
            });
            personList.Add(new Person
            {
                Name = "Евгений",
                Age = "46",
                City = "Питер"
            });
            personList.Add(new Person
            {
                Name = "Евгений",
                Age = "46",
                City = "Питер"
            });
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(TbName.Text == String.Empty || TbAge.Text == String.Empty || TbCity.Text == String.Empty)
            {
                MessageBox.Show("Поля пустые");
                return;
            }
            personList.Add(new Person
            {
                Name = TbName.Text,
                Age = TbAge.Text,
                City = TbCity.Text
            });
            Refresh();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(LvPersons.SelectedItem == null)
            {
                MessageBox.Show("Выберите объект для удаления");
                return;
            }
            var selectedItem = LvPersons.SelectedItem as Person;
            personList.Remove(selectedItem);
            Refresh();
        }
        private void Refresh()
        {
            LvPersons.ItemsSource = personList.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (LvPersons.SelectedItem == null)
            {
                MessageBox.Show("Выберите объект для редактирования");
                return;
            }
            var selectedItem = LvPersons.SelectedItem as Person;
            TbRedName.Text = selectedItem.Name;
            TbRedAge.Text = selectedItem.Age;
            TbRedCity.Text = selectedItem.City;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TbRedName.Text == String.Empty || TbRedAge.Text == String.Empty || TbRedCity.Text == String.Empty)
            {
                MessageBox.Show("Поля пустые");
                return;
            }
            var selectedItem = LvPersons.SelectedItem as Person;
            selectedItem.Name = TbRedName.Text;
            selectedItem.Age = TbRedAge.Text;
            selectedItem.City = TbRedCity.Text;
            Refresh();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TbRedName.Clear();
            TbRedAge.Clear();
            TbRedCity.Clear();
        }
    }
}

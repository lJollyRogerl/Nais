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
using TestForNice.SerializationApproach;
using Instances;

namespace TestForNice
{
    public partial class MainWindow : Window
    {
        //the field is storing all the employees after they've been deserialized
        private List<Employee> listOfEmployes { get; set; } = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
        }
       

        //all the try/catch logics are implementing within thw SaveLoader class
        private void FileLoad_Click(object sender, RoutedEventArgs e)
        {
            //Here you can chose either XMLSerializer needed or BinarySerializer one
            SaverLoader loader = new SaverLoader(new BinarySerializer());
            listOfEmployes = loader.Load<List<Employee>>();
            dgEmployees.ItemsSource = listOfEmployes;
        }
        private void FileSave_Click(object sender, RoutedEventArgs e)
        {
            //Here you can chose either XMLSerializer needed or BinarySerializer one
            SaverLoader saver = new SaverLoader(new BinarySerializer());
            saver.Save<List<Employee>>((List<Employee>)dgEmployees.ItemsSource);
        }

        //this event has been registered in order to refresh the data 
        //in the awerage salary column after the wage rate was changed
        private void dgEmployees_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            listOfEmployes = (List<Employee>)dgEmployees.ItemsSource;
            dgEmployees.ItemsSource = null;
            dgEmployees.ItemsSource = listOfEmployes;
        }

        //pretty obvious
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //displays all the data, which's been read from a file. Ordered by ID
        private void btnShowAllEmployee_Click(object sender, RoutedEventArgs e)
        {
            dgEmployees.ItemsSource = listOfEmployes
                .OrderBy(emp => emp.Id)
               .ToList(); 
        }
        //displays sorted data. It's sorted by the average salaries of the employees
        private void sortEmployee_Click(object sender, RoutedEventArgs e)
        {
            dgEmployees.ItemsSource = listOfEmployes
               .OrderByDescending(emp => emp.AverageSalary)
               .ToList();
        }
        //Shows the top 3 workers with the boggest average salaries
        private void btnShowTop3_Click(object sender, RoutedEventArgs e)
        {
            dgEmployees.ItemsSource = listOfEmployes
                .OrderByDescending(emp => emp.AverageSalary)
                .Take(3)
                .ToList();
        }
        //Shows the top 5 workers with the lowest average salaries
        private void btnShowLast5_Click(object sender, RoutedEventArgs e)
        {
            dgEmployees.ItemsSource = listOfEmployes
               .OrderBy(emp => emp.AverageSalary)
               .Take(5)
               .ToList();
        }
    }
}

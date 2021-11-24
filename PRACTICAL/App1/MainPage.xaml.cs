using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
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
        private List<Employee> Employees;
        public class Employee
        {
            public Employee(string name, string role, int birthyear)
            {
                Name = name;
                Role = role;
                Birthyear = birthyear;
            }
            public string Name { get; set; }
            public string Role { get; set; }
            public int Birthyear { get; set; }

        }

        private void GetEmployeeInfo()
        {
            using (StreamReader file = File.OpenText(".\\employee.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jObject = (JObject)JToken.ReadFrom(reader);

            }
            var employee = from p in JObject["employee"]
                           select new Employee((string)p["Name"], (string)p["Role"], (int)p["Birthyear"]);
            Employee = employee.ToList<Employee>;

        }

        private void read_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

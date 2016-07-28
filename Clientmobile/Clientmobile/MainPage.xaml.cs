using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;


namespace Clientmobile
{
    public partial class MainPage : ContentPage
    {
      
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonPost_OnClicked(object sender, EventArgs e)
        {
            PostEmployees();
        }

        private void ButtonPut_OnClicked(object sender, EventArgs e)
        {
            PutEmployees();
        }

        private void ButtonDelete_OnClicked(object sender, EventArgs e)
        {
           DeleteEmployees();
        }

        private void ButtonGet_OnClicked(object sender, EventArgs e)
        {
            GetEmployees();
        }

        public async void GetEmployees()
        {
            var Url = "http://localhost:51950/api/Employees/";

            var client = new HttpClient();

            var json = await client.GetStringAsync(Url);

            List<Employee> Employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            MainListView.ItemsSource = Employees;


        }
        public async void PostEmployees()
        {
            var Url = "http://localhost:51950/api/Employees/";
            Employee E = new Employee();
            E.Name = Txtname.Text;
            E.Age = int.Parse(Txtage.Text);

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(E);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await client.PostAsync(Url, httpContent);
        }
        public async void  PutEmployees()
        {
            var Url = "http://localhost:51950/api/Employees/";
            Employee E = new Employee();
            E.Name = Txtname1.Text;
            E.Age = Int32.Parse(Txtage1.Text);
            E.EmployeeId= Int32.Parse(TxtEmployeeId.Text);
            var id = Int32.Parse(TxtEmployeeId.Text);
            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(E);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await client.PutAsync(Url+id.ToString(), httpContent);
        }
        public async void DeleteEmployees()
        {
            var Url = "http://localhost:51950/api/Employees/";

            var id = TxtEmployeeId1.Text;
            var client = new HttpClient();

            var json = await client.DeleteAsync(Url + id);
        }
    }
}

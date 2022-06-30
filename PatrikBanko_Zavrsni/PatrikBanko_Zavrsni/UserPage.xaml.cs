using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;

namespace PatrikBanko_Zavrsni
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        List<ModelUsers> userList = new List<ModelUsers>();
        public UserPage()
        {
            InitializeComponent();
            GetJsonAsync();
        }

        public async Task GetJsonAsync()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var message = jsonObject["msg"];
                var data = jsonObject["data"];
                var jsonArray = JArray.Parse(data.ToString());

                foreach (var token in jsonArray)
                {
                    ModelUsers model = new ModelUsers();
                    string id_user = token["id_user"].ToString();
                    string email = token["email"].ToString();
                    string create_time = token["create_time"].ToString();
                    model.id_user = id_user;
                    model.email = email;
                    model.create_time = create_time;
                    userList.Add(model);
                }
            }
            testListView.ItemsSource = userList;
        }

        public async Task GetJsonAsyncAscending()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=users");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var message = jsonObject["msg"];
                var data = jsonObject["data"];
                var jsonArray = JArray.Parse(data.ToString());

                foreach (var token in jsonArray)
                {
                    ModelUsers model = new ModelUsers();
                    string id_user = token["id_user"].ToString();
                    string email = token["email"].ToString();
                    string create_time = token["create_time"].ToString();
                    model.id_user = id_user;
                    model.email = email;
                    model.create_time = create_time;
                    userList.Add(model);
                }
            }
            var sorting = userList.OrderBy(model => model.id_user).ToList();
            testListView.ItemsSource = sorting;
        }

        public async Task GetJsonAsyncDescending()
        {
            var uri = new Uri("https://www.idt.mdh.se/personal/plt01/languide/?get=results");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                string json = content.ToString();
                var jsonObject = JObject.Parse(json);
                var status = jsonObject["error"];
                var message = jsonObject["msg"];
                var data = jsonObject["data"];
                var jsonArray = JArray.Parse(data.ToString());

                foreach (var token in jsonArray)
                {
                    ModelUsers model = new ModelUsers();

                    string id_user = token["id_user"].ToString();
                    string email = token["email"].ToString();
                    string create_time = token["create_time"].ToString();
                    model.id_user = id_user;
                    model.email = email;
                    model.create_time = create_time;
                    userList.Add(model);
                }
            }
            var sorting = userList.OrderByDescending(model => model.id_user).ToList();
            testListView.ItemsSource = sorting;
        }

        private void ButtonDescending(object sender, EventArgs e)
        {
            GetJsonAsyncDescending();
        }

        private void ButtonAscending(object sender, EventArgs e)
        {
            GetJsonAsyncAscending();
        }


        private void SearchBar_TextChanged_email(object sender, TextChangedEventArgs e)
        {
            var search = userList.Where(user => user.email.StartsWith(e.NewTextValue)).ToList();
            testListView.ItemsSource = search;
        }

        private void SearchBar_TextChanged_usr(object sender, TextChangedEventArgs e)
        {
            var search = userList.Where(user => user.id_user.StartsWith(e.NewTextValue)).ToList();
            testListView.ItemsSource = search;
        }
    }
}
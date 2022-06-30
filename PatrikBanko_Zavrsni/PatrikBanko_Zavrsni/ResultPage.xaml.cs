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
    public partial class ResultPage : ContentPage
    {
        List<ModelResults> modelList = new List<ModelResults>();
        public ResultPage()
        {
            InitializeComponent();
            GetJsonAsync();
        }

        public async Task GetJsonAsync()
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
                    ModelResults model = new ModelResults();
                    string id_user = token["id_user"].ToString();
                    string email = token["email"].ToString();
                    string create_time = token["create_time"].ToString();
                    string id_exercise = token["id_exercise"].ToString();
                    string result_percent = token["result_percent"].ToString();
                    string result_score = token["result_score"].ToString();
                    string result_max = token["result_max"].ToString();
                    string skill = token["skill"].ToString();
                    string language = token["language"].ToString();
                    string result_date = token["result_date"].ToString();
                    model.id_user = id_user;
                    model.email = email;
                    model.create_time = create_time;
                    model.id_exercise = id_exercise;
                    model.result_percent = result_percent;
                    model.result_score = result_score;
                    model.result_max = result_max;
                    model.skill = skill;
                    model.language = language;
                    model.result_date = result_date;
                    modelList.Add(model);
                }
            }
            testListView.ItemsSource = modelList;
        }

        public async Task GetJsonAsyncAsc()
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
                    ModelResults model = new ModelResults();
                    string id_user = token["id_user"].ToString();
                    string email = token["email"].ToString();
                    string create_time = token["create_time"].ToString();
                    string id_exercise = token["id_exercise"].ToString();
                    string result_percent = token["result_percent"].ToString();
                    string result_score = token["result_score"].ToString();
                    string result_max = token["result_max"].ToString();
                    string skill = token["skill"].ToString();
                    string language = token["language"].ToString();
                    string result_date = token["result_date"].ToString();
                    model.id_user = id_user;
                    model.email = email;
                    model.create_time = create_time;
                    model.id_exercise = id_exercise;
                    model.result_percent = result_percent;
                    model.result_score = result_score;
                    model.result_max = result_max;
                    model.skill = skill;
                    model.language = language;
                    model.result_date = result_date;
                    modelList.Add(model);
                }
            }
            IEnumerable<ModelResults> query = modelList.OrderBy(modelList => modelList.id_user).ToList();
            testListView.ItemsSource = query;
        }

        public async Task GetJsonAsyncDesc()
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
                    ModelResults model = new ModelResults();
                    string id_user = token["id_user"].ToString();
                    string email = token["email"].ToString();
                    string create_time = token["create_time"].ToString();
                    string id_exercise = token["id_exercise"].ToString();
                    string result_percent = token["result_percent"].ToString();
                    string result_score = token["result_score"].ToString();
                    string result_max = token["result_max"].ToString();
                    string skill = token["skill"].ToString();
                    string language = token["language"].ToString();
                    string result_date = token["result_date"].ToString();
                    model.id_user = id_user;
                    model.email = email;
                    model.create_time = create_time;
                    model.id_exercise = id_exercise;
                    model.result_percent = result_percent;
                    model.result_score = result_score;
                    model.result_max = result_max;
                    model.skill = skill;
                    model.language = language;
                    model.result_date = result_date;
                    modelList.Add(model);
                }
            }
            IEnumerable<ModelResults> query = modelList.OrderByDescending(modelList => modelList.id_user).ToList();
            testListView.ItemsSource = query;
        }

        private void Button_Clicked_Asc(object sender, EventArgs e)
        {
            GetJsonAsyncAsc();
        }

        private void Button_Clicked_Desc(object sender, EventArgs e)
        {
            GetJsonAsyncDesc();
        }
    }
}
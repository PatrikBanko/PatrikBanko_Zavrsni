using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace PatrikBanko_Zavrsni
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        List<ModelResults> modelList = new List<ModelResults>();
        public LanguagePage()
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

                    string language = token["language"].ToString();
                    model.language = language;

                    modelList.Add(model);

                }
                Debug.WriteLine(message);
            }

            //List<ModelResults> sortedLanguages = modelList.Distinct().ToList();
            //testListView.ItemsSource = sortedLanguages;


            var distinctResults = modelList.GroupBy(result => result.language).Select(u => u.First()).ToList();
            testListView.ItemsSource = distinctResults;

            //testListView.ItemsSource = modelList.Distinct().ToList();


        }

        public async Task GetJsonAsync1()
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

                    string language = token["language"].ToString();
                    model.language = language;

                    modelList.Add(model);

                }
                Debug.WriteLine(message);
            }

            var distinctResults = modelList.GroupBy(result => result.language).Select(u => u.First()).ToList();
            var distinctResults1 = distinctResults.OrderByDescending(model => model.language).ToList();
            testListView.ItemsSource = distinctResults1;
        }

        public async Task GetJsonAsync2()
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

                    string language = token["language"].ToString();
                    model.language = language;

                    modelList.Add(model);

                }
                Debug.WriteLine(message);
            }

            var distinctResults = modelList.GroupBy(result => result.language).Select(u => u.First()).ToList();
            var distinctResults1 = distinctResults.OrderBy(model => model.language).ToList();
            testListView.ItemsSource = distinctResults1;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GetJsonAsync1();
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            GetJsonAsync2();
        }
    }
}
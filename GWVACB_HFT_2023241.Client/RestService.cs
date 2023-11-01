using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GWVACB_HFT_2023241.Client
{
    public class RestService
    {
        private HttpClient client;

        public RestService(string baseurl, string pingableEndpoint = "swagger")
        {
            var isOk = false;
            do
            {
                isOk = Ping(baseurl + pingableEndpoint);
            } while (isOk == false);

            Init(baseurl);
        }

        private bool Ping(string url)
        {
            try
            {
                var wc = new WebClient();
                wc.DownloadData(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Init(string baseurl)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue
                    ("application/json"));
            try
            {
                client.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException)
            {
                throw new ArgumentException("Endpoint is not available!");
            }
        }

        public List<T> Get<T>(string endpoint)
        {
            var items = new List<T>();
            var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            return items;
        }

        public T GetSingle<T>(string endpoint)
        {
            var item = default(T);
            var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            return item;
        }

        public T Get<T>(int id, string endpoint)
        {
            var item = default(T);
            var response = client.GetAsync(endpoint + "/" + id).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            else
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            return item;
        }

        public void Post<T>(T item, string endpoint)
        {
            var response =
                client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }

        public void Delete(int id, string endpoint)
        {
            var response =
                client.DeleteAsync(endpoint + "/" + id).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }

        public void Put<T>(T item, string endpoint)
        {
            var response =
                client.PutAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
                throw new ArgumentException(error.Msg);
            }

            response.EnsureSuccessStatusCode();
        }
    }

    public class RestExceptionInfo
    {
        public string Msg { get; set; }
    }
}
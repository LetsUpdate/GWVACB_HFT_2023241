using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GWVACB_HFT_2023241.WPFClient
{ 
public class RestService
{
    HttpClient client;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public RestService(string baseurl, string pingableEndpoint = "swagger")
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        bool isOk = false;
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
            WebClient wc = new WebClient();
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
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
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

    public async Task<List<T>> GetAsync<T>(string endpoint)
    {
        List<T> items = new List<T>();
        HttpResponseMessage response = await client.GetAsync(endpoint);
        if (response.IsSuccessStatusCode)
        {
            items = await response.Content.ReadAsAsync<List<T>>();
        }
        else
        {
            var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
            throw new ArgumentException(error.Msg);
        }
        return items;
    }

    public List<T> Get<T>(string endpoint)
    {
        List<T> items = new List<T>();
        HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();
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

    public async Task<T> GetSingleAsync<T>(string endpoint)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        T item = default(T);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        HttpResponseMessage response = await client.GetAsync(endpoint);
        if (response.IsSuccessStatusCode)
        {
            item = await response.Content.ReadAsAsync<T>();
        }
        else
        {
            var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
            throw new ArgumentException(error.Msg);
        }
        return item;
    }

    public T GetSingle<T>(string endpoint)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        T item = default(T);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();
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

    public async Task<T> GetAsync<T>(int id, string endpoint)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        T item = default(T);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        HttpResponseMessage response = await client.GetAsync(endpoint + "/" + id.ToString());
        if (response.IsSuccessStatusCode)
        {
            item = await response.Content.ReadAsAsync<T>();
        }
        else
        {
            var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
            throw new ArgumentException(error.Msg);
        }
        return item;
    }

    public T Get<T>(int id, string endpoint)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        T item = default(T);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        HttpResponseMessage response = client.GetAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();
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

    public async Task PostAsync<T>(T item, string endpoint)
    {
        HttpResponseMessage response =
            await client.PostAsJsonAsync(endpoint, item);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
            throw new ArgumentException(error.Msg);
        }
        response.EnsureSuccessStatusCode();
    }

    public void Post<T>(T item, string endpoint)
    {
        HttpResponseMessage response =
            client.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
        {
            var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
            throw new ArgumentException(error.Msg);
        }
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id, string endpoint)
    {
        HttpResponseMessage response =
            await client.DeleteAsync(endpoint + "/" + id.ToString());

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
            throw new ArgumentException(error.Msg);
        }

        response.EnsureSuccessStatusCode();
    }

    public void Delete(int id, string endpoint)
    {
        HttpResponseMessage response =
            client.DeleteAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();

        if (!response.IsSuccessStatusCode)
        {
            var error = response.Content.ReadAsAsync<RestExceptionInfo>().GetAwaiter().GetResult();
            throw new ArgumentException(error.Msg);
        }

        response.EnsureSuccessStatusCode();
    }

    public async Task PutAsync<T>(T item, string endpoint)
    {
        HttpResponseMessage response =
            await client.PutAsJsonAsync(endpoint, item);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsAsync<RestExceptionInfo>();
            throw new ArgumentException(error.Msg);
        }

        response.EnsureSuccessStatusCode();
    }

    public void Put<T>(T item, string endpoint)
    {
        HttpResponseMessage response =
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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public RestExceptionInfo()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
    public string Msg { get; set; }
}
class NotifyService
{
    private HubConnection conn;

    public NotifyService(string url)
    {
        conn = new HubConnectionBuilder()
            .WithUrl(url)
            .Build();

        conn.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await conn.StartAsync();
        };
    }

    public void AddHandler<T>(string methodname, Action<T> value)
    {
        conn.On<T>(methodname, value);
    }

    public async void Init()
    {
        await conn.StartAsync();
    }

}

    public class RestCollection<T> : INotifyCollectionChanged, IEnumerable<T>
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        NotifyService notify;
        RestService rest;
        List<T> items;
        bool hasSignalR;
        Type type = typeof(T);

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public RestCollection(string baseurl, string endpoint, string hub = null)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            hasSignalR = hub != null;
            this.rest = new RestService(baseurl, endpoint);
            if (hub != null)
            {
                this.notify = new NotifyService(baseurl + hub);
                this.notify.AddHandler<T>(type.Name + "Created", (T item) =>
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    items.Add(item);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                });
                this.notify.AddHandler<T>(type.Name + "Deleted", (T item) =>
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
                    var element = items.FirstOrDefault(t => t.Equals(item));
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    if (element != null)
                    {
                        items.Remove(item);
                        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }
                    else
                    {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                        Init();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    }

                });
                this.notify.AddHandler<T>(type.Name + "Updated", (T item) =>
                {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    Init();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                });

                this.notify.Init();
            }
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Init();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private async Task Init()
        {
            items = await rest.GetAsync<T>(typeof(T).Name);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (items != null)
            {
                return items.GetEnumerator();
            }
            else return new List<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (items != null)
            {
                return items.GetEnumerator();
            }
            else return new List<T>().GetEnumerator();
        }

        public void Add(T item)
        {
            if (hasSignalR)
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                this.rest.PostAsync(item, typeof(T).Name);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            else
            {
                this.rest.PostAsync(item, typeof(T).Name).ContinueWith((t) =>
                {
                    Init().ContinueWith(z =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        });
                    });
                });
            }

        }

        public void Update(T item)
        {
            if (hasSignalR)
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                this.rest.PutAsync(item, typeof(T).Name);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            else
            {
                this.rest.PutAsync(item, typeof(T).Name).ContinueWith((t) =>
                {
                    Init().ContinueWith(z =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        });
                    });
                });
            }
        }

        public void Delete(int id)
        {
            if (hasSignalR)
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                this.rest.DeleteAsync(id, typeof(T).Name);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            else
            {
                this.rest.DeleteAsync(id, typeof(T).Name).ContinueWith((t) =>
                {
                    Init().ContinueWith(z =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        });
                    });
                });
            }

        }
    }

}
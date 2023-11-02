using System;
using System.Collections.Generic;
using ConsoleTools;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Client
{
    public class CrudMenu<T> where T : IBaseModel
    {
        public static void Show(RestService rest)
        {
            var endpoint = typeof(T).Name;
            new ConsoleMenu()
                .Add("Create", () =>
                {
                    T obj;
                    try
                    {
                        obj = ModelHelper<T>.CreateObject();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("somehting went wrong");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }

                    rest.Post(obj, endpoint);
                })
                .Add("ReadAll", () => ShowList(rest.Get<T>(endpoint)))
                //.Add("Update", () => Update(type))
                .Add("Delete", () =>
                    Selector(rest.Get<T>(endpoint), id => rest.Delete(id, endpoint), "Select item to delete"))
                .Add("Back", ConsoleMenu.Close).Show();
        }

        private static void Selector(List<T> list, Action<int> action, string title)
        {
            var menu = new ConsoleMenu();
            menu.Configure(config => { config.Title = title; });

            foreach (var item in list)
                menu.Add(item.ToString()!, () =>
                {
                    action(item.Id);
                    menu.CloseMenu();
                });
            menu.Show();
        }

        private static void ShowList(List<T> l)
        {
            Console.WriteLine("List of {0}: ", typeof(T).Name);
            foreach (var item in l) Console.WriteLine(item);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
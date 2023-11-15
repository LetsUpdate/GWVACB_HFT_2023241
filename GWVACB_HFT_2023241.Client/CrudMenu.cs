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
                        rest.Post(obj, endpoint);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("somehting went wrong");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                })
                .Add("ReadAll", () => ShowList(rest.Get<T>(endpoint)))
                .Add("GetById", () =>
                {
                    Console.WriteLine("ID?:  ");
                    int id = int.Parse(Console.ReadLine());
                    try
                    {
                        var res = rest.Get<T>(id, endpoint);
                        if(res==null)
                            Console.WriteLine($"id: ({id}) not found!");
                        else
                            Console.WriteLine(rest.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("press any key to continue...");
                    Console.ReadKey();
                })
                .Add("Update", () => Update(rest))
                .Add("Delete", () =>
                    Selector(rest.Get<T>(endpoint), id => rest.Delete(id.Id, endpoint), "Select item to delete"))
                .Add("Back", ConsoleMenu.Close).Show();
        }

        private static void Update(RestService rest)
        {
            try
            {
                Selector(rest.Get<T>(typeof(T).Name), o =>
                {
                   o =ModelHelper<T>.UpdateObject(o);
                   rest.Put(o,typeof(T).Name);
                },"Select item to Update");
            }catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("somehting went wrong");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }


        private static void Selector(List<T> list, Action<T> action, string title)
        {
            var menu = new ConsoleMenu();
            menu.Configure(config => { config.Title = title; });

            foreach (var item in list)
                menu.Add(item.ToString()!, () =>
                {
                    action(item);
                    menu.CloseMenu();
                });
            menu.Add("Back", ConsoleMenu.Close);
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
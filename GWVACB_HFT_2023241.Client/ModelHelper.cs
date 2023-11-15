using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GWVACB_HFT_2023241.Client
{
    public static class ModelHelper<T>
    {
        private static object _RecordObject(Type t)
        {
            var instance = Activator.CreateInstance(t);
            foreach (var item in t.GetProperties())
            {
                if (item.Name.ToLower().Contains(t.Name.ToLower() + "id")) continue;
                //if itm is virtual continue
                if (item.GetGetMethod() != null && item.GetGetMethod()!.IsVirtual) continue;

                var attr = item.GetCustomAttribute<DisplayNameAttribute>();
                if (attr != null)
                    Console.Write(attr.DisplayName + ": ");
                else
                    Console.Write($"Enter {item.Name} value: ");


                var result = Console.ReadLine();

                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(instance, result);
                }
                else
                {
                    var propType = item.PropertyType;
                    var parseMethod = propType.GetMethods().First(t => t.Name.Contains("Parse"));
                    var converted = parseMethod.Invoke(null, new object[] { result });
                    item.SetValue(instance, converted);
                }
            }

            return instance;
        }

        private static T _UpdateObject(T o)
        {
            Console.WriteLine("To use current value just press enter!");
            Type t = o.GetType();
            foreach (var prop in t.GetProperties())
            {
                if (prop.Name.ToLower().Contains(t.Name.ToLower() + "id")) continue;
                if (prop.GetGetMethod() != null && prop.GetGetMethod()!.IsVirtual) continue;
                Console.Write($"{prop.Name} ({prop.GetValue(o)}): ");
                string newval = Console.ReadLine()??"";
                
                if (newval.Length > 0)
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(o,newval);
                    }
                    else
                    {
                        var propType = prop.PropertyType;
                        var parseMethod = propType.GetMethods().First(t => t.Name.Contains("Parse"));
                        var converted = parseMethod.Invoke(null, new object[] { newval });
                        prop.SetValue(o, converted);
                    }
                }
               
            }

            return o;
        }

        public static T CreateObject()
        {
            return (T)_RecordObject(typeof(T));
        }

        public static T UpdateObject(T obj)
        {
            return _UpdateObject(obj);
        }
    }
}
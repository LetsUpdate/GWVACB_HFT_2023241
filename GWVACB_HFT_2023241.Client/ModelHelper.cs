using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GWVACB_HFT_2023241.Client
{
    public static class ModelHelper<T>
    {
        private static object _RecordObject(Type t)
        {
            object instance = Activator.CreateInstance(t);
            foreach (var item in t.GetProperties())
            {
                if(item.Name.ToLower().Contains(t.Name.ToLower()+"id"))
                {
                    continue;
                }
                //if itm is virtual continue
                if (item.GetGetMethod()!=null && item.GetGetMethod()!.IsVirtual)
                {
                    continue;
                }
                
                var attr = item.GetCustomAttribute<DisplayNameAttribute>();
                if (attr != null)
                {
                    Console.Write(attr.DisplayName + ": ");
                }
                else
                {
                    Console.Write($"Enter {item.Name} value: ");
                }

                

                string result = Console.ReadLine();
                
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(instance, result);
                }
                else
                {
                    Type propType = item.PropertyType;
                    var parseMethod = propType.GetMethods().First(t => t.Name.Contains("Parse"));
                    var converted = parseMethod.Invoke(null, new object[] { result });
                    item.SetValue(instance, converted);
                }
                
                
            }
            return instance;
        }

        public static T CreateObject()
        {
            return (T)_RecordObject(typeof(T));
        }

        public static T UpdateObject(T obj)
        {
            return (T)_RecordObject(typeof(T));
        }
    }
}
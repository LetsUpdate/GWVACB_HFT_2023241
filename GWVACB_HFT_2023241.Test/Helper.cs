using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NUnit.Framework;
using RangeAttribute = System.ComponentModel.DataAnnotations.RangeAttribute;

namespace GWVACB_HFT_2023241.Test
{
    public class Helper
    {
        private static bool ValidateObjectByAttributes(object obj)
        {
            var objectType = obj.GetType();
            var properties = objectType.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (attribute is ValidationAttribute validationAttribute)
                    {
                        var value = property.GetValue(obj);

                        if (!validationAttribute.IsValid(value))
                        {
                            return false; // Ha bármely attribútum ellenőrzése nem felel meg, akkor hamis értékkel tér vissza.
                        }
                    }
                }
            }

            return true; // Ha az összes attribútum ellenőrzése sikeres volt, akkor igaz értékkel tér vissza.
        }
        
    }
}
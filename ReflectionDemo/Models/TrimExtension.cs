using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ReflectionDemo.Models
{
    public static class TrimExtension
    {
        public static T TrimAllStrings<T>(this T obj)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;

            foreach (PropertyInfo p in obj.GetType().GetProperties(flags))
            {
                Type currentNodeType = p.PropertyType;
                if (currentNodeType == typeof(String))
                {
                    string currentValue = (string)p.GetValue(obj, null);
                    if (currentValue != null)
                    {
                        p.SetValue(obj, currentValue.Trim(), null);
                    }
                }

                else if (currentNodeType != typeof(object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
                {
                    p.GetValue(obj, null).TrimAllStrings();
                }


            }
            return obj;
        }
    }

    public class Reference 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class Referencecontact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class TrimModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext,
          ModelBindingContext bindingContext,
          System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            if (propertyDescriptor.PropertyType == typeof(string))
            {
                var stringValue = (string)value;
               
                    if (!string.IsNullOrWhiteSpace(stringValue))
                        value = stringValue.Trim();
                    else
                        value = null;
            }

            base.SetProperty(controllerContext, bindingContext,
                                propertyDescriptor, value);
        }
    }
}
using System;
using System.Collections;
using System.Reflection;

namespace Util
{
    public class ClassHelper
    {
        public static bool GetBoolValue(object dataobject, string PropertyName)
        {
            try
            {
                object rtn = GetPropertyValue(dataobject, PropertyName);
                if (rtn != null)
                {
                    return Convert.ToBoolean(rtn);
                }
            }
            catch
            {
            }
            return false;
        }
        public static int GetIntValue(object dataobject, string PropertyName)
        {
            try
            {
                object rtn = GetPropertyValue(dataobject, PropertyName);
                if (rtn != null)
                {
                    return Convert.ToInt32(rtn);
                }
            }
            catch
            {
            }

            return 0;
        }
        public static string GetStringValue(object dataobject, string PropertyName)
        {
            try
            {
                object rtn = GetPropertyValue(dataobject, PropertyName);
                if (rtn != null)
                {
                    return Convert.ToString(rtn);
                }
            }
            catch
            {
            }

            return string.Empty;
        }

        public static object GetPropertyValue(object dataobject, string PropertyName)
        {
            try
            {
                Type t = dataobject.GetType();

                PropertyInfo[] AllProperty = t.GetProperties();
                foreach (PropertyInfo pi in AllProperty)
                {
                    if (pi.Name == PropertyName)
                    {
                        object data = pi.GetValue(dataobject, null);
                        return data;
                    }
                }
            }
            catch
            { }
            return null;
        }
        public static Type GetPropertyType(object dataobject, string PropertyName)
        {
            try
            {
                return GetPropertyValue(dataobject, PropertyName).GetType();
            }
            catch
            { }
            return null;
        }

        public static void SetListValue(IList data, string PropertyName, object value)
        {
            foreach (object dataobject in data)
            {
                SetPropertyValue(dataobject, PropertyName, value);
            }
        }

        public static void SetPropertyValue(object dataobject, string PropertyName, object value)
        {
            try
            {
                Type t = dataobject.GetType();

                PropertyInfo[] AllProperty = t.GetProperties();
                foreach (PropertyInfo pi in AllProperty)
                {
                    if (pi.Name == PropertyName)
                    {
                        if (value != null && !string.IsNullOrEmpty(value.ToString()) && pi.PropertyType != value.GetType())
                        {
                            value = Convert.ChangeType(value, pi.PropertyType);
                        }
                        //设置DataTime
                        if (pi.PropertyType == typeof(DateTime))
                        {
                            DateTime outdate;
                            if (DateTime.TryParse(value.ToString(), out outdate))
                            {
                                if (Convert.ToDateTime(outdate) < Convert.ToDateTime("1573-01-01") || Convert.ToDateTime(outdate) > Convert.ToDateTime("9999-01-01"))
                                {
                                    value = Convert.ToDateTime("1900-01-01");
                                }
                            }
                            else
                            {
                                value = Convert.ToDateTime("1900-01-01");
                            }
                        }
                        pi.SetValue(dataobject, value, null);
                    }
                }
            }
            catch
            { }
        }

        public static object SetDefaultDateTime(object dataobject)
        {
            try
            {
                Type t = dataobject.GetType();

                PropertyInfo[] AllProperty = t.GetProperties();
                foreach (PropertyInfo pi in AllProperty)
                {
                    if (pi.PropertyType == typeof(DateTime))
                    {
                        object value = pi.GetValue(dataobject, null);
                        DateTime outdate;
                        if (DateTime.TryParse(value.ToString(), out outdate))
                        {
                            if (Convert.ToDateTime(outdate) < Convert.ToDateTime("1573-01-01") || Convert.ToDateTime(outdate) > Convert.ToDateTime("9999-01-01"))
                            {
                                value = Convert.ToDateTime("1900-01-01");
                                pi.SetValue(dataobject, value, null);
                            }
                        }
                    }
                }
            }
            catch
            { }
            return dataobject;

        }


        public static void SetObjectClone(object sourobject, object targetobject)
        {
            PropertyInfo[] targetProperties = (targetobject.GetType()).GetProperties();
            PropertyInfo[] sourProperties = (sourobject.GetType()).GetProperties();
            for (int i = 0; i < sourProperties.Length; i++)
            {
                for (int j = 0; j < targetProperties.Length; j++)
                {
                    if (sourProperties[i].Name == targetProperties[j].Name && targetProperties[j].CanWrite)
                    {
                        sourProperties[j].SetValue(targetobject, sourProperties[i].GetValue(sourobject, null), null);
                        break;
                    }
                }

            }

        }

    }
}

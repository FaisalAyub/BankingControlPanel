using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MCN.Common
{
    public static class DataTableToCollection
    {
        public static T ToSingleCollection<T>(this DataTable dt)
        {
            try
            {
                List<T> lst = new System.Collections.Generic.List<T>();
                Type tClass = typeof(T);
                PropertyInfo[] pClass = tClass.GetProperties();
                List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
                T cn;
                foreach (DataRow item in dt.Rows)
                {
                    cn = (T)Activator.CreateInstance(tClass);
                    foreach (PropertyInfo pc in pClass)
                    {
                        // Can comment try catch block. 
                        try
                        {
                            DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                            if (d != null)
                            {
                                pc.SetValue(cn, item[pc.Name], null);
                            }
                        }
                        catch
                        {
                        }
                    }
                    lst.Add(cn);
                    break;
                }
                if (lst.Count() > 0)
                    return lst[0];
                return (T)Activator.CreateInstance(tClass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<T> ToCollection<T>(this DataTable dt)
        {
            try
            {
                List<T> lst = new System.Collections.Generic.List<T>();
                Type tClass = typeof(T);
                PropertyInfo[] pClass = tClass.GetProperties();
                List<DataColumn> dc = dt.Columns.Cast<DataColumn>().ToList();
                T cn;
                foreach (DataRow item in dt.Rows)
                {
                    cn = (T)Activator.CreateInstance(tClass);
                    foreach (PropertyInfo pc in pClass)
                    {
                        // Can comment try catch block. 
                        try
                        {
                            DataColumn d = dc.Find(c => c.ColumnName == pc.Name);
                            if (d != null)
                            {
                                pc.SetValue(cn, item[pc.Name], null);
                            }

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    lst.Add(cn);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

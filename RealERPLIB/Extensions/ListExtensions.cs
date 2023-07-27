using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB.Extensions
{
    public static class ListExtensions
    {
        public static DataTable ListToDataTable<T>(this List<T> dataList)
        {
            DataTable dataTable = new DataTable();

            if (dataList == null || dataList.Count == 0)
                return dataTable;

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T data in dataList)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo prop in props)
                {
                    row[prop.Name] = prop.GetValue(data, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}

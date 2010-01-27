/**********************************************************************
* Description:  A collection of data-type utility classes 
* Created By:	Dallon Feldner @ Central Christian Church of the East Valley
* Date Created:	???
*
* $Workfile: DatabaseUtils.cs $
* $Revision: 1 $ 
* $Header: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/DatabaseUtils.cs   1   2010-01-27 10:18:58-07:00   JasonO $
* 
* $Log: /trunk/Arena.Custom.Cccev/Arena.Custom.Cccev.DataUtils/DatabaseUtils.cs $
*  
*  Revision: 1   Date: 2010-01-27 17:18:58Z   User: JasonO 
*  Breaking DataUtils collection of classes into separate files. 
*  
*  Revision: 6   Date: 2008-12-15 22:20:26Z   User: DallonF 
*  Added ToDataTable(this IEnumerable<T>) method 
*
**********************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Arena.Custom.Cccev.DataUtils
{
    /// <summary>
    /// Methods relating to the database
    /// </summary>
    public static class DatabaseUtils
    {
        /// <summary>
        /// Returns a DataTable based on an IEnumerable. Used for objects such as the ArenaDataGrid which expect a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <param name="list">The list to convert into a data table</param>
        /// <returns>DataTable based on the list.</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            DataTable result = new DataTable();
            Type t = typeof(T);
            var colNames = t.GetProperties()
                .Where(p => p.CanRead)
                .Select(p => p.Name);
            foreach (string colName in colNames)
            {
                result.Columns.Add(colName);
            }
            foreach (T item in list)
            {
                DataRow row = result.Rows.Add();
                foreach (DataColumn col in result.Columns)
                {
                    row[col] = t.GetProperty(col.ColumnName).GetValue(item, null);
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableLibrary
{
    public class DataTableUtils
    {
        public static DataTable SortTable(DataTable dt, string sort)
        {
            DataView dataView = dt.DefaultView;
            dataView.Sort = sort;
            dt = dataView.ToTable();
            return dt;
        }
    }
}

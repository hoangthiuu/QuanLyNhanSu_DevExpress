using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS
{
    public class CommonHandler
    {
        /// <summary>
        /// Load data cho LookupEdit
        /// </summary>
        /// <param name="lookupEdit"></param>
        /// <param name="datasource"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        public static void LoadFromObject(LookUpEdit lookupEdit, object datasource, string valueMember, string displayMember)
        {
            lookupEdit.Properties.DataSource = datasource;// Gán Datasoruce = data
            lookupEdit.Properties.Columns.Add(new LookUpColumnInfo(displayMember));
            lookupEdit.Properties.ValueMember = valueMember; // Chỉ định ValueMemmer
            lookupEdit.Properties.DisplayMember = displayMember; // Chỉ định DisplayMember
            lookupEdit.Properties.ShowHeader = false;
            lookupEdit.Properties.SearchMode = SearchMode.AutoSuggest;
        }

        /// <summary>
        /// Load data cho RepositoryLookupEdit
        /// </summary>
        /// <param name="lookupEdit"></param>
        /// <param name="datasource"></param>
        /// <param name="valueMember"></param>
        /// <param name="displayMember"></param>
        public static void LoadFromObject(RepositoryItemLookUpEdit lookupEdit, object datasource, string valueMember, string displayMember)
        {
            lookupEdit.DataSource = datasource;// Gán Datasoruce = data
            lookupEdit.Columns.Add(new LookUpColumnInfo(displayMember));
            lookupEdit.ValueMember = valueMember; // Chỉ định ValueMemmer
            lookupEdit.DisplayMember = displayMember; // Chỉ định DisplayMember
            lookupEdit.ShowHeader = false;
            lookupEdit.SearchMode = SearchMode.AutoSuggest;
        }

        // Ép kiểu giá trị object sang kiểu dữ liệu cụ thể, nếu object null --> trả về null
        public static int? ConvertToNullabeInt(object value)
        {
            if (value == null) return null;
            else return Convert.ToInt32(value);
        }
        public static long? ConvertToNullabeLong(object value)
        {
            if (value == null) return null;
            else return Convert.ToInt64(value);
        }
        public static decimal? ConvertToNullableDecimal(object value)
        {
            if (value == null) return null;
            else return Convert.ToDecimal(value);
        }
        public static double? ConvertToNullableDouble(object value)
        {
            if (value == null) return null;
            else return Convert.ToDouble(value);
        }
        public static float? ConvertToNullableFloat(object value)
        {
            if (value == null) return null;
            else return (float)value;
        }
        public static DateTime? ConvertToNullableDateTime(object value)
        {
            if (value == null) return null;
            else return Convert.ToDateTime(value);
        }
        public static string ConvertToNullableString(object value)
        {
            if (value == null) return null;
            else return Convert.ToString(value);
        }
        public static bool? ConvertToNullableBoolean(object value)
        {
            if (value == null) return null;
            else return Convert.ToBoolean(value);
        }

        //Thêm hình ảnh nhân viên
        public static Byte? ConvertToNullableByte(object value)
        {
            if (value == null) return null;
            else return Convert.ToByte(value);
        }
    }
}

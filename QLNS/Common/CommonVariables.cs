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
    public class CommonVariables
    {
        /// <summary>
        ///  Trạng thái form: 1.View | 2.Create | 3.Edit
        /// </summary>
        public enum FormStatus
        {
            View = 0,
            Create = 1,
            Edit = 2
        }
    }
}

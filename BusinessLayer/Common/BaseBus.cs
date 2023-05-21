using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    ///  Business cơ sở, các Business cụ thể kế thừa BaseBusiness và thực thi interface IStandardBus
    /// </summary>
    public class BaseBus
    {
        protected QLNS1Entities1 db = new QLNS1Entities1();
    }
}

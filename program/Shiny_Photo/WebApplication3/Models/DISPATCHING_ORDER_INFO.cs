//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DISPATCHING_ORDER_INFO
    {
        public long DISPATCHING_ID { get; set; }
        public long DISPATCHING_ORDER_EQUIPMENT_ID { get; set; }
        public long DISPATCHING_DISPATCHER_ID { get; set; }
        public short DISPATCHING_STATUS { get; set; }
    
        public virtual ORDER_EQUIPMENT_INFO ORDER_EQUIPMENT_INFO { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}

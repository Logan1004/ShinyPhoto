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
    
    public partial class ALL_PHOTO
    {
        public long PHOTO_ID { get; set; }
        public string PHOTO_ADDRESS { get; set; }
        public long PHOTO_SIZE { get; set; }
        public string PHOTO_REQUIREMENT { get; set; }
        public short PHOTO_STATUS { get; set; }
    
        public virtual CONTRACT_PHOTO_INFO CONTRACT_PHOTO_INFO { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Base_O_A_Setup
    {
        public string Setup_ID { get; set; }
        public string User_ID { get; set; }
        public string Setup_IName { get; set; }
        public string NavigateUrl { get; set; }
        public string Target { get; set; }
        public string Setup_Img { get; set; }
        public string Setup_Remak { get; set; }
        public Nullable<int> SortCode { get; set; }
    
        public virtual Base_UserInfo Base_UserInfo { get; set; }
    }
}
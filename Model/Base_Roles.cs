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
    
    public partial class Base_Roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Base_Roles()
        {
            this.Base_RoleRight = new HashSet<Base_RoleRight>();
            this.Base_UserRole = new HashSet<Base_UserRole>();
        }
    
        public string Roles_ID { get; set; }
        public string ParentId { get; set; }
        public string Roles_Name { get; set; }
        public string Role_Restriction { get; set; }
        public string Roles_Remark { get; set; }
        public Nullable<int> AllowEdit { get; set; }
        public Nullable<int> AllowDelete { get; set; }
        public Nullable<int> SortCode { get; set; }
        public Nullable<int> DeleteMark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Base_RoleRight> Base_RoleRight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Base_UserRole> Base_UserRole { get; set; }
    }
}
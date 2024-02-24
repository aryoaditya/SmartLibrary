using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    /* 
     * Account Role Model
     * intermediary model for accounts and roles
    */
    [Table(name:"tb_m_account_roles")]
    public class AccountRole : Base
    {
        [Column(name:"role_guid")]
        public Guid RoleGuid { get; set; }
        [Column(name: "account_guid")]
        public Guid AccountGuid { get; set; }
        [Column(name: "created_date")]
        public DateTime CreatedDate { get; set; }
        [Column(name: "modified_date")]
        public DateTime ModifiedDate { get; set; }

        //Cardinality
        public Role? Role { get; set; }
        public Account? Account { get; set; }
    }
}

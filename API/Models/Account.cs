﻿using System.ComponentModel.DataAnnotations.Schema;


namespace API.Models
{
    // Account Model
    [Table(name: "tb_m_accounts")]
    public class Account : Base
    {
        [Column(name:"username", TypeName = "nvarchar(20)")]
        public string Username { get; set; }
        [Column(name:"password", TypeName = "nvarchar(max)")]
        public string Password { get; set; }
        [Column(name:"otp")]
        public int Otp { get; set; }
        [Column(name: "is_used")]
        public bool IsUsed { get; set; }
        [Column(name: "expired_date")]
        public DateTime ExpiredDate { get; set; }
        [Column(name: "created_date")]
        public DateTime CreatedDate { get; set; }
        [Column(name: "modified_date")]
        public DateTime ModifiedDate { get; set; }
        
        // Cardinality
        public ICollection<AccountRole>? AccountRoles { get; set; }
        public Member? Member { get; set; }
        public Staff? Staff { get; set; }
    }
}

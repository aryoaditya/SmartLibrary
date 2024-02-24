using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    // Staff model
    [Table(name: "tb_m_staffs")]
    public class Staff : Base
    {
        [Column(name:"id", TypeName ="nchar(6)")]
        public string Id { get; set; }
        [Column(name: "first_name", TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Column(name: "last_name", TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Column(name: "birth_date")]
        public DateTime BirthDate { get; set; }
        [Column(name: "gender")]
        public GenderLevel Gender { get; set; }
        [Column(name: "email")]
        public string Email { get; set; }
        [Column(name: "phone_number")]
        public string PhoneNumber { get; set; }

        // Cardinality
        public Account? Account { get; set; }
        public ICollection<BorrowerRecord>? BorrowerRecords { get; set; }
        public ICollection<ReturnRecord>? ReturnRecords { get; set; }
    }
}

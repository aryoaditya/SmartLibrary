using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    // Borrower Record Model
    [Table(name:"tb_m_borrower_records")]
    public class BorrowerRecord : Base
    {
        [Column(name: "member_guid")]
        public Guid MemberGuid { get; set; }
        [Column(name: "staff_guid")]
        public Guid StaffGuid { get; set; }
        [Column(name: "date_request")]
        public DateTime DateRequest { get; set; }
        [Column(name: "borrow_date")]
        public DateTime BorrowDate { get; set; }
        [Column(name:"return_deadline")]
        public DateTime ReturnDeadline { get; set; }
        [Column(name: "remarks", TypeName = "nvarchar(max)")]
        public string Remarks { get; set; }

        // Cardinality
        public Member? Member { get; set; }
        public Staff? Staff { get; set; }
        public ReturnRecord? ReturnRecord { get; set; }
        public ICollection<BookBorrower>? BookBorrowers { get; set; }

    }
}

using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    // Return record model
    [Table(name:"tb_m_return_records")]
    public class ReturnRecord : Base
    {
        [Column(name:"member_guid")]
        public Guid MemberGuid { get; set; }
        [Column(name: "staff_guid")]
        public Guid StaffGuid { get; set; }
        [Column(name: "borrow_record_guid")]
        public Guid BorrowRecordGuid { get; set; }
        [Column(name: "return_date")]
        public DateTime ReturnDate { get; set; }
        [Column(name: "status")]
        public StatusLevel Status { get; set; }
        [Column(name: "remarks", TypeName = "nvarchar(max)")]
        public string Remarks { get; set; }

        // Cardinality
        public ICollection<BookReturn>? BookReturns { get; set; }
        public Staff? Staff { get; set; }
        public BorrowerRecord? BorrowerRecord { get; set; }
        public Member? Member { get; set; }
    }
}

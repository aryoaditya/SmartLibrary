using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    /* 
     * Book Borrower Model
     * intermediary model between books and borrower records
    */
    [Table(name:"tb_m_book_borrowers")]
    public class BookBorrower : Base
    {
        [Column(name: "borrower_record_guid")]
        public Guid BorrowerRecordGuid { get; set; }
        [Column(name: "book_guid")]
        public Guid BookGuid { get; set; }

        // Cardinality
        public BorrowerRecord? BorrowerRecord { get; set; }
        public Book? Book { get; set; }
    }
}

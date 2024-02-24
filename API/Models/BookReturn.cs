using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    /* 
     * Book Return Model
     * intermediary model between books and return records
    */
    [Table(name: "tb_m_book_returns")]
    public class BookReturn : Base
    {
        [Column(name: "return_record_guid")]
        public Guid ReturnRecordGuid { get; set; }
        [Column(name: "book_guid")]
        public Guid BookGuid { get; set; }

        // Cardinality
        public ReturnRecord? ReturnRecord { get; set; }
        public Book? Book { get; set; }
    }
}

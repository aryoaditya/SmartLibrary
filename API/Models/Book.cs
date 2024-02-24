using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    // Book model
    [Table(name:"tb_m_books")]
    public class Book : Base
    {
        [Column(name:"id", TypeName = "nchar(6)")]
        public string Id { get; set; }
        [Column(name: "title", TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Column(name: "description", TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Column(name: "author", TypeName = "nvarchar(150)")]
        public string Author { get; set; }
        [Column(name: "edition", TypeName = "nvarchar(100)")]
        public string Edition { get; set; }
        [Column(name: "publisher", TypeName = "nvarchar(50)")]
        public string Publisher { get; set; }
        [Column(name: "copies")]
        public int Copies { get; set; }
        [Column(name: "created_date")]
        public DateTime CreatedDate { get; set; }
        [Column(name: "modified_date")]
        public DateTime ModifiedDate { get; set; }

        // Cardinality
        public ICollection<BookReturn>? BookReturns { get; set; }
        public ICollection<BookBorrower>? BookBorrowers { get; set; }
    }
}

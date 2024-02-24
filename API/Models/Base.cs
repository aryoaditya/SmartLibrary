using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    // Base model
    public abstract class Base
    {
        [Key, Column(name:"guid")]
        public Guid Guid { get; set; }
    }
}

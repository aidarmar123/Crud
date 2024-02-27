using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Models.Metadata
{
    public class UserMetadata
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле имени обязательное")]
        [MaxLength(50, ErrorMessage = "")]
        //[RegularExpression()]
        public string Name { get; set; }
        public int RoleId { get; set; }

        [Required]
        public virtual Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Models.Metadata
{
    public class UserMethData
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Имя не заполненно")]
        
        public string Name { get; set; }
        public int RoleId { get; set; }
        [Required (ErrorMessage ="Нету роли")]
        public virtual Role Role { get; set; }
    }
}

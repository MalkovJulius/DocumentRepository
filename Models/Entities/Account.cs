using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Entities
{
    /// <summary>
    /// Сущность аккаунт
    /// </summary>
    public class Account
    {
        [Display(Name = "Id")]
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Логин аккаунта")]
        public virtual string Login { get; set; }

        [Required]
        [Display(Name = "Зашифрованный пароль")]        
        public virtual string CryptedPassword { get; set; }

        [Display(Name = "Ссылка на список сущностей Document")]
        public virtual List<Document> Documents { get; set; } //возможно List<int> с ID
    }
}

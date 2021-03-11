using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Entities
{
    /// <summary>
    /// Сущность документ
    /// </summary>
    public class Document
    {
        [Display(Name = "Id")]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Название документа")]
        public virtual string Name { get; set; }

        [Display(Name = "Дата создания")]
        public virtual DateTime DateTime { get; set; }

        [Required]
        //[Column("Account")] это не точно надо проверить
        [Display(Name = "Автор документа")]
        public virtual Account Author { get; set; }

        [Display(Name = "Тип документа")]
        public virtual DocumentType DocumentType { get; set; }

        [Required]
        [Display(Name = "Бинарный файл")]
        public virtual List<byte> File { get; set; }
    }

    /// <summary>
    /// Тип документа
    /// </summary>
    public enum DocumentType
    {
        [Display(Name = "MS Word документ")]
        Word = 10,

        [Display(Name = "MS Excel документ")]
        Excel = 20,

        [Display(Name = "PDF документ")]
        Pdf = 30
    }
}

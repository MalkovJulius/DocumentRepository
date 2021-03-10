using DocumentRepository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Dtos
{
    /// <summary>
    /// ДТО документа
    /// </summary>
    public class DocumentDto
    {
        /// <summary>
        /// Id документа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название документа
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Дата создания документа
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Автор документа
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Бинарный файл
        /// </summary>       
        public List<byte> File { get; set; } //возможно byte[] 
    }
}

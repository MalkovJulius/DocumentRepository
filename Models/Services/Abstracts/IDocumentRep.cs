using DocumentRepository.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Services.Abstracts
{
    /// <summary>
    /// Интерфейс для работы с ORM по документам
    /// </summary>
    interface IDocumentRep
    {
        /// <summary>
        /// Добавляет документ в БД
        /// </summary>
        /// <param name="file"> бинарный файл </param>
        void AddDocument(List<byte> file);

        /// <summary>
        /// Удаляет документ из БД
        /// </summary>
        /// <param name="id"> id документа </param>
        void DeletDocument(int id);

        /// <summary>
        /// Возращает документ из БД
        /// </summary>
        /// <param name="id"> id документа </param>
        /// <returns></returns>
        List<byte> GetDocument(int id);

        /// <summary>
        /// Возращает все документы из БД
        /// </summary>
        /// <param name="authorId"> id документа </param>
        /// <returns></returns>
        List<DocumentDto> GetDocuments(int authorId);

        /// <summary>
        /// Возращает все документы в названии, которых содержится данное слово или фраза
        /// </summary>
        /// <param name="authorId"> id документа </param>
        /// <param name="text"> часть названия документа </param> 
        /// <returns></returns>
        List<DocumentDto> GetCurrentDocuments(int authorId, string text);
    }
}

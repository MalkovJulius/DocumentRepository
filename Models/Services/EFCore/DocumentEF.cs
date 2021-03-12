using DocumentRepository.Models.Dtos;
using DocumentRepository.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Services.EFCore
{
    //TODO: сделать везде try catch на случай не удачных операций
    public class DocumentEF : IDocument //возможно назвать DocumentRepository
    {
        public void AddDocument(List<byte> file) //может Document должно быть
        {
            var document = new Document //затычка
            {
                DocumentType = DocumentType.Word,
                Author = new Account(),
                Name = "",
                File = file//,
                //DateCreated = DateTime.UtcNow
            };
            //TODO: fill documet from file and something else data like Author or DocumentType

            using (var context = new ContextEF())
            {
                context.Documents.Add(document);
                context.SaveChanges();
            }
        }

        public void DeletDocument(int id)
        {
            using (var context = new ContextEF())
            {
                var document = context.Documents.FirstOrDefault(doc => doc.Id == id);
                context.Documents.Remove(document);
                context.SaveChanges();
            }
        }

        public List<byte> GetDocument(int id)
        {
            using (var context = new ContextEF())
            {
                return context.Documents.FirstOrDefault(doc => doc.Id == id)?.File;
            }
        }

        public List<DocumentDto> GetDocuments(int authorId)
        {
            using (var context = new ContextEF())
            {
                var documents = context.Documents
                    .Where(doc => doc.Author.Id == authorId)
                    .Select(doc =>
                        new DocumentDto
                        {
                            Id = doc.Id,
                            Name = doc.Name,
                            DateTime = doc.DateCreated,
                            DocumentType = DocumentType.Word, // it's temp solution
                            File = doc.File
                        })
                    .ToList();
                return documents;
            }
        }

        public List<DocumentDto> GetCurrentDocuments(int authorId, string text)
        {
            using (var context = new ContextEF())
            {
                var documents = context.Documents
                    .Where(doc => doc.Author.Id == authorId)
                    .Where(doc => doc.Name.Contains(text))
                    .Select(doc =>
                        new DocumentDto
                        {
                            Id = doc.Id,
                            Name = doc.Name,
                            DateTime = doc.DateCreated,
                            DocumentType = DocumentType.Word, // it's temp solution
                            File = doc.File
                        })
                    .ToList();
                return documents;
            }
        }
    }
}

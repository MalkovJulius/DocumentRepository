using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Services
{
    /// <summary>
    /// Класс соответсвующий конфигурационному файлу
    /// </summary>
    public class Config //может откажусь от данного класса или изменю
    {
        public static string ConnectionString { get; set; }
        public static string SomeInformation { get; set; }
    }
}

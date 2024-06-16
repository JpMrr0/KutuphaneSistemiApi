using KutuphaneSistemiApi.Domain.Entities.Common;
using KutuphaneSistemiApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public BookGenres Genre { get; set; }
    }
}

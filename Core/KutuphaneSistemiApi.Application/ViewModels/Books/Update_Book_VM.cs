using KutuphaneSistemiApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.ViewModels.Books
{
    public class Update_Book_VM
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public BookGenres Genre { get; set; }
    }
}

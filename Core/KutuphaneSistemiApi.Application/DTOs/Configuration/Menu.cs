using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.DTOs.Configuration
{
    public class Menu
    {
        public string Title { get; set; }
        public List<Configuration.Action> Actions { get; set; } = new();
    }
}

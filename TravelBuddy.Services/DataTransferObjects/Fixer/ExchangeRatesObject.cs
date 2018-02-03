using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Services.DataTransferObjects.Fixer
{
    public class ExchangeRatesObject
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}

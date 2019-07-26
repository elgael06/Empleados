using System;

namespace Empleados.Models
{
    public class Payments
    {
        public int id { get; set; }
        public int idEmploye { get; set; }
        public int idClient { get; set; }
        public double preBalance { get; set; }
        public double payment { get; set; }
        public double newBalance { get; set; }
        public DateTime date = DateTime.Now;
    }
}
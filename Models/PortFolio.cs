using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Empleados.Models
{
    public class PortFolio
    {
        public int id { get; set; }
        public int idEmploye { get; set; }
        public int IdClient { get; set; }
        public bool Status { get; set; }
        public double Total { get; set; }
    }
}
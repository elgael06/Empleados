using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Empleados.Models
{
    public class Client : Person
    {
        public string other { get; set; }

    }

}
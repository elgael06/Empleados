using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace  Empleados.Models
{
    public class Employe
    {
        [Key]
        public int id {get;set;}
        public string name {get;set;}
        public List<Access> accesss {get;set;}
    }

    public class Access
    {
        public int id {get;set;}
        public string menu {get;set;}
        public string url {get;set;}
        public bool status {get;set;} 
    }
}
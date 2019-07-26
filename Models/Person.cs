using System.ComponentModel.DataAnnotations;

namespace Empleados.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string photo { get; set; }
        public string name { get; set; }
        public string applealed { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
    }

}
using SimApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    
    public class Category:BaseModel
    {
        public string Name { get; set; }

        public virtual List<Product> products { get; set; } =new List<Product>();
    }
}

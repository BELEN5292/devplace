using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_devplace.Repository;

namespace api.devplace.Domain.Models
{
    public class ComentarioBlog : EntityBase
    {
       
        public string Texto { get; set; }
      
        public ArticuloBlog Articulo { get; set; }

        
        public int ArticuloId { get; set; }
        


    }
}


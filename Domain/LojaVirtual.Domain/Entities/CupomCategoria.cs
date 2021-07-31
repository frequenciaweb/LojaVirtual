using System;

namespace LojaVirtual.Domain.Entities
{
    public class CupomCategoria
    {
        public Guid ID { get; set; }
        
        public Guid CategoriaID { get; set; }
        public Categoria Categoria { get; set; }

        public Guid CupomID { get; set; }
        public Cupom Cupom { get; set; }
        

    }
}

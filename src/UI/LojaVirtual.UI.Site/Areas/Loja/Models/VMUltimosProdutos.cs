using System;

namespace LojaVirtual.UI.Site.Areas.Loja.Models
{
    public class VMUltimosProdutos
    {
        public Guid ID { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal ValorAntigo { get; set; }
    }
}

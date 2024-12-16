namespace CSVHeader.Presentation.Model
{
    public class Produto
    {
        public string? Nome { get; set; }
        public int QtdVendida { get; set; }
        public int QtdTotalEstoque { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCompra { get; set; }

        public decimal CalcularValorRetornado()
        {
            return (QtdVendida * ValorVenda) - (ValorCompra * QtdTotalEstoque);
        }

        public int CalcularValorTotalEstoque()
        {
            return QtdTotalEstoque - QtdVendida;
        }

        public string StatusProduto()
        {
            decimal valor = CalcularValorRetornado();

            if (valor > 0)
            {
                return "Lucro";
            }

            if (valor < 0)
            {
                return "Prejuizo";
            }

            return "Rendimento Nulo";
        }
    }
}

using CSVHeader.Presentation.Model;
namespace CSVHeader.Presentation.View
{
    public class ProdutoView
    {
        public void ExibirProdutos(List<Produto> produtos)
        {
            Console.WriteLine("Informações dos produtos:");

            foreach (var item in produtos)
            {
                Console.WriteLine($"Nome Produto: {item.Nome}, " +
                                  $"Valor Total Retornado: ${item.CalcularValorRetornado()}, " +
                                  $"Situação: {item.StatusProduto()}, " +
                                  $"Valor Total de Produtos no Estoque: {item.CalcularValorTotalEstoque()}");
            }
        }

        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}

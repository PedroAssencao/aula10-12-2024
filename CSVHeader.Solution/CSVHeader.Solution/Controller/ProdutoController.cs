using CSVHeader.Presentation.Service;
using CSVHeader.Presentation.View;

namespace CSVHeader.Presentation.Controller
{
    public class ProdutoController
    {
        private readonly ProdutoService _service;
        private readonly ProdutoView _view;

        public ProdutoController()
        {
            _service = new ProdutoService();
            _view = new ProdutoView();
        }

        public void ExibirProdutos(string caminho)
        {
            var produtos = _service.ObterProdutos(caminho);

            if (produtos.Count >= 0)
            {
                _view.ExibirProdutos(produtos.Where(x => x.StatusProduto() == "Lucro").ToList());
                Console.ReadKey();
                Console.Clear();
                _view.ExibirProdutos(produtos.Where(x => x.StatusProduto() == "Prejuizo").ToList());
                Console.ReadKey();
                Console.Clear();
                _view.ExibirProdutos(produtos.Where(x => x.StatusProduto() == "Rendimento Nulo").ToList());
                Console.ReadKey();
                Console.Clear();
                _view.ExibirProdutos(produtos);
                Console.ReadKey();
            }
            else
            {
                _view.ExibirMensagem("Nenhum produto encontrado no arquivo.");
                Console.ReadKey();
            }
        }
    }
}

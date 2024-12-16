using CSVHeader.Presentation.Controller;

var caminhoArquivo = "Produtos.csv";

var controller = new ProdutoController();
controller.ExibirProdutos(caminhoArquivo);
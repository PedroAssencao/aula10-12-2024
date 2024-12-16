using CSVHeader.Presentation.Model;

namespace CSVHeader.Presentation.Service
{
    public class ProdutoService
    {
        private List<string> LerArquivoCsv(string caminho)
        {
            var linhas = new List<string>();

            using (var reader = new StreamReader(caminho))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(linha))
                    {
                        linhas.Add(linha);
                    }
                }
            }
            return linhas;
        }

        public List<Produto> ObterProdutos(string caminho)
        {
            var linhas = LerArquivoCsv(caminho);
            var listProdutos = new List<Produto>();

            foreach (var linha in linhas)
            {
                var colunas = linha.Split(";").ToList();

                if (colunas.Count == 5 && colunas.All(x => !string.IsNullOrWhiteSpace(x)))
                {
                    listProdutos.Add(new Produto
                    {
                        Nome = colunas[0],
                        QtdVendida = Convert.ToInt32(colunas[1]),
                        QtdTotalEstoque = Convert.ToInt32(colunas[2]),
                        ValorCompra = Convert.ToDecimal(colunas[3]),
                        ValorVenda = Convert.ToDecimal(colunas[4]),
                    });
                }
            }

            return listProdutos;
        }
    }
}

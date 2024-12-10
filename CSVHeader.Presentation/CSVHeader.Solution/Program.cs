var caminhoArquivo = "ProdutosCsv.csv";

var listProdutos = new List<Produto>();

using (var reader = new StreamReader(caminhoArquivo))
{
    reader.ReadLine();

    while (!reader.EndOfStream)
    {
        var linha = reader.ReadLine()?.Split(";").ToList();

        if (linha != null && linha.Count > 0)
        {
            listProdutos.Add(new Produto
            {
                Nome = linha[0],
                QtdVendida = Convert.ToInt32(linha[1]),
                QtdTotalEstoque = Convert.ToInt32(linha[2]),
                ValorCompra = Convert.ToInt32(linha[3]),
                ValorVenda = Convert.ToInt32(linha[4]),
            });
        }
    }
}

if (listProdutos.Count > 0)
{
    Console.WriteLine("Informações dos produtos");

    foreach (var item in listProdutos)
    {
        var Valor = (item.QtdVendida * item.ValorVenda) - (item.QtdTotalEstoque * item.ValorCompra);
        var ValorTotalProduto = item.QtdTotalEstoque - item.QtdVendida;
        var situação = "";

        if (Valor == 0)
        {
            situação = "Rendimento Nulo";
        }

        if (Valor > 0)
        {
            situação = "Lucro";
        }

        if (Valor < 0)
        {
            situação = "Perda";
        }

        Console.WriteLine($"Nome Produto: {item.Nome}, Valor Total Retornado: ${Valor}, Ouve: {situação}, Valor Total de Produtos no Estoque: {ValorTotalProduto}");
    }
}
else
{
    Console.WriteLine("Nenhum Arquivo Encontrado");
}

public class Produto
{
    public string? Nome { get; set; }
    public int QtdVendida { get; set; }
    public int QtdTotalEstoque { get; set; }
    public int ValorVenda { get; set; }
    public int ValorCompra { get; set; }
}


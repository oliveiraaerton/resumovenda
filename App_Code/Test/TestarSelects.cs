using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web.Helpers;
using WebMatrix.Data;

public class TestarSelects
{

	public static void TestarConexaoMilenio()
	{
		Conexao conexao = new Conexao();
	 	SqlConnection c = conexao.sqlConnection();
	 	Assert.IsNotNull(c);
	}

    public static void RetornarCompraSecao()
    {
        //arrange:
        String loja = "000001";
        String datainicial = "2018-08-01";
        String datafinal = "2018-08-01";
        Conexao c = new Conexao(loja);

        //act:
        List<PorSecao> compraDiaria = c.CompraPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(compraDiaria);
        Assert.IsTrue(compraDiaria.Count<=16 && compraDiaria.Count>0);
        Assert.Erro.Add("Total registros: " + compraDiaria.Count.ToString());
    }

    public static void RetornarVendaParceiroPorSecao()
    {
        //arrange:
         String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
        List<PorSecao> vendaParceiro = c.VendaParceiroPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(vendaParceiro);
        Assert.IsTrue(vendaParceiro.Count<=16 && vendaParceiro.Count>0);
        Assert.Erro.Add("Total registros: " + vendaParceiro.Count.ToString());
    }    

    public static void RetornarEntradaTransferenciaPorSecao()
    {
        //arrange:
         String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
        List<PorSecao> entrada = c.EntradaTransferenciaDiariaPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(entrada);
        Assert.IsTrue(entrada.Count<=16 && entrada.Count>0);
        Assert.Erro.Add("Total registros: " + entrada.Count.ToString());
    }  

    public static void RetornarSaidaTransferenciaPorSecao()
    {
        //arrange:
         String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
        List<PorSecao> saida = c.SaidaTransferenciaDiariaPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(saida);
        Assert.IsTrue(saida.Count<=16 && saida.Count>0);
        Assert.Erro.Add("Total registros: " + saida.Count.ToString());
    }  

    public static void ComparaCompraDiariaValorCorreto()
    {
        //arrange:
         String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
        List<PorSecao> compraDiaria = c.CompraPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(compraDiaria);
        Assert.AreEqual(compraDiaria[0].total, 19278.28, 2);
        Assert.AreNotEqual(compraDiaria[0].total, 19278.28, 3);
        
    } 

    public static void ComparaVendaParceiroValorCorreto()
    {
        //arrange:
         String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
        List<PorSecao> vendaParceiro = c.VendaParceiroPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(vendaParceiro);
        Assert.AreEqual(vendaParceiro[0].total, 328060.45, 2);
        Assert.AreNotEqual(vendaParceiro[0].total, 328060.45, 3);
        
    } 

    public static void ComparaEntradaTransferenciaPorSecaoValorCorreto()
    {
        //arrange:
         String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
         //act:
        List<PorSecao> entrada = c.EntradaTransferenciaDiariaPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(entrada);
        Assert.AreEqual(entrada[1].total, 10425.03, 2);
        Assert.AreNotEqual(entrada[1].total, 10425.03, 3);
        
    } 

    public static void ComparaSaidaTransferenciaPorSecaoValorCorreto()
    {
        //arrange:
        String loja = "000001";
        String datainicial = "2018-07-01";
        String datafinal = "2018-07-31";
        Conexao c = new Conexao(loja);

        //act:
         //act:
        List<PorSecao> saida = c.SaidaTransferenciaDiariaPorSecao(loja, datainicial, datafinal);
        if(!String.IsNullOrEmpty(c.message)) Assert.Erro.Add(c.message);

        //assert:
        Assert.IsNotNull(saida);
        Assert.AreEqual(saida[1].total, 57906.86, 2);
        Assert.AreNotEqual(saida[1].total, 57906.86, 3);
        
    }     

    public static void TestarGravarVendaParceiro()
    {
    	string loja = "000001";
    	DateTime ontem = DateTime.Parse("09/07/2018");
        Conexao c = new Conexao(loja);
        c.gravarVendaParceiro(loja, ontem);
        Assert.IsNull(c.message);
    }

    public static void TestarGravarCompraDiaria()
    {
    	string loja = "000001";
    	DateTime ontem = DateTime.Parse("09/07/2018");
        Conexao c = new Conexao(loja);
        c.gravarCompraDiaria(loja, ontem);
        Assert.IsNull(c.message);
    }   

    public static void TestarGravarSaidaTransferenciaDiaria()
    {
    	string loja = "000001";
    	DateTime ontem = DateTime.Parse("09/07/2018");
        Conexao c = new Conexao(loja);
        c.gravarSaidaTransferenciaDiaria(loja, ontem);
        Assert.IsNull(c.message);
    }

    public static void TestarGravarEntradaTransferenciaDiaria()
    {
    	string loja = "000001";
    	DateTime ontem = DateTime.Parse("10/07/2018");
        Conexao c = new Conexao(loja);
        c.gravarEntradaTransferenciaDiaria(loja, ontem);
        Assert.IsNull(c.message);
    }

    public static void TestarGravarCompraVenda()
    {
    	string loja = "000001";
    	DateTime ontem = DateTime.Parse("09/07/2018");
        Conexao c = new Conexao(loja);
        c.gravarCompraVenda(loja, ontem);
        Assert.IsNull(c.message);
    }    
}
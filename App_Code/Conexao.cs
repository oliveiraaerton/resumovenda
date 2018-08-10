using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web.Helpers;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using WebMatrix.Data;

/// <summary>
/// RESUMO VENDA
/// </summary>

public class Conexao
{    
    private FbConnection con = new FbConnection(null);
    public String message; //
    private String connectionString=""; //
    private Configuracao config;


/**   CONEXAO COM O BANCO **/

    public Conexao(){}

    public Conexao(string loja)
    {                
        if(!String.IsNullOrEmpty(loja))
        {
        config=new Configuracao();      
        switch(Int32.Parse(loja))
        {
            case 1: config.datasourceSyspdv="192.168.1.100";break;
            case 2: config.datasourceSyspdv="192.168.2.100";break;
	        case 3: config.datasourceSyspdv="192.168.3.100";break;
            case 4: config.datasourceSyspdv="192.168.4.100";break;
            case 6: config.datasourceSyspdv="192.168.6.100";break;
        }
        connectionString ="User=" + config.userSyspdv + ";" +
        "Password=" + config.passwordSyspdv + ";" +
        "Database=" + config.databaseSyspdv + ";" +
        "DataSource=" + config.datasourceSyspdv + ";" +
        "Dialect=3;" +
        "Charset=NONE;" +
        "Role=;" +
        "Connection lifetime=15;" +
        "Pooling=true;" +
        "MinPoolSize=0;" +
        "MaxPoolSize=50;" +
        "Packet Size=8192;" +
        "ServerType=0";
        abreConexao();
        }
    }

    public void abreConexao()
    {
        con.ConnectionString=connectionString;
        try
        {            
            if(con.State!=ConnectionState.Open)
            {
                con.Open();            
            }    
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
            Fecha();    
        }
    }

    public  void Fecha()
    {
        con.Close();
    }

/** UTILITARIOS**/

	public string randomcolor(Random rnd){
		var hexadecimais = "0123456789ABCDEF";
		var cor = "#";
  
		// Pega um número aleatório no array acima
		//Random rnd = new Random();
		for (var i = 0; i < 6; i++ ) {
		//E concatena à variável cor
        cor += hexadecimais[rnd.Next(0,15)];
		}
		return cor;
	}
	
	public string retornaSemana(int dia, string mes, string ano)
	{
		String data = String.Empty;
		Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
		switch(mes)
		{
			case "JANEIRO":
				data=dia.ToString("00")+"/"+"01"+"/"+ano;
				break;
			case "FEVEREIRO":
				data=dia.ToString("00")+"/"+"02"+"/"+ano;
				break;
			case "MARÇO":
				data=dia.ToString("00")+"/"+"03"+"/"+ano;
				break;
			case "ABRIL":
				data=dia.ToString("00")+"/"+"04"+"/"+ano;
				break;
			case "MAIO":
				data=dia.ToString("00")+"/"+"05"+"/"+ano;
				break;
			case "JUNHO":
				data=dia.ToString("00")+"/"+"06"+"/"+ano;
				break;
			case "JULHO":
				data=dia.ToString("00")+"/"+"07"+"/"+ano;
				break;
			case "AGOSTO":
				data=dia.ToString("00")+"/"+"08"+"/"+ano;
				break;
			case "SETEMBRO":
				data=dia.ToString("00")+"/"+"09"+"/"+ano;
				break;
			case "OUTUBRO":
				data=dia.ToString("00")+"/"+"10"+"/"+ano;
				break;
			case "NOVEMBRO":
				data=dia.ToString("00")+"/"+"11"+"/"+ano;
				break;
			case "DEZEMBRO":
				data=dia.ToString("00")+"/"+"12"+"/"+ano;
				break;
		}
		try{
			CultureInfo ci = new CultureInfo("pt-BR");
			DateTime novadata = DateTime.Parse(data);
			data = novadata.ToString("ddd", ci);
			return data;
		} catch{
			message = data;
		}
		return null;
	}
	
	public string retornaData(int dia, string mes, string ano)
	{
		String data = String.Empty;
		Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
		switch(mes)
		{
			case "JANEIRO":
				data=dia.ToString("00")+"/"+"01"+"/"+ano;
				break;
			case "FEVEREIRO":
				data=dia.ToString("00")+"/"+"02"+"/"+ano;
				break;
			case "MARÇO":
				data=dia.ToString("00")+"/"+"03"+"/"+ano;
				break;
			case "ABRIL":
				data=dia.ToString("00")+"/"+"04"+"/"+ano;
				break;
			case "MAIO":
				data=dia.ToString("00")+"/"+"05"+"/"+ano;
				break;
			case "JUNHO":
				data=dia.ToString("00")+"/"+"06"+"/"+ano;
				break;
			case "JULHO":
				data=dia.ToString("00")+"/"+"07"+"/"+ano;
				break;
			case "AGOSTO":
				data=dia.ToString("00")+"/"+"08"+"/"+ano;
				break;
			case "SETEMBRO":
				data=dia.ToString("00")+"/"+"09"+"/"+ano;
				break;
			case "OUTUBRO":
				data=dia.ToString("00")+"/"+"10"+"/"+ano;
				break;
			case "NOVEMBRO":
				data=dia.ToString("00")+"/"+"11"+"/"+ano;
				break;
			case "DEZEMBRO":
				data=dia.ToString("00")+"/"+"12"+"/"+ano;
				break;
		}
		try{
			CultureInfo ci = new CultureInfo("pt-BR");
			DateTime novadata = DateTime.Parse(data);
			data = novadata.ToString("dd//MM/yyyy", ci);
		} catch{
			data = "01/01/1900";
		}
		return data;
	}
		

    public String stringToData(String data)
    {
        String dia=data.Substring(0,2);
        String mes=data.Substring(3,2);
        String ano=data.Substring(6,4);
        String novadata=ano + "-" + mes + "-" + dia;
        return novadata;
    }

    public String dataTostring(String data)
    {
        String dia=data.Substring(8,2);
        String mes=data.Substring(5,2);
        String ano=data.Substring(0,4);
        String novadata=dia + "/" + mes + "/" + ano;
        return novadata;
    }

    public double diferencaPerc(double diferenca, double total)
    {
        double perc=0.0;
        if(total!=0){
            perc=diferenca*100/total;
        }
        return perc;
    }
 
/** ACESSO AO BANCO LOCAL MILENIO **/


/** SELECT **/
    public  SqlConnection sqlConnection(){
        string connectionString = null; 
        SqlConnection cnn ; 
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        var query = db.QuerySingle("select server, db, uid, pwd from acesso");
        db.Close();
        connectionString=String.Format("server={0}; database={1}; uid={2}; pwd={3}; Connection Timeout=1000;", query.server, query.db, query.uid, query.pwd);
        cnn = new SqlConnection(connectionString); 
        try 
        { 
            cnn.Open(); 
            
        } catch (Exception ex) 
        { 
            message = ex.StackTrace + " - " + ex.Message;
        }       
        return cnn;
    }
        

    public  List<Secao> ListaSecao()
    {
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;

        List<Secao> secoes = new List<Secao>();
        string sqlS = "SELECT SECCOD, SECDES FROM SECAO where SECCOD BETWEEN '01' AND '16' ORDER BY SECCOD";
       try
        {
            command = new SqlCommand(sqlS, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Secao g = new Secao();
                g.seccod = dataReader.GetValue(0).ToString();
                g.secdes = dataReader.GetValue(1).ToString();
                secoes.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return secoes;
    }

    public List<PorSecao> CompraPorSecaoFLV(String loja, String datainicial, String datafinal)
    {       
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> resultado = new List<PorSecao>();
        double valor = 0d;
        string sqlCG = "SELECT ";
        sqlCG+="SUM(ISNULL(IE.ITECSTREPFSC, 0) * ISNULL(IE.ITEQTDITEEMB, 0) * ISNULL(IE.ITEQTDEMB, 0)) AS TOTAL ";
        sqlCG+="FROM ITEM_ENTRADA IE ";
        sqlCG+="INNER JOIN V_ENTRADA E on E.LOJCOD = IE.LOJCOD AND E.ENTCOD = IE.ENTCOD ";
        sqlCG+="INNER JOIN V_LOJA L on E.LOJCOD = L.LOJCOD ";
        sqlCG+="INNER JOIN CUSTO C on IE.LOJCOD = C.LOJCOD and IE.REFPLU = C.REFPLU ";
        sqlCG+="INNER JOIN V_FORNECEDOR F ON F.AGECOD = E.AGECOD ";
        sqlCG+="INNER JOIN REFERENCIA R on IE.REFPLU = R.REFPLU ";
        sqlCG+="INNER JOIN PRODUTO P on R.PROCOD = P.PROCOD LEFT ";
        sqlCG+="JOIN FINALIDADE_PRODUTO_LOJA FPL ON FPL.PROCOD = P.PROCOD AND FPL.LOJCOD = E.LOJCOD ";
        sqlCG+="INNER JOIN SECAO S on P.SECCOD = S.SECCOD ";
        sqlCG+="INNER JOIN GRUPO G on S.SECCOD = G.SECCOD ";
        sqlCG+="AND P.GRPCOD = G.GRPCOD ";
        sqlCG+="WHERE E.DOCSTA = 'E' ";
        sqlCG+="AND (E.DOCSTANFE IS NULL OR E.DOCSTANFE = 'A') ";
        sqlCG+="AND EXISTS (select EXISTS_H.HOLCOD ";
        sqlCG+="from HOLDING EXISTS_H ";
        sqlCG+="inner join V_LOJA EXISTS_L on EXISTS_L.HOLCOD = EXISTS_H.HOLCOD ";
        sqlCG+="inner join V_LOJA_ACESSO_FUNCIONARIO VLAF on VLAF.LOJCOD = EXISTS_L.LOJCOD ";
        sqlCG+="where L.HOLCOD = EXISTS_L.HOLCOD AND VLAF.FUNCOD = '000088' ";
        sqlCG+="group by EXISTS_H.HOLCOD) ";
        if(loja!="000000"){
        sqlCG+="AND E.LOJCOD in ('{0}') ";
        sqlCG+="AND E.ENTDATENT BETWEEN '{1}' AND '{2}' ";
        } else {
        sqlCG+="AND E.ENTDATENT BETWEEN '{0}' AND '{1}' ";          
        }
        sqlCG+="AND COALESCE(FPL.FPLTIP, P.PROTIP) IN ('1') ";
        sqlCG+="AND E.DOCCMPVDA = 'S' AND P.SECCOD = '08' AND P.GRPCOD='001' ";
        //sqlCG+="GROUP BY P.SECCOD, s.SECDES";
        
        if(loja!="000000"){
            sqlCG = String.Format(sqlCG, loja, datainicial, datafinal);
        } else {
            sqlCG = String.Format(sqlCG, datainicial, datafinal);
        }
                
        try
        {
            command = new SqlCommand(sqlCG, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = "100";
                g.secdes = "FLV";
                valor = Convert.ToDouble(dataReader.GetValue(0).ToString());
                g.total = valor;
                resultado.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        
        return resultado;
    }
        
    public List<PorSecao> CompraPorSecao(String loja, String datainicial, String datafinal)
    {    	
	    SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> resultado = new List<PorSecao>();
        double valor = 0d;
        string sqlCG = "SELECT P.SECCOD As SECAO, S.SECDES AS SECDES, ";
        sqlCG+="SUM(ISNULL(IE.ITECSTREPFSC, 0) * ISNULL(IE.ITEQTDITEEMB, 0) * ISNULL(IE.ITEQTDEMB, 0)) AS TOTAL ";
        sqlCG+="FROM ITEM_ENTRADA IE ";
        sqlCG+="INNER JOIN V_ENTRADA E on E.LOJCOD = IE.LOJCOD AND E.ENTCOD = IE.ENTCOD ";
        sqlCG+="INNER JOIN V_LOJA L on E.LOJCOD = L.LOJCOD ";
        sqlCG+="INNER JOIN CUSTO C on IE.LOJCOD = C.LOJCOD and IE.REFPLU = C.REFPLU ";
        sqlCG+="INNER JOIN V_FORNECEDOR F ON F.AGECOD = E.AGECOD ";
        sqlCG+="INNER JOIN REFERENCIA R on IE.REFPLU = R.REFPLU ";
        sqlCG+="INNER JOIN PRODUTO P on R.PROCOD = P.PROCOD LEFT ";
        sqlCG+="JOIN FINALIDADE_PRODUTO_LOJA FPL ON FPL.PROCOD = P.PROCOD AND FPL.LOJCOD = E.LOJCOD ";
        sqlCG+="INNER JOIN SECAO S on P.SECCOD = S.SECCOD ";
        sqlCG+="WHERE E.DOCSTA = 'E' ";
        sqlCG+="AND (E.DOCSTANFE IS NULL OR E.DOCSTANFE = 'A') ";
        sqlCG+="AND EXISTS (select EXISTS_H.HOLCOD ";
        sqlCG+="from HOLDING EXISTS_H ";
        sqlCG+="inner join V_LOJA EXISTS_L on EXISTS_L.HOLCOD = EXISTS_H.HOLCOD ";
        sqlCG+="inner join V_LOJA_ACESSO_FUNCIONARIO VLAF on VLAF.LOJCOD = EXISTS_L.LOJCOD ";
        sqlCG+="where L.HOLCOD = EXISTS_L.HOLCOD AND VLAF.FUNCOD = '000088' ";
        sqlCG+="group by EXISTS_H.HOLCOD) ";
        if(loja!="000000"){
        sqlCG+="AND E.LOJCOD in ('{0}') ";
        sqlCG+="AND E.ENTDATENT BETWEEN '{1}' AND '{2}' ";
        } else {
        sqlCG+="AND E.ENTDATENT BETWEEN '{0}' AND '{1}' ";          
        }
        sqlCG+="AND COALESCE(FPL.FPLTIP, P.PROTIP) IN ('1') ";
        sqlCG+="AND E.DOCCMPVDA = 'S' AND P.SECCOD between '01' and '16' ";
        sqlCG+="GROUP BY P.SECCOD, s.SECDES";
        
        if(loja!="000000"){
            sqlCG = String.Format(sqlCG, loja, datainicial, datafinal);
        } else {
            sqlCG = String.Format(sqlCG, datainicial, datafinal);
        }
                
        try
        {
            command = new SqlCommand(sqlCG, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = dataReader.GetValue(0).ToString();
                g.secdes = dataReader.GetValue(1).ToString();
                valor = Convert.ToDouble(dataReader.GetValue(2).ToString());
                g.total = valor;
                resultado.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        
	 	return resultado;
	}

    public List<PorSecao> VendaParceiroPorSecao(String loja, String datainicial, String datafinal)
    {    	
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlVP = "SELECT PrODUTO.SECCOD AS SECAO, SECAO.SECDES AS SECDES, ";
        sqlVP+="SUM(ITEM_SAIDA.ITSVLRTOT) AS TOTAL ";
        sqlVP+="FROM SAIDA  ";
        sqlVP+="INNER JOIN DOCUMENTO ON (SAIDA.LOJCOD = DOCUMENTO.LOJCOD) AND (SAIDA.SAICOD = DOCUMENTO.DOCCOD)  ";
        sqlVP+="INNER JOIN V_LOJA LJ ON (DOCUMENTO.LOJCOD = LJ.LOJCOD)  ";
        sqlVP+="INNER JOIN OPERACAO ON (DOCUMENTO.OPECOD = OPERACAO.OPECOD)  ";
        sqlVP+="LEFT JOIN V_FUNCIONARIO ON (V_FUNCIONARIO.FUNCOD = DOCUMENTO.FUNCODEMI)  ";
        sqlVP+="LEFT JOIN ITEM_SAIDA ON (SAIDA.LOJCOD = ITEM_SAIDA.LOJCOD) AND (SAIDA.SAICOD = ITEM_SAIDA.SAICOD)  ";
        sqlVP+="LEFT JOIN REFERENCIA ON (ITEM_SAIDA.REFPLU = REFERENCIA.REFPLU)  ";
        sqlVP+="LEFT JOIN PRODUTO ON (REFERENCIA.PROCOD = PRODUTO.PROCOD)  ";
        sqlVP+="LEFT JOIN SECAO ON (SECAO.SECCOD = PRODUTO.SECCOD)  ";
        sqlVP+="LEFT JOIN V_CLIENTE V ON (DOCUMENTO.AGECOD = V.AGECOD) ";
        sqlVP+="LEFT JOIN LOCAL ON (LOCAL.LOJCOD = DOCUMENTO.LOJCOD) AND (LOCAL.LOCCOD = DOCUMENTO.LOCCOD)  ";
        sqlVP+="WHERE EXISTS  ";
        sqlVP+="(select EXISTS_H.HOLCOD  ";
        sqlVP+="from HOLDING EXISTS_H  ";
        sqlVP+="inner join V_LOJA EXISTS_L on EXISTS_L.HOLCOD = EXISTS_H.HOLCOD  ";
        sqlVP+="inner join V_LOJA_ACESSO_FUNCIONARIO VLAF on VLAF.LOJCOD = EXISTS_L.LOJCOD  ";
        sqlVP+="where LJ.HOLCOD = EXISTS_L.HOLCOD AND VLAF.FUNCOD = '000088'  ";
        sqlVP+="group by EXISTS_H.HOLCOD)  ";
        if(loja!="000000"){
        sqlVP+="AND SAIDA.LOJCOD IN ('{0}')  ";
        sqlVP+="AND (V.CLICOD = '000002' or v.clicod='000003' or v.clicod='000005' or v.clicod='000006' or v.clicod='000705' or v.clicod='000714' or v.clicod='000719' or v.clicod='000362' or v.clicod='000642' or v.clicod='000643' or v.clicod='000644' or v.clicod='000705' or v.clicod='000706' or v.clicod='000708' or v.clicod='000709' or v.clicod='000716') ";
        sqlVP+="AND ITEM_SAIDA.ITSTIP = 'E'  ";
        sqlVP+="AND REFERENCIA.REFCMP <> 'K'  ";
        sqlVP+="AND SAIDA.SAIDATSAI BETWEEN '{1}' AND '{2}' ";
        } else {
        sqlVP+="AND (V.CLICOD = '000002' or v.clicod='000003' or v.clicod='000005' or v.clicod='000006' or v.clicod='000705' or v.clicod='000714' or v.clicod='000719' or v.clicod='000362' or v.clicod='000642' or v.clicod='000643' or v.clicod='000644' or v.clicod='000705' or v.clicod='000706' or v.clicod='000708' or v.clicod='000709' or v.clicod='000716') ";
        sqlVP+="AND ITEM_SAIDA.ITSTIP = 'E'  ";
        sqlVP+="AND REFERENCIA.REFCMP <> 'K'  ";
        sqlVP+="AND SAIDA.SAIDATSAI BETWEEN '{0}' AND '{1}' ";          
        }
        sqlVP+="AND DOCSTA IN ('E') AND PRODUTO.SECCOD BETWEEN '01' AND '16' ";
        sqlVP+="GROUP BY PRODUTO.SECCOD, SECAO.SECDES  ";

        if(loja!="000000"){
            sqlVP = String.Format(sqlVP, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlVP = String.Format(sqlVP, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlVP, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = dataReader.GetValue(0).ToString();
                g.secdes = dataReader.GetValue(1).ToString();
                valor = Convert.ToDouble(dataReader.GetValue(2).ToString());
                g.total = valor;
                retorno.Add(g);
            }

        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
	}

    public List<PorSecao> EntradaTransferenciaDiariaPorSecao(String loja, String datainicial, String datafinal)
    {    	
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlET = "SELECT PRODUTO.SECCOD, SECAO.SECDES, ";
         sqlET+="sum(ITEM_ENTRADA.ITEVLRTOT) ";
         sqlET+="FROM V_ENTRADA ENTRADA ";
         sqlET+="INNER JOIN DOCUMENTO ON (ENTRADA.LOJCOD = DOCUMENTO.LOJCOD) ";
         sqlET+="AND (ENTRADA.ENTCOD = DOCUMENTO.DOCCOD) "; 
         sqlET+="INNER JOIN V_LOJA ON (ENTRADA.LOJCOD = V_LOJA.LOJCOD) ";
         sqlET+="LEFT JOIN ITEM_ENTRADA ON (ENTRADA.LOJCOD = ITEM_ENTRADA.LOJCOD) ";
         sqlET+="AND (ENTRADA.ENTCOD = ITEM_ENTRADA.ENTCOD) ";
         sqlET+="LEFT JOIN REFERENCIA ON (ITEM_ENTRADA.REFPLU = REFERENCIA.REFPLU) ";
         sqlET+="LEFT JOIN PRODUTO ON (REFERENCIA.PROCOD = PRODUTO.PROCOD) ";
         sqlET+="LEFT JOIN SECAO ON (SECAO.SECCOD = PRODUTO.SECCOD)  ";         
         sqlET+="LEFT JOIN LOCAL ON (LOCAL.LOJCOD = DOCUMENTO.LOJCOD) ";
         sqlET+="AND (LOCAL.LOCCOD = DOCUMENTO.LOCCOD) ";
         sqlET+="WHERE DOCUMENTO.LOCCOD BETWEEN '001' AND '001' ";
         sqlET+="AND PRODUTO.SECCOD BETWEEN '01' AND '16' ";
         sqlET+="AND DOCUMENTO.OPECOD = '000016' ";

        if(loja!="000000"){
            sqlET+="AND ENTRADA.LOJCOD='{0}' AND DOCUMENTO.DOCDAT BETWEEN '{1}' AND '{2}'  ";
        } else {
            sqlET+="AND ENTRADA.ENTDATENT BETWEEN '{0}' AND '{1}'  ";
        }
        sqlET+="AND DOCUMENTO.DOCSTA IN ('E')  ";

        sqlET+="GROUP BY PRODUTO.SECCOD, SECAO.SECDES  ";
        
        if(loja!="000000"){
            sqlET = String.Format(sqlET, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlET = String.Format(sqlET, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlET, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = dataReader.GetValue(0).ToString();
                g.secdes = dataReader.GetValue(1).ToString();
                valor = Convert.ToDouble(dataReader.GetValue(2).ToString());
                g.total = valor;
                retorno.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
	}

    public List<PorSecao> QuebraDiariaPorSecao(String loja, String datainicial, String datafinal)
    {       
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlEt = "SELECT S.SECCOD AS SECCOD, ";
        sqlEt+="S.SECDES AS DESCRICAO, ";
        sqlEt+="sum(isnull(A.AJUQTD, 0) * isnull(A.AJUCSTREP, 0)) AS TOTAL_CUSTO ";
        sqlEt+="FROM AJUSTE A ";
        sqlEt+="INNER JOIN V_FUNCIONARIO F ON A.FUNCOD=F.FUNCOD ";
        sqlEt+="INNER JOIN V_LOJA L ON (A.LOJCOD=L.LOJCOD) ";
        sqlEt+="INNER JOIN LOCAL LC ON A.LOCCOD=LC.LOCCOD ";
        sqlEt+="AND A.LOJCOD=LC.LOJCOD ";
        sqlEt+="INNER JOIN REFERENCIA R ON R.REFPLU=A.REFPLU ";
        sqlEt+="INNER JOIN PRODUTO P ON R.PROCOD=P.PROCOD ";
        sqlEt+="INNER JOIN V_FORNECEDOR FN ON R.FORCOD = FN.FORCOD ";
        sqlEt+="INNER JOIN SECAO S ON S.SECCOD = P.SECCOD ";
        sqlEt+="INNER JOIN GRUPO G ON S.SECCOD = G.SECCOD ";
        sqlEt+="AND P.GRPCOD = G.GRPCOD ";
        sqlEt+="INNER JOIN TIPO_OPERACAO_ESTOQUE T ON A.TOECOD = T.TOECOD ";
        sqlEt+="INNER JOIN SUBGRUPO SG ON S.SECCOD = SG.SECCOD ";
        sqlEt+="AND P.GRPCOD = SG.GRPCOD ";
        sqlEt+="AND P.SBGCOD = SG.SBGCOD ";
        sqlEt+="WHERE 1=1 ";
        sqlEt+="AND A.LOCCOD IN ('001') ";
        //sqlEt+="AND S.SECCOD BETWEEN'08' AND '08' ;"
        //sqlEt+="AND G.GRPCOD BETWEEN'001' AND '001' ;"
        sqlEt+="AND A.TOECOD = '02' ";
        sqlEt+="AND T.TOETIP = 'Q' ";


        if(loja!="000000"){
            sqlEt+="AND A.LOJCOD='{0}' AND A.AJUDAT BETWEEN '{1}' AND '{2}'  ";
        } else {
            sqlEt+="AND A.AJUDAT BETWEEN '{0}' AND '{1}'  ";
        }
        
        sqlEt+="GROUP BY S.SECCOD, ";
        sqlEt+="S.SECDES ";
        sqlEt+="ORDER BY S.SECCOD ";

        if(loja!="000000"){
            sqlEt = String.Format(sqlEt, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlEt = String.Format(sqlEt, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlEt, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = dataReader.GetValue(0).ToString();
                g.secdes = dataReader.GetValue(1).ToString();
                valor = Convert.ToDouble(dataReader.GetValue(2).ToString());
                g.total = valor;
                retorno.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
    }

    public List<PorSecao> QuebraDiariaPorSecaoFLV(String loja, String datainicial, String datafinal)
    {       
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlEt = "SELECT ";
        sqlEt+="sum(isnull(A.AJUQTD, 0) * isnull(A.AJUCSTREP, 0)) AS TOTAL_CUSTO ";
        sqlEt+="FROM AJUSTE A ";
        sqlEt+="INNER JOIN V_FUNCIONARIO F ON A.FUNCOD=F.FUNCOD ";
        sqlEt+="INNER JOIN V_LOJA L ON (A.LOJCOD=L.LOJCOD) ";
        sqlEt+="INNER JOIN LOCAL LC ON A.LOCCOD=LC.LOCCOD ";
        sqlEt+="AND A.LOJCOD=LC.LOJCOD ";
        sqlEt+="INNER JOIN REFERENCIA R ON R.REFPLU=A.REFPLU ";
        sqlEt+="INNER JOIN PRODUTO P ON R.PROCOD=P.PROCOD ";
        sqlEt+="INNER JOIN V_FORNECEDOR FN ON R.FORCOD = FN.FORCOD ";
        sqlEt+="INNER JOIN SECAO S ON S.SECCOD = P.SECCOD ";
        sqlEt+="INNER JOIN GRUPO G ON S.SECCOD = G.SECCOD ";
        sqlEt+="AND P.GRPCOD = G.GRPCOD ";
        sqlEt+="INNER JOIN TIPO_OPERACAO_ESTOQUE T ON A.TOECOD = T.TOECOD ";
        sqlEt+="INNER JOIN SUBGRUPO SG ON S.SECCOD = SG.SECCOD ";
        sqlEt+="AND P.GRPCOD = SG.GRPCOD ";
        sqlEt+="AND P.SBGCOD=SG.SBGCOD ";
        sqlEt+="WHERE 1=1 ";
        sqlEt+="AND A.LOCCOD IN ('001') ";
        sqlEt+="AND S.SECCOD BETWEEN'08' AND '08' ";
        sqlEt+="AND G.GRPCOD BETWEEN'001' AND '001' ";
        sqlEt+="AND A.TOECOD = '02' ";
        sqlEt+="AND T.TOETIP = 'Q' ";

        if(loja!="000000"){
            sqlEt+="AND A.LOJCOD='{0}' AND A.AJUDAT BETWEEN '{1}' AND '{2}'  ";
        } else {
            sqlEt+="AND A.AJUDAT BETWEEN '{0}' AND '{1}'  ";
        }
        
        if(loja!="000000"){
            sqlEt = String.Format(sqlEt, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlEt = String.Format(sqlEt, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlEt, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = "100";
                g.secdes = "FLV";
                valor = Convert.ToDouble(dataReader.GetValue(0).ToString());
                g.total = valor;
                retorno.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
    }

    public List<PorSecao> EntradaTransferenciaDiariaPorSecaoFLV(String loja, String datainicial, String datafinal)
    {       
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlET = "SELECT ";
         sqlET+="sum(ITEM_ENTRADA.ITEVLRTOT) ";
         sqlET+="FROM V_ENTRADA ENTRADA ";
         sqlET+="INNER JOIN DOCUMENTO ON (ENTRADA.LOJCOD = DOCUMENTO.LOJCOD) ";
         sqlET+="AND (ENTRADA.ENTCOD = DOCUMENTO.DOCCOD) "; 
         sqlET+="INNER JOIN V_LOJA ON (ENTRADA.LOJCOD = V_LOJA.LOJCOD) ";
         sqlET+="LEFT JOIN ITEM_ENTRADA ON (ENTRADA.LOJCOD = ITEM_ENTRADA.LOJCOD) ";
         sqlET+="AND (ENTRADA.ENTCOD = ITEM_ENTRADA.ENTCOD) ";
         sqlET+="LEFT JOIN REFERENCIA ON (ITEM_ENTRADA.REFPLU = REFERENCIA.REFPLU) ";
         sqlET+="LEFT JOIN PRODUTO ON (REFERENCIA.PROCOD = PRODUTO.PROCOD) ";
         sqlET+="LEFT JOIN LOCAL ON (LOCAL.LOJCOD = DOCUMENTO.LOJCOD) ";
         sqlET+="AND (LOCAL.LOCCOD = DOCUMENTO.LOCCOD) ";
         sqlET+="WHERE DOCUMENTO.LOCCOD BETWEEN '001' AND '001' ";
         sqlET+="AND PRODUTO.SECCOD BETWEEN '08' AND '08' ";
         sqlET+="AND PRODUTO.GRPCOD BETWEEN '001' AND '001' ";
         sqlET+="AND DOCUMENTO.OPECOD = '000016' ";

        if(loja!="000000"){
            sqlET+="AND ENTRADA.LOJCOD='{0}' AND DOCUMENTO.DOCDAT BETWEEN '{1}' AND '{2}'  ";
        } else {
            sqlET+="AND ENTRADA.ENTDATENT BETWEEN '{0}' AND '{1}'  ";
        }
        sqlET+="AND DOCUMENTO.DOCSTA IN ('E')  ";
        
        if(loja!="000000"){
            sqlET = String.Format(sqlET, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlET = String.Format(sqlET, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlET, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = "100";
                g.secdes = "FLV";
                valor = Convert.ToDouble(dataReader.GetValue(0).ToString());
                g.total = valor;
                retorno.Add(g);
            }
        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
    }

    public List<PorSecao> SaidaTransferenciaDiariaPorSecao(String loja, String datainicial, String datafinal)
    {    	
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlST = "SELECT SECAO.SECCOD, SECAO.SECDES, ";
        sqlST+="SUM(ITEM_SAIDA.ITSVLRTOT) AS TOTAL "; 
        sqlST+="FROM SAIDA  ";
        sqlST+="INNER JOIN DOCUMENTO ON (SAIDA.LOJCOD = DOCUMENTO.LOJCOD) AND (SAIDA.SAICOD = DOCUMENTO.DOCCOD)  ";
        sqlST+="INNER JOIN V_LOJA LJ ON (DOCUMENTO.LOJCOD = LJ.LOJCOD)  ";
        sqlST+="INNER JOIN OPERACAO ON (DOCUMENTO.OPECOD = OPERACAO.OPECOD)  ";
        sqlST+="LEFT JOIN V_FUNCIONARIO ON (V_FUNCIONARIO.FUNCOD = DOCUMENTO.FUNCODEMI)  ";
        sqlST+="LEFT JOIN ITEM_SAIDA ON (SAIDA.LOJCOD = ITEM_SAIDA.LOJCOD) AND (SAIDA.SAICOD = ITEM_SAIDA.SAICOD)  ";
        sqlST+="LEFT JOIN REFERENCIA ON (ITEM_SAIDA.REFPLU = REFERENCIA.REFPLU)  ";
        sqlST+="LEFT JOIN PRODUTO ON (REFERENCIA.PROCOD = PRODUTO.PROCOD)  ";
        sqlST+="LEFT JOIN SECAO ON (SECAO.SECCOD = PRODUTO.SECCOD)  ";
        sqlST+="LEFT JOIN V_CLIENTE V ON (DOCUMENTO.AGECOD = V.AGECOD) ";
        sqlST+="LEFT JOIN LOCAL ON (LOCAL.LOJCOD = DOCUMENTO.LOJCOD) AND (LOCAL.LOCCOD = DOCUMENTO.LOCCOD)  ";
        sqlST+="WHERE EXISTS (select EXISTS_H.HOLCOD from HOLDING EXISTS_H inner join V_LOJA EXISTS_L on EXISTS_L.HOLCOD = EXISTS_H.HOLCOD  ";
        sqlST+="inner join V_LOJA_ACESSO_FUNCIONARIO VLAF on VLAF.LOJCOD = EXISTS_L.LOJCOD where LJ.HOLCOD = EXISTS_L.HOLCOD AND VLAF.FUNCOD = '000088'  ";
        sqlST+="group by EXISTS_H.HOLCOD)  ";
        if(loja!="000000"){
            sqlST+="AND SAIDA.LOJCOD IN ('{0}')  ";
            sqlST+="AND ITEM_SAIDA.ITSTIP = 'E'  ";
            sqlST+="AND REFERENCIA.REFCMP <> 'K'  ";
            sqlST+="AND EXISTS (SELECT * FROM PRODUTO P LEFT JOIN FINALIDADE_PRODUTO_LOJA FPL ON FPL.PROCOD = P.PROCOD AND FPL.LOJCOD = LJ.LOJCOD  ";
            sqlST+="WHERE COALESCE(FPL.FPLTIP, P.PROTIP) IN ('1') AND PRODUTO.PROCOD = P.PROCOD)  ";
            sqlST+="AND DOCUMENTO.OPECOD = '000014'  ";
            sqlST+="AND SAIDA.SAIDATSAI BETWEEN '{1}' AND '{2}'  ";
        } else {
            sqlST+="AND ITEM_SAIDA.ITSTIP = 'E'  ";
            sqlST+="AND REFERENCIA.REFCMP <> 'K'  ";
            sqlST+="AND EXISTS (SELECT * FROM PRODUTO P LEFT JOIN FINALIDADE_PRODUTO_LOJA FPL ON FPL.PROCOD = P.PROCOD AND FPL.LOJCOD = LJ.LOJCOD  ";
            sqlST+="WHERE COALESCE(FPL.FPLTIP, P.PROTIP) IN ('1') AND PRODUTO.PROCOD = P.PROCOD)  ";
            sqlST+="AND DOCUMENTO.OPECOD = '000014'  ";
            sqlST+="AND SAIDA.SAIDATSAI BETWEEN '{0}' AND '{1}'  ";         
        }
        sqlST+="AND DOCSTA IN ('E') AND SECAO.SECCOD BETWEEN '01' AND '16' ";
        sqlST+="GROUP BY SECAO.SECCOD, SECAO.SECDES ";
        if(loja!="000000"){
            sqlST = String.Format(sqlST, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlST = String.Format(sqlST, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlST, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = dataReader.GetValue(0).ToString();
                g.secdes = dataReader.GetValue(1).ToString();
                valor = Convert.ToDouble(dataReader.GetValue(2).ToString());
                g.total = valor;
                retorno.Add(g);
            }

        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
	}

    public List<PorSecao> SaidaTransferenciaDiariaPorSecaoFLV(String loja, String datainicial, String datafinal)
    {       
        SqlConnection db = sqlConnection() ;
        SqlCommand command ;
        SqlDataReader dataReader ;
        
        List<PorSecao> retorno = new List<PorSecao>();
        double valor = 0d;
        string sqlST = "SELECT ";
        sqlST+="SUM(ITEM_SAIDA.ITSVLRTOT) AS TOTAL "; 
        sqlST+="FROM SAIDA  ";
        sqlST+="INNER JOIN DOCUMENTO ON (SAIDA.LOJCOD = DOCUMENTO.LOJCOD) AND (SAIDA.SAICOD = DOCUMENTO.DOCCOD)  ";
        sqlST+="INNER JOIN V_LOJA LJ ON (DOCUMENTO.LOJCOD = LJ.LOJCOD)  ";
        sqlST+="INNER JOIN OPERACAO ON (DOCUMENTO.OPECOD = OPERACAO.OPECOD)  ";
        sqlST+="LEFT JOIN V_FUNCIONARIO ON (V_FUNCIONARIO.FUNCOD = DOCUMENTO.FUNCODEMI)  ";
        sqlST+="LEFT JOIN ITEM_SAIDA ON (SAIDA.LOJCOD = ITEM_SAIDA.LOJCOD) AND (SAIDA.SAICOD = ITEM_SAIDA.SAICOD)  ";
        sqlST+="LEFT JOIN REFERENCIA ON (ITEM_SAIDA.REFPLU = REFERENCIA.REFPLU)  ";
        sqlST+="LEFT JOIN PRODUTO ON (REFERENCIA.PROCOD = PRODUTO.PROCOD)  ";
        sqlST+="LEFT JOIN SECAO ON (SECAO.SECCOD = PRODUTO.SECCOD)  ";
        sqlST+="LEFT JOIN GRUPO ON (SECAO.SECCOD = GRUPO.SECCOD)  ";
        sqlST+="AND (GRUPO.GRPCOD = PRODUTO.GRPCOD)  ";
        sqlST+="LEFT JOIN V_CLIENTE V ON (DOCUMENTO.AGECOD = V.AGECOD) ";
        sqlST+="LEFT JOIN LOCAL ON (LOCAL.LOJCOD = DOCUMENTO.LOJCOD) AND (LOCAL.LOCCOD = DOCUMENTO.LOCCOD)  ";
        sqlST+="WHERE EXISTS (select EXISTS_H.HOLCOD from HOLDING EXISTS_H inner join V_LOJA EXISTS_L on EXISTS_L.HOLCOD = EXISTS_H.HOLCOD  ";
        sqlST+="inner join V_LOJA_ACESSO_FUNCIONARIO VLAF on VLAF.LOJCOD = EXISTS_L.LOJCOD where LJ.HOLCOD = EXISTS_L.HOLCOD AND VLAF.FUNCOD = '000088'  ";
        sqlST+="group by EXISTS_H.HOLCOD)  ";
        if(loja!="000000"){
            sqlST+="AND SAIDA.LOJCOD IN ('{0}')  ";
            sqlST+="AND ITEM_SAIDA.ITSTIP = 'E'  ";
            sqlST+="AND REFERENCIA.REFCMP <> 'K'  ";
            sqlST+="AND EXISTS (SELECT * FROM PRODUTO P LEFT JOIN FINALIDADE_PRODUTO_LOJA FPL ON FPL.PROCOD = P.PROCOD AND FPL.LOJCOD = LJ.LOJCOD  ";
            sqlST+="WHERE COALESCE(FPL.FPLTIP, P.PROTIP) IN ('1') AND PRODUTO.PROCOD = P.PROCOD)  ";
            sqlST+="AND DOCUMENTO.OPECOD = '000014'  ";
            sqlST+="AND SAIDA.SAIDATSAI BETWEEN '{1}' AND '{2}'  ";
        } else {
            sqlST+="AND ITEM_SAIDA.ITSTIP = 'E'  ";
            sqlST+="AND REFERENCIA.REFCMP <> 'K'  ";
            sqlST+="AND EXISTS (SELECT * FROM PRODUTO P LEFT JOIN FINALIDADE_PRODUTO_LOJA FPL ON FPL.PROCOD = P.PROCOD AND FPL.LOJCOD = LJ.LOJCOD  ";
            sqlST+="WHERE COALESCE(FPL.FPLTIP, P.PROTIP) IN ('1') AND PRODUTO.PROCOD = P.PROCOD)  ";
            sqlST+="AND DOCUMENTO.OPECOD = '000014'  ";
            sqlST+="AND SAIDA.SAIDATSAI BETWEEN '{0}' AND '{1}'  ";         
        }
        sqlST+="AND DOCSTA IN ('E') AND SECAO.SECCOD ='08' AND GRUPO.GRPCOD='001' ";
    
        if(loja!="000000"){
            sqlST = String.Format(sqlST, loja, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        } else {
            sqlST = String.Format(sqlST, DateTime.Parse(datainicial).ToString("yyyy-MM-dd"), DateTime.Parse(datafinal).ToString("yyyy-MM-dd"));
        }
        
        try
        {
            command = new SqlCommand(sqlST, db);
            command.CommandTimeout = 1000;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                PorSecao g = new PorSecao();
                g.seccod = "100";
                g.secdes = "FLV";
                valor = Convert.ToDouble(dataReader.GetValue(0).ToString());
                g.total = valor;
                retorno.Add(g);
            }

        }
        catch (Exception ex){
            message = ex.StackTrace + " - " + ex.Message;
        }
        db.Close();
        return retorno;
    }


	/** ACESSO AO BANCO LOCAL RESUMOVENDA.SDF **/


/** SELECT **/

 	  public List<Validar> validardias(DateTime diainicial, DateTime diafinal, String loja){
		List<Validar> validar = new List<Validar>();
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		string sqlStr = string.Empty;
		sqlStr = "select diadavenda, sum(valor) valor from VendaDiaria where loja=@0 and diadavenda between @1 and @2 group by diadavenda";
		var sql = db.Query(sqlStr, loja, diainicial, diafinal);
		db.Close();
		foreach(var s in sql){
			Validar v = new Validar(s.diadavenda,s.valor);
			validar.Add(v);
		}
		return validar;    	
	  }

      public decimal retornaValorLoja(DateTime diainicial, DateTime diafinal, string loja, string seccod)
      {
        //VendaDiaria
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        string sqlStr = string.Empty;
        if(loja=="000000")
        {
            sqlStr = "select sum(valor) valor from VendaDiaria where diadavenda between @1 and @2 and seccod=@3";    
        }
        else
        {
            sqlStr = "select sum(valor) valor from VendaDiaria where loja=@0 and diadavenda between @1 and @2 and seccod=@3";
        }
        
        var sql = db.Query(sqlStr, loja, diainicial.ToString("yyyy-MM-dd 00:00:00"), diafinal.ToString("yyyy-MM-dd 23:59:59"), seccod);
        db.Close();
        decimal valor = 0;
        foreach(var s in sql){
            try
            {
                valor = s.valor;
            } catch{
                valor=0;
            }
        }
        return valor;
      }

      public decimal retornaQuebraLoja(DateTime diainicial, DateTime diafinal, string loja, string seccod)
      {
        //VendaDiaria
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        string sqlStr = string.Empty;
        if(loja=="000000")
        {
            sqlStr = "select sum(valor) valor from QuebraDiaria where diadaquebra between @1 and @2 and seccod=@3";
        }
        else
        {
           sqlStr = "select sum(valor) valor from QuebraDiaria where loja=@0 and diadaquebra between @1 and @2 and seccod=@3"; 
        }
        
        var sql = db.Query(sqlStr, loja, diainicial.ToString("yyyy-MM-dd 00:00:00"), diafinal.ToString("yyyy-MM-dd 23:59:59"), seccod);
        db.Close();
        decimal valor = 0;
        foreach(var s in sql){
            try
            {
                valor = s.valor;
            } catch{
                valor=0;
            }
        }
        return valor;
      }
       
      public decimal retornaVendaParceiroLoja(DateTime diainicial, DateTime diafinal, string loja, string seccod)
      {
        //VendaDiaria
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        string sqlStr = string.Empty;
        if(loja=="000000")
        {
            sqlStr = "select sum(valor) valor from VendaParceiro where diadavenda between @1 and @2 and seccod=@3";
        }
        else
        {
            sqlStr = "select sum(valor) valor from VendaParceiro where loja=@0 and diadavenda between @1 and @2 and seccod=@3";
        }
        
        var sql = db.Query(sqlStr, loja, diainicial.ToString("yyyy-MM-dd 00:00:00"), diafinal.ToString("yyyy-MM-dd 23:59:59"), seccod);
        db.Close();
        decimal valor = 0;
        foreach(var s in sql){
            try
            {
                valor = s.valor;
            } catch{
                valor=0;
            }
        }
        return valor;
      }
      
      public decimal retornaEntradaTransferenciaLoja(DateTime diainicial, DateTime diafinal, string loja, string seccod)
      {
        //VendaDiaria
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        string sqlStr = string.Empty;
        if(loja=="000000")
        {
            sqlStr = "select sum(valor) valor from EntradaTransferenciaDiaria where diadaentrada between @1 and @2 and seccod=@3";
        }
        else
        {
            sqlStr = "select sum(valor) valor from EntradaTransferenciaDiaria where loja=@0 and diadaentrada between @1 and @2 and seccod=@3";
        }
        
        var sql = db.Query(sqlStr, loja, diainicial.ToString("yyyy-MM-dd 00:00:00"), diafinal.ToString("yyyy-MM-dd 23:59:59"), seccod);
        db.Close();
        decimal valor = 0;
        foreach(var s in sql){
            try
            {
                valor = s.valor;
            } catch{
                valor=0;
            }
        }
        return valor;
      }

      public decimal retornaSaidaTransferenciaLoja(DateTime diainicial, DateTime diafinal, string loja, string seccod)
      {
        //VendaDiaria
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        string sqlStr = string.Empty;
        if(loja=="000000")
        {
            sqlStr = "select sum(valor) valor from SaidaTransferenciaDiaria where diadasaida between @1 and @2 and seccod=@3";
        }
        else
        {
            sqlStr = "select sum(valor) valor from SaidaTransferenciaDiaria where loja=@0 and diadasaida between @1 and @2 and seccod=@3";
        }
        
        var sql = db.Query(sqlStr, loja, diainicial.ToString("yyyy-MM-dd 00:00:00"), diafinal.ToString("yyyy-MM-dd 23:59:59"), seccod);
        db.Close();
        decimal valor = 0;
        foreach(var s in sql){
            try
            {
                valor = s.valor;
            } catch{
                valor=0;
            }
        }
        return valor;
      }

	  public decimal retornaCompraLoja(DateTime diainicial, DateTime diafinal, string loja, string seccod)
	  {
        //VendaDiaria
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		string sqlStr = string.Empty;
        if(loja=="000000")
        {
            sqlStr = "select sum(valor) valor from CompraDiaria where diadacompra between @1 and @2 and seccod=@3";
        }
        else
        {
            sqlStr = "select sum(valor) valor from CompraDiaria where loja=@0 and diadacompra between @1 and @2 and seccod=@3";
        }
		
		var sql = db.Query(sqlStr, loja, diainicial.ToString("yyyy-MM-dd 00:00:00"), diafinal.ToString("yyyy-MM-dd 23:59:59"), seccod);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;
	  }

      public List<VendaDiaria> relatorioDiario(string loja, DateTime inicial, DateTime final){
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        List<VendaDiaria> relatorio = new List<VendaDiaria>();
		string sqlStr = string.Empty;
		if(loja.Equals("000000"))
		{
			sqlStr = "select seccod, secdes, sum(valor) total from VendaDiaria where diadavenda between @1 and @2 and seccod<>'100' group by seccod, secdes";
		}
		else
		{
			sqlStr = "select seccod, secdes, sum(valor) total from VendaDiaria where loja=@0 and diadavenda between @1 and @2 and seccod<>'100' group by seccod, secdes";
		}
        var sql = db.Query(sqlStr, loja, inicial, final);
        foreach(var s in sql){
            VendaDiaria v = new VendaDiaria(loja, s.seccod, s.secdes, DateTime.Now, s.total);    
            relatorio.Add(v);
        }
        db.Close();
        return relatorio;          
       }
	  
	   public decimal puxaVendaDia(string loja, string dia, string secao){
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        string sqlStr = string.Empty;
		if(loja.Equals("000000"))
		{
			sqlStr = "select valor from VendaDiaria where diadavenda = @1 and seccod = @2";
		}
		else
		{
			sqlStr = "select valor from VendaDiaria where loja=@0 and diadavenda = @1 and seccod = @2";
		}
        var sql = db.Query(sqlStr, loja, dia, secao);
		db.Close();
        foreach(var s in sql){
			
            return s.valor;
        }
        return 0;          
      }
	  
      public bool vendaGravada(string loja, DateTime dia){
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        var sql = db.QuerySingle("select top 1 id from VendaDiaria where LOJA=@0 AND diadavenda between @1 and @2", loja, dia.ToString("yyyy-MM-dd 00:00:00"), dia.ToString("yyyy-MM-dd 23:59:59"));
        db.Close();
        bool retorno=false;
        if(sql!=null)
        {
            retorno=true;
        }
        return retorno;          
      }
	  
      public bool compraGravada(string loja, DateTime dia){
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        var sql = db.QuerySingle("select top 1 id from CompraDiaria where LOJA=@0 AND diadacompra between @1 and @2", loja, dia.ToString("yyyy-MM-dd 00:00:00"), dia.ToString("yyyy-MM-dd 23:59:59"));
        db.Close();
        bool retorno=false;
        if(sql!=null)
        {
            retorno=true;
        }
        return retorno;          
      }      

      public bool compraGravadaFLV(string loja, DateTime dia){
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        var sql = db.QuerySingle("select TOP 1 id from CompraDiaria where LOJA=@0 AND diadacompra between @1 and @2 and SECCOD='100'", loja, dia.ToString("yyyy-MM-dd 00:00:00"), dia.ToString("yyyy-MM-dd 23:59:59"));
        db.Close();
        bool retorno=false;

        if(sql!=null)
        {
             retorno=true;
        }
        return retorno;          
      }      

/** AUXILIARES **/

	public decimal buscarVenda(int dia,string mes,string ano, string loja)
	{
		String data = String.Empty;
		switch(mes)
		{
			case "JANEIRO":
				data=dia.ToString("00")+"/"+"01"+"/"+ano;
				break;
			case "FEVEREIRO":
				data=dia.ToString("00")+"/"+"02"+"/"+ano;
				break;
			case "MARÇO":
				data=dia.ToString("00")+"/"+"03"+"/"+ano;
				break;
			case "ABRIL":
				data=dia.ToString("00")+"/"+"04"+"/"+ano;
				break;
			case "MAIO":
				data=dia.ToString("00")+"/"+"05"+"/"+ano;
				break;
			case "JUNHO":
				data=dia.ToString("00")+"/"+"06"+"/"+ano;
				break;
			case "JULHO":
				data=dia.ToString("00")+"/"+"07"+"/"+ano;
				break;
			case "AGOSTO":
				data=dia.ToString("00")+"/"+"08"+"/"+ano;
				break;
			case "SETEMBRO":
				data=dia.ToString("00")+"/"+"09"+"/"+ano;
				break;
			case "OUTUBRO":
				data=dia.ToString("00")+"/"+"10"+"/"+ano;
				break;
			case "NOVEMBRO":
				data=dia.ToString("00")+"/"+"11"+"/"+ano;
				break;
			case "DEZEMBRO":
				data=dia.ToString("00")+"/"+"12"+"/"+ano;
				break;
		}		
		decimal vendaRecarga = 0;
		try {
			vendaRecarga = totalVenda(DateTime.Parse(data), DateTime.Parse(data), int.Parse(loja).ToString("000000"));
		} catch{
			message = "data: " + data + "loja: " + loja;
		}
		return vendaRecarga;
	}
	
	public decimal buscarVendaRecarga(int dia,string mes,string ano, string loja)
	{
		String data = String.Empty;
		switch(mes)
		{
			case "JANEIRO":
				data=dia.ToString("00")+"/"+"01"+"/"+ano;
				break;
			case "FEVEREIRO":
				data=dia.ToString("00")+"/"+"02"+"/"+ano;
				break;
			case "MARÇO":
				data=dia.ToString("00")+"/"+"03"+"/"+ano;
				break;
			case "ABRIL":
				data=dia.ToString("00")+"/"+"04"+"/"+ano;
				break;
			case "MAIO":
				data=dia.ToString("00")+"/"+"05"+"/"+ano;
				break;
			case "JUNHO":
				data=dia.ToString("00")+"/"+"06"+"/"+ano;
				break;
			case "JULHO":
				data=dia.ToString("00")+"/"+"07"+"/"+ano;
				break;
			case "AGOSTO":
				data=dia.ToString("00")+"/"+"08"+"/"+ano;
				break;
			case "SETEMBRO":
				data=dia.ToString("00")+"/"+"09"+"/"+ano;
				break;
			case "OUTUBRO":
				data=dia.ToString("00")+"/"+"10"+"/"+ano;
				break;
			case "NOVEMBRO":
				data=dia.ToString("00")+"/"+"11"+"/"+ano;
				break;
			case "DEZEMBRO":
				data=dia.ToString("00")+"/"+"12"+"/"+ano;
				break;
		}		
		decimal vendaRecarga = 0;
		try {
			vendaRecarga = totalRecarga(DateTime.Parse(data), DateTime.Parse(data), int.Parse(loja).ToString("000000"))+totalVenda(DateTime.Parse(data), DateTime.Parse(data), int.Parse(loja).ToString("000000"));
		} catch{
			message = "data: " + data + "loja: " + loja;
		}
		
		return vendaRecarga;
	}

	
	public decimal buscarCliente(int dia,string mes,string ano, string loja)
	{
		String data = String.Empty;
		switch(mes)
		{
			case "JANEIRO":
				data=dia.ToString("00")+"/"+"01"+"/"+ano;
				break;
			case "FEVEREIRO":
				data=dia.ToString("00")+"/"+"02"+"/"+ano;
				break;
			case "MARÇO":
				data=dia.ToString("00")+"/"+"03"+"/"+ano;
				break;
			case "ABRIL":
				data=dia.ToString("00")+"/"+"04"+"/"+ano;
				break;
			case "MAIO":
				data=dia.ToString("00")+"/"+"05"+"/"+ano;
				break;
			case "JUNHO":
				data=dia.ToString("00")+"/"+"06"+"/"+ano;
				break;
			case "JULHO":
				data=dia.ToString("00")+"/"+"07"+"/"+ano;
				break;
			case "AGOSTO":
				data=dia.ToString("00")+"/"+"08"+"/"+ano;
				break;
			case "SETEMBRO":
				data=dia.ToString("00")+"/"+"09"+"/"+ano;
				break;
			case "OUTUBRO":
				data=dia.ToString("00")+"/"+"10"+"/"+ano;
				break;
			case "NOVEMBRO":
				data=dia.ToString("00")+"/"+"11"+"/"+ano;
				break;
			case "DEZEMBRO":
				data=dia.ToString("00")+"/"+"12"+"/"+ano;
				break;
		}		
		decimal vendaRecarga = 0;
		try {
			vendaRecarga = totalCliente(DateTime.Parse(data), DateTime.Parse(data), int.Parse(loja).ToString("000000"));
		} catch{
			message = "data: " + data + "loja: " + loja;
		}
		return vendaRecarga;
	}


    public decimal retornaPercentual(string Operadora)
    {
    	switch(Operadora)
    	{
    		case "Claro": return 4.5m; break;
    		case "Oi": return 5.4m; break;
    		case "Vivo": return 4.0m; break;
    		case "Tim": return 4.2m; break;
    	}
    	return 0m;
    }

    public Claro retornaClaro(List<Recarga> recarga, string Loja)
    {
    	Claro c = new Claro();
    	string op = "Claro";
    	try {
    		c = new Claro(recarga.Find(i=>i.Operadora.Equals(op)).Valor, Loja, recarga.Find(i=>i.Operadora.Equals(op)).Percentual);
    	} catch {
    		c = new Claro(0,Loja,0);
    	}
		return c;
    }

    public Oi retornaOi(List<Recarga> recarga, string Loja)
    {
    	Oi c = new Oi();
    	string op = "Oi";
    	try {
	    	c = new Oi(recarga.Find(i=>i.Operadora.Equals(op)).Valor, Loja, recarga.Find(i=>i.Operadora.Equals(op)).Percentual);
    	} catch {
    		c = new Oi(0,Loja,0);
    	}
		return c;
    }

    public Vivo retornaVivo(List<Recarga> recarga, string Loja)
    {
    	Vivo c = new Vivo();
    	string op = "Vivo";
    	try {
	    	c = new Vivo(recarga.Find(i=>i.Operadora.Equals(op)).Valor, Loja, recarga.Find(i=>i.Operadora.Equals(op)).Percentual);
    	} catch {
    		c = new Vivo(0,Loja,0);
    	}
		return c;
    }

    public Tim retornaTim(List<Recarga> recarga, string Loja)
    {
    	Tim c = new Tim();
    	string op = "Tim";
    	try {
	    	c = new Tim(recarga.Find(i=>i.Operadora.Equals(op)).Valor, Loja, recarga.Find(i=>i.Operadora.Equals(op)).Percentual);
    	} catch {
    		c = new Tim(0,Loja,0);
    	}
		return c;
    }


/** TOTALIZADORES  **/

	public decimal buscatotalCliente(string mes, string ano, string loja)
	{
		int mesInt = 0;
		switch(mes)
		{
			case "JANEIRO":
				mesInt=1;
				break;
			case "FEVEREIRO":
				mesInt=2;
				break;
			case "MARÇO":
				mesInt=3;
				break;
			case "ABRIL":
				mesInt=4;
				break;
			case "MAIO":
				mesInt=5;
				break;
			case "JUNHO":
				mesInt=6;
				break;
			case "JULHO":
				mesInt=7;
				break;
			case "AGOSTO":
				mesInt=8;
				break;
			case "SETEMBRO":
				mesInt=9;
				break;
			case "OUTUBRO":
				mesInt=10;
				break;
			case "NOVEMBRO":
				mesInt=11;
				break;
			case "DEZEMBRO":
				mesInt=12;
				break;
		}		
        String sqlStr="select SUM(quantidade) valor FROM CLIENTEDIARIO WHERE LOJA=@0 AND DATEPART(MONTH, DIADAVENDA)=@1 AND DATEPART(YEAR, DIADAVENDA)=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, loja, mesInt, ano);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;		
	}

public decimal buscatotalValorRecarga(string mes, string ano, string loja)
	{
		int mesInt = 0;
		switch(mes)
		{
			case "JANEIRO":
				mesInt=1;
				break;
			case "FEVEREIRO":
				mesInt=2;
				break;
			case "MARÇO":
				mesInt=3;
				break;
			case "ABRIL":
				mesInt=4;
				break;
			case "MAIO":
				mesInt=5;
				break;
			case "JUNHO":
				mesInt=6;
				break;
			case "JULHO":
				mesInt=7;
				break;
			case "AGOSTO":
				mesInt=8;
				break;
			case "SETEMBRO":
				mesInt=9;
				break;
			case "OUTUBRO":
				mesInt=10;
				break;
			case "NOVEMBRO":
				mesInt=11;
				break;
			case "DEZEMBRO":
				mesInt=12;
				break;
		}		
        String sqlStr="select SUM(VALOR) VALOR FROM VENDADIARIA WHERE LOJA=@0 AND DATEPART(MONTH, DIADAVENDA)=@1 AND DATEPART(YEAR, DIADAVENDA)=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, loja, mesInt, ano);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		
        sqlStr="select SUM(VALOR) VALOR FROM recargadiaria WHERE LOJA=@0 AND DATEPART(MONTH, DIADARECARGA)=@1 AND DATEPART(YEAR, DIADARECARGA)=@2";
		
		db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		sql = db.Query(sqlStr, loja, mesInt, ano);
		db.Close();
		decimal recarga = 0;
		foreach(var s in sql){
			try
			{
				recarga = s.valor;
			} catch{
				recarga=0;
			}
		}
		
		return valor+recarga;		
	}
		
	public decimal buscatotalValor(string mes, string ano, string loja)
	{
		int mesInt = 0;
		switch(mes)
		{
			case "JANEIRO":
				mesInt=1;
				break;
			case "FEVEREIRO":
				mesInt=2;
				break;
			case "MARÇO":
				mesInt=3;
				break;
			case "ABRIL":
				mesInt=4;
				break;
			case "MAIO":
				mesInt=5;
				break;
			case "JUNHO":
				mesInt=6;
				break;
			case "JULHO":
				mesInt=7;
				break;
			case "AGOSTO":
				mesInt=8;
				break;
			case "SETEMBRO":
				mesInt=9;
				break;
			case "OUTUBRO":
				mesInt=10;
				break;
			case "NOVEMBRO":
				mesInt=11;
				break;
			case "DEZEMBRO":
				mesInt=12;
				break;
		}		
        String sqlStr="select SUM(VALOR) VALOR FROM VENDADIARIA WHERE LOJA=@0 AND DATEPART(MONTH, DIADAVENDA)=@1 AND DATEPART(YEAR, DIADAVENDA)=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, loja, mesInt, ano);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;		
	}

    public decimal totalCancelamento(DateTime datainicial, DateTime datafinal, String loja)
    {
        double recarga=0.0;
        String sqlStr="select sum(valor) valor from cancelamentodiario where diadocancelamento between @0 AND @1 and loja=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, datainicial.ToString("yyyy-MM-dd 00:00:00"), datafinal.ToString("yyyy-MM-dd 23:59:59"), loja);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;        
    }
	
    public decimal totalRecarga(DateTime datainicial, DateTime datafinal, String loja)
    {
        double recarga=0.0;
        String sqlStr="select sum(valor) valor from recargadiaria where diadarecarga between @0 AND @1 and loja=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, datainicial.ToString("yyyy-MM-dd 00:00:00"), datafinal.ToString("yyyy-MM-dd 23:59:59"), loja);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;        
    }
	
    public decimal totalVenda(DateTime datainicial, DateTime datafinal, String loja)
    {
        double recarga=0.0;
        String sqlStr="select sum(valor) valor from vendadiaria where diadavenda between @0 AND @1 and loja=@2 and seccod<>'100'";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, datainicial.ToString("yyyy-MM-dd 00:00:00"), datafinal.ToString("yyyy-MM-dd 23:59:59"), loja);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;        
    }
    
    public int totalCliente(DateTime datainicial, DateTime datafinal, String loja)
    {
        int recarga=0;
        String sqlStr="select sum(quantidade) quantidade from ClienteDiario where diadavenda between @0 AND @1 and loja=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, datainicial.ToString("yyyy-MM-dd 00:00:00"), datafinal.ToString("yyyy-MM-dd 23:59:59"), loja);
		db.Close();
		int valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.quantidade;
			} catch{
				valor=0;
			}
		}
		return valor;        
    }

	public decimal totalTaxa(DateTime datainicial, DateTime datafinal, String loja)
    {
        double recarga=0.0;
        String sqlStr="select sum(valor) valor from entregadiaria where diadaentrega between @0 AND @1 and loja=@2";
		
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
		var sql = db.Query(sqlStr, datainicial.ToString("yyyy-MM-dd 00:00:00"), datafinal.ToString("yyyy-MM-dd 23:59:59"), loja);
		db.Close();
		decimal valor = 0;
		foreach(var s in sql){
			try
			{
				valor = s.valor;
			} catch{
				valor=0;
			}
		}
		return valor;        
    }
	
	public Claro totalRecargaClaro(DateTime datainicial, DateTime datafinal, string Loja)
    {
    	Claro claro = new Claro();
    	decimal valor = 0m;
    	decimal percentual = 0m;

        for(DateTime dt = datainicial; dt<=datafinal; dt=dt.AddDays(1))
        {
        	Recarga r = totalRecargaPorOperadora(dt, Loja, "Claro");
        	valor+=r.Valor;
        	percentual+=r.Percentual;
        }
        claro.Loja = Loja;
        claro.Valor = valor;
        claro.Percentual = percentual;
        return claro;
    }


	public Oi totalRecargaOi(DateTime datainicial, DateTime datafinal, string Loja)
    {
    	Oi oi = new Oi();
    	decimal valor = 0m;
    	decimal percentual = 0m;

        for(DateTime dt = datainicial; dt<=datafinal; dt=dt.AddDays(1))
        {
        	Recarga r = totalRecargaPorOperadora(dt, Loja, "Oi");
        	valor+=r.Valor;
        	percentual+=r.Percentual;
        }
        oi.Loja = Loja;
        oi.Valor = valor;
        oi.Percentual = percentual;
        return oi;
    }    

	public Tim totalRecargaTim(DateTime datainicial, DateTime datafinal, string Loja)
    {
    	Tim tim = new Tim();
    	decimal valor = 0m;
    	decimal percentual = 0m;

        for(DateTime dt = datainicial; dt<=datafinal; dt=dt.AddDays(1))
        {
        	Recarga r = totalRecargaPorOperadora(dt, Loja, "Tim");
        	valor+=r.Valor;
        	percentual+=r.Percentual;
        }
        tim.Loja = Loja;
        tim.Valor = valor;
        tim.Percentual = percentual;
        return tim;
    }  


	public Vivo totalRecargaVivo(DateTime datainicial, DateTime datafinal, string Loja)
    {
    	Vivo vivo = new Vivo();
    	decimal valor = 0m;
    	decimal percentual = 0m;

        for(DateTime dt = datainicial; dt<=datafinal; dt=dt.AddDays(1))
        {
        	Recarga r = totalRecargaPorOperadora(dt, Loja, "Vivo");
        	valor+=r.Valor;
        	percentual+=r.Percentual;
        }
        vivo.Loja = Loja;
        vivo.Valor = valor;
        vivo.Percentual = percentual;
        return vivo;
    }  	


      public void gerarDias(string loja, DateTime inicial, DateTime final)
      {
          for(DateTime d=inicial; d<final;d=d.AddDays(1)){
              gravarDiaria(loja, d);
          }
      }


      public List<RelatorioLoja> relatorioLoja(DateTime inicial, DateTime final)
      {
        List<RelatorioLoja> relatorio = new List<RelatorioLoja>();
		string sqlStr = string.Empty;

        List<Secao> resultado = new List<Secao>();
		Secao s = new Secao("01", "LIMPEZA", null);
		resultado.Add(s);
		s = new Secao("02", "PEIXARIA", null);
		resultado.Add(s);
		s = new Secao("03", "MERCEARIA", null);
		resultado.Add(s);
		s = new Secao("04", "ENLATADOS", null);
		resultado.Add(s);
		s = new Secao("05", "FRIOS", null);
		resultado.Add(s);
		s = new Secao("06", "BEBIDAS", null);
		resultado.Add(s);
		s = new Secao("07", "PERFUMARIA", null);
		resultado.Add(s);
		s = new Secao("08", "HORTIFRUTI", null);
		resultado.Add(s);
		s = new Secao("09", "FRIGORÍFICO", null);
		resultado.Add(s);
		s = new Secao("10", "BAZAR", null);
		resultado.Add(s);
		s = new Secao("11", "PAD. TRAD.", null);
		resultado.Add(s);
		s = new Secao("15", "PAD. DA CASA", null);
		resultado.Add(s);
		s = new Secao("16", "CEREAIS", null);
		resultado.Add(s);
		s = new Secao("18", "XEROX", null);
		resultado.Add(s);
		s = new Secao("20", "TAXA DE ENTREGA", null);
		resultado.Add(s);
		
		foreach(Secao x in resultado)
		{
			List<Loja> lojas = new List<Loja>();
			RelatorioLoja rl = new RelatorioLoja();
			rl.seccod = x.seccod;
			rl.secdes = x.secdes;
			for(int i=1; i<7; i++)
			{
				if(i!=5)
				{
					Loja l = new Loja(i.ToString(), retornaValorLoja(inicial, final, i.ToString("000000"), x.seccod));
					lojas.Add(l);
				}
			}
			rl.lojas=lojas;
			relatorio.Add(rl);
		}
        return relatorio;          
       }	  

      public List<RelatorioLoja> relatorioCompra(DateTime inicial, DateTime final)
      {
        List<RelatorioLoja> relatorio = new List<RelatorioLoja>();
        string sqlStr = string.Empty;

        List<Secao> resultado = new List<Secao>();
        Secao s = new Secao("01", "LIMPEZA", null);
        resultado.Add(s);
        s = new Secao("02", "PEIXARIA", null);
        resultado.Add(s);
        s = new Secao("03", "MERCEARIA", null);
        resultado.Add(s);
        s = new Secao("04", "ENLATADOS", null);
        resultado.Add(s);
        s = new Secao("05", "FRIOS", null);
        resultado.Add(s);
        s = new Secao("06", "BEBIDAS", null);
        resultado.Add(s);
        s = new Secao("07", "PERFUMARIA", null);
        resultado.Add(s);
        s = new Secao("08", "HORTIFRUTI", null);
        resultado.Add(s);
        s = new Secao("09", "FRIGORÍFICO", null);
        resultado.Add(s);
        s = new Secao("10", "BAZAR", null);
        resultado.Add(s);
        s = new Secao("11", "PAD. TRAD.", null);
        resultado.Add(s);
        s = new Secao("15", "PAD. DA CASA", null);
        resultado.Add(s);
        s = new Secao("16", "CEREAIS", null);
        resultado.Add(s);
        
        foreach(Secao x in resultado)
        {
            List<Loja> lojas = new List<Loja>();
            RelatorioLoja rl = new RelatorioLoja();
            rl.seccod = x.seccod;
            rl.secdes = x.secdes;
            for(int i=1; i<7; i++)
            {
                if(i!=5)
                {
                    decimal compra = retornaCompraLoja(inicial, final, i.ToString("000000"), x.seccod);
                    decimal parceiro = retornaVendaParceiroLoja(inicial, final, i.ToString("000000"), x.seccod);
                    decimal compraefetiva = compra  - parceiro;
                    Loja l = new Loja(i.ToString(), compraefetiva);
                    lojas.Add(l);
                }
            }
            rl.lojas=lojas;
            relatorio.Add(rl);
        }
        return relatorio;          
       }      

      public List<RelatorioLoja> relatorioCompraEfetiva(DateTime inicial, DateTime final)
      {
        List<RelatorioLoja> relatorio = new List<RelatorioLoja>();
        string sqlStr = string.Empty;

        List<Secao> resultado = new List<Secao>();
        Secao s = new Secao("01", "LIMPEZA", null);
        resultado.Add(s);
        s = new Secao("02", "PEIXARIA", null);
        resultado.Add(s);
        s = new Secao("03", "MERCEARIA", null);
        resultado.Add(s);
        s = new Secao("04", "ENLATADOS", null);
        resultado.Add(s);
        s = new Secao("05", "FRIOS", null);
        resultado.Add(s);
        s = new Secao("06", "BEBIDAS", null);
        resultado.Add(s);
        s = new Secao("07", "PERFUMARIA", null);
        resultado.Add(s);
        s = new Secao("08", "HORTIFRUTI", null);
        resultado.Add(s);
        s = new Secao("09", "FRIGORÍFICO", null);
        resultado.Add(s);
        s = new Secao("10", "BAZAR", null);
        resultado.Add(s);
        s = new Secao("11", "PAD. TRAD.", null);
        resultado.Add(s);
        s = new Secao("15", "PAD. DA CASA", null);
        resultado.Add(s);
        s = new Secao("16", "CEREAIS", null);
        resultado.Add(s);
        
        foreach(Secao x in resultado)
        {
            List<Loja> lojas = new List<Loja>();
            RelatorioLoja rl = new RelatorioLoja();
            rl.seccod = x.seccod;
            rl.secdes = x.secdes;
            for(int i=1; i<7; i++)
            {
                if(i!=5)
                {
                    decimal compra = retornaCompraLoja(inicial, final, i.ToString("000000"), x.seccod);
                    decimal entrada = retornaEntradaTransferenciaLoja(inicial, final, i.ToString("000000"), x.seccod);
                    decimal saida = retornaSaidaTransferenciaLoja(inicial, final, i.ToString("000000"), x.seccod);
                    decimal parceiro = retornaVendaParceiroLoja(inicial, final, i.ToString("000000"), x.seccod);
                    decimal compraefetiva = compra + entrada - saida - parceiro;
                    if(compraefetiva<0) compraefetiva=0;
                    Loja l = new Loja(i.ToString(), compraefetiva);
                    lojas.Add(l);
                }
            }
            rl.lojas=lojas;
            relatorio.Add(rl);
        }
        return relatorio;          
       }      
	  
      public void gravarVenda(DateTime dia){
          for(int i=1; i<7; i++){
              if(i!=5){
                gravarDiaria(i.ToString("000000"), dia);      
              }            
          }
      }

/** DELETE **/

      public void limparDBResumoVenda(){
          var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
          db.Execute("delete from VendaDiaria");
          db.Execute("delete from EntregaDiaria");
          db.Execute("delete from RecargaDiaria");
          db.Execute("delete from CancelamentoDiario");
		  db.Execute("delete from vendaparceiro");
          db.Execute("delete from clientediario");
          db.Execute("delete from compradiaria");
          db.Execute("delete from entradatransferenciadiaria");
          db.Execute("delete from saidatransferenciadiaria");  
          db.Close();
      }

	  public void apagarDiaria(DateTime ontem)
	  {
		  var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");		  
          db.Execute("delete from quebradiaria where diadaquebra>=@0", ontem);
		  db.Execute("delete from vendadiaria where diadavenda>=@0", ontem);
		  db.Execute("delete from vendaparceiro where diadavenda>=@0", ontem);
          db.Execute("delete from recargadiaria where diadarecarga>=@0", ontem);
          db.Execute("delete from entregadiaria where diadaentrega>=@0", ontem);
          db.Execute("delete from cancelamentodiario where diadocancelamento>=@0", ontem);
          db.Execute("delete from clientediario where diadavenda>=@0", ontem);
          db.Execute("delete from compradiaria where diadacompra>=@0", ontem);
          db.Execute("delete from entradatransferenciadiaria where diadaentrada>=@0", ontem);
          db.Execute("delete from saidatransferenciadiaria where diadasaida>=@0", ontem);                   
		  db.Close();		  
	  }
	  
	  	
	/** INSERT  **/

	  public void gravarClienteDiario(string loja, DateTime ontem)
	  {
		var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");

		int cliente = totalCliente(ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
		ClienteDiario cd = new ClienteDiario(loja, ontem, (int) cliente);
		try{
			db.Execute("insert into clientediario (loja, diadavenda, quantidade) values (@0, @1, @2)", cd.loja, cd.diadavenda, cd.quantidade);
		} catch (Exception ex){
			message = ex.Message;
		}		 
	  }

      public void gravarVendaDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
            List<PorSecao> lista = ResumoPorSecao(ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
            foreach(PorSecao s in lista){
                VendaDiaria v = new VendaDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
                try{
                    db.Execute("insert into vendadiaria (seccod, secdes, diadavenda, valor, loja) values (@0, @1, @2, @3, @4)", v.seccod, v.secdes, v.diadavenda, v.valor, v.loja);
                } catch (Exception ex){
                    message = ex.Message;
                }
            } 
      }
   
      public void gravarVendaDiariaFLV(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
            List<PorSecao> lista = ResumoPorSecaoFLV(ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
            foreach(PorSecao s in lista){
                VendaDiaria v = new VendaDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
                try{
                    db.Execute("insert into vendadiaria (seccod, secdes, diadavenda, valor, loja) values (@0, @1, @2, @3, @4)", v.seccod, v.secdes, v.diadavenda, v.valor, v.loja);
                } catch (Exception ex){
                    message = ex.Message;
                }
            } 
      }

      public void gravarRecargaDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
            double recarga = totalRecarga(ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
            RecargaDiaria r = new RecargaDiaria(loja, ontem, (decimal) recarga);
            try{
                db.Execute("insert into recargadiaria (loja, diadarecarga, valor) values (@0, @1, @2)", r.loja, r.diadarecarga, r.valor);
            } catch (Exception ex){
                message = ex.Message;
            }
      }

      public void gravarTaxaDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");

            double entrega = totalTaxa(ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
            EntregaDiaria e = new EntregaDiaria(loja, ontem, (decimal) entrega);
            try{
                db.Execute("insert into entregadiaria (loja, diadaentrega, valor) values (@0, @1, @2)", e.loja, e.diadaentrega, e.valor);
            } catch (Exception ex){
                message = ex.Message;
            }
        
      }

      public void gravarCancelamentoDiario(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
            double cancelamento = totalCancelamento(ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
            CancelamentoDiario c = new CancelamentoDiario(loja, ontem, (decimal) cancelamento);
            try{
                db.Execute("insert into cancelamentodiario (loja, diadocancelamento, valor) values (@0, @1, @2)", c.loja, c.diadocancelamento, c.valor);
            } catch (Exception ex){
                message = ex.Message;
            }        
      }

      public void gravarDiaria(string loja, DateTime ontem)
      {
       
        if(!vendaGravada(loja, ontem))
        {
            gravarVendaDiaria(loja, ontem);
            gravarRecargaDiaria(loja, ontem);
            gravarTaxaDiaria(loja, ontem);
            gravarCancelamentoDiario(loja, ontem);
            gravarClienteDiario(loja, ontem);
            gravarCompraVenda(loja, ontem);
        }
        else {
            message = "Venda Já Foi Gerada!";
            }
       }

      public void gravarVendaParceiro(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = VendaParceiroPorSecao(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){
            VendaParceiroDiaria v1 = new VendaParceiroDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into vendaparceiro (seccod, secdes, diadavenda, valor, loja) values (@0, @1, @2, @3, @4)", v1.seccod, v1.secdes, v1.diadavenda, v1.valor, v1.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }

      public void gravarCompraDiariaFLV(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = CompraPorSecaoFLV(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){
            CompraDiaria v2 = new CompraDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into compradiaria (seccod, secdes, diadacompra, valor, loja) values (@0, @1, @2, @3, @4)", v2.seccod, v2.secdes, v2.diadacompra, v2.valor, v2.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }
      
      public void gravarCompraDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = CompraPorSecao(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){
            CompraDiaria v2 = new CompraDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into compradiaria (seccod, secdes, diadacompra, valor, loja) values (@0, @1, @2, @3, @4)", v2.seccod, v2.secdes, v2.diadacompra, v2.valor, v2.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }

      public void gravarQuebraDiariaFLV(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = QuebraDiariaPorSecaoFLV(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){
            QuebraDiaria v2 = new QuebraDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into quebradiaria (seccod, secdes, diadaquebra, valor, loja) values (@0, @1, @2, @3, @4)", v2.seccod, v2.secdes, v2.diadaquebra, v2.valor, v2.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }
      
      public void gravarQuebraDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = QuebraDiariaPorSecao(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){
            QuebraDiaria v2 = new QuebraDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into quebradiaria (seccod, secdes, diadaquebra, valor, loja) values (@0, @1, @2, @3, @4)", v2.seccod, v2.secdes, v2.diadaquebra, v2.valor, v2.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }

      public void gravarEntradaTransferenciaDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = EntradaTransferenciaDiariaPorSecao(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){ 
            EntradaTransferenciaDiaria v3 = new EntradaTransferenciaDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into entradatransferenciadiaria (seccod, secdes, diadaentrada, valor, loja) values (@0, @1, @2, @3, @4)", v3.seccod, v3.secdes, v3.diadaentrada, v3.valor, v3.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }

      public void gravarEntradaTransferenciaDiariaFLV(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = EntradaTransferenciaDiariaPorSecaoFLV(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){ 
            EntradaTransferenciaDiaria v3 = new EntradaTransferenciaDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into entradatransferenciadiaria (seccod, secdes, diadaentrada, valor, loja) values (@0, @1, @2, @3, @4)", v3.seccod, v3.secdes, v3.diadaentrada, v3.valor, v3.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        }
        db.Close();          
      }

      public void gravarSaidaTransferenciaDiaria(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = SaidaTransferenciaDiariaPorSecao(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){ 
            SaidaTransferenciaDiaria v4 = new SaidaTransferenciaDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into saidatransferenciadiaria (seccod, secdes, diadasaida, valor, loja) values (@0, @1, @2, @3, @4)", v4.seccod, v4.secdes, v4.diadasaida, v4.valor, v4.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        } 
        db.Close();          
      }

      public void gravarSaidaTransferenciaDiariaFLV(string loja, DateTime ontem)
      {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");           
        List<PorSecao> lista = SaidaTransferenciaDiariaPorSecaoFLV(loja, ontem.ToString("yyyy-MM-dd"), ontem.ToString("yyyy-MM-dd"));
        foreach(PorSecao s in lista){ 
            SaidaTransferenciaDiaria v4 = new SaidaTransferenciaDiaria(loja, s.seccod, s.secdes, ontem, (decimal) s.total);
            try{
                db.Execute("insert into saidatransferenciadiaria (seccod, secdes, diadasaida, valor, loja) values (@0, @1, @2, @3, @4)", v4.seccod, v4.secdes, v4.diadasaida, v4.valor, v4.loja);
            } catch (Exception ex){
                message = ex.Message;
            }
        } 
        db.Close();          
      }

      public void gravarCompraVenda(string loja, DateTime ontem)
	  {
        if(!compraGravada(loja, ontem))
        {
        	gravarVendaParceiro(loja, ontem);			
			gravarCompraDiaria(loja, ontem);
			gravarEntradaTransferenciaDiaria(loja, ontem);
			gravarSaidaTransferenciaDiaria(loja, ontem);					  
            gravarQuebraDiaria(loja, ontem);
            gravarCompraVendaFLV(loja, ontem);    
        }
        else {
            message = "Compra Já Foi Gerada!";
            }
	  }
 
      public void gravarCompraVendaFLV(string loja, DateTime ontem)
      {
        if(!compraGravadaFLV(loja, ontem))
        {
            gravarCompraDiariaFLV(loja, ontem);
            gravarEntradaTransferenciaDiariaFLV(loja, ontem);
            gravarSaidaTransferenciaDiariaFLV(loja, ontem); 
            gravarVendaDiariaFLV(loja, ontem);                     
            gravarQuebraDiariaFLV(loja, ontem);
        }
        else 
        {
            message = "Compra Já Foi Gerada!";
        }
      }  
/** ACESSO AO BANCO FIREBIRD **/


    public List<Secao> sqlSecao(String filtro){
        String sql="Select seccod, secdes from SECAO where seccod in " + filtro + " order by seccod";
        List<Secao> resultado = new List<Secao>();
        try
        {
            FbCommand fbc = new FbCommand(sql, con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];
            foreach(DataRow r in dt.Rows)
            {
                Secao rs = new Secao(r["seccod"].ToString(), r["secdes"].ToString(), null);
                resultado.Add(rs);
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return resultado;
    }  

    public List<PorSecao> ResumoPorSecaoFLV(String datainicial, String datafinal) 
    {
        String sql="SELECT Sum(itevda.ITVVLRTOT) AS TOTAL ";
        sql=sql+"FROM itevda itevda, produto produto, transacao, secao, grupo WHERE (itevda.TRNDAT between '" + datainicial +"' AND '" + datafinal + "') ";
        sql=sql+"AND (transacao.CXANUM=itevda.cxanum) AND (transacao.TRNDAT=itevda.trndat) AND (transacao.TRNSEQ=itevda.trnseq) AND (secao.seccod='08') AND (grupo.grpcod='001') ";
        sql=sql+"AND (transacao.TRNTIP='1') AND (produto.PROCOD=itevda.procod) AND (itevda.ITVTIP=1) AND (produto.seccod=secao.seccod) ";
        sql=sql+"AND (produto.grpcod=grupo.grpcod) AND (grupo.seccod=secao.seccod) ";
        //sql=sql+"group by secao.seccod, secao.secdes";
        List<PorSecao> resultado = new List<PorSecao>();
        try{
            FbCommand fbc = new FbCommand(sql,con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();                        
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];            
            foreach(DataRow dr in dt.Rows)
            {
                try{
                    PorSecao rs = new PorSecao("100", "FLV", double.Parse(dr["total"].ToString()));
                    resultado.Add(rs);
                } catch (Exception ex){
                    message=ex.ToString();
                }
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return resultado;
    }

    public List<PorSecao> ResumoPorSecao(String datainicial, String datafinal) 
    {
        String sql="SELECT secao.seccod, secao.secdes AS SECAO, Sum(itevda.ITVVLRTOT) AS TOTAL ";
        sql=sql+"FROM itevda itevda, produto produto, transacao, secao WHERE (itevda.TRNDAT between '" + datainicial +"' AND '" + datafinal + "') ";
        sql=sql+"AND (transacao.CXANUM=itevda.cxanum) AND (transacao.TRNDAT=itevda.trndat) AND (transacao.TRNSEQ=itevda.trnseq) ";
        sql=sql+"AND (transacao.TRNTIP='1') AND (produto.PROCOD=itevda.procod) AND (itevda.ITVTIP=1) AND (produto.seccod=secao.seccod) AND (produto.seccod<21) ";
        sql=sql+"group by secao.seccod, secao.secdes";
        List<PorSecao> resultado = new List<PorSecao>();
        try{
            FbCommand fbc = new FbCommand(sql,con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();                        
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];            
            foreach(DataRow dr in dt.Rows)
            {
                PorSecao rs = new PorSecao(dr["seccod"].ToString(),dr["secao"].ToString(), double.Parse(dr["total"].ToString()));
                resultado.Add(rs);
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return resultado;
    }
	
    public List<Secao> sqlSecao(){
        String sql="Select seccod, secdes from SECAO where seccod<21 order by seccod";
        List<Secao> resultado = new List<Secao>();
        try
        {
            FbCommand fbc = new FbCommand(sql, con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];
            foreach(DataRow r in dt.Rows)
            {
                Secao rs = new Secao(r["seccod"].ToString(), r["secdes"].ToString(), null);
                resultado.Add(rs);
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return resultado;
    }

    /** TOTALIZADORES  **/


    public double totalTaxa(String datainicial, String datafinal)
    {
        double recarga=0.0;
        String sql="select sum(trnvlr) soma from transacao where trndat between '" + datainicial +"' AND '" + datafinal + "' and trntip='5' and trnvlr<5 ";
        try{
            FbCommand fbc = new FbCommand(sql,con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();                        
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];            
            foreach(DataRow dr in dt.Rows)
            {
                try
                {

                    recarga = double.Parse(dr["soma"].ToString());
                }
                catch
                {
	                recarga=0;
                }
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return recarga;
      }
    
		public double totalCancelamento(String datainicial, String datafinal)
    	{
	        double recarga=0.0;
	        String sql="select sum(itvvlrtot) soma from transacao t inner join itevda i on i.trndat=t.trndat and i.cxanum=t.cxanum and i.trnseq=t.trnseq where t.trndat between '" + datainicial +"' AND '" + datafinal + "' and (t.trntip='7' or i.itvtip='2') ";
	        try{
	            FbCommand fbc = new FbCommand(sql,con);
	            FbDataAdapter fbDA = new FbDataAdapter(fbc);
	            DataSet secao = new DataSet();                        
	            fbDA.Fill(secao);
	            DataTable dt = secao.Tables[0];            
	            foreach(DataRow dr in dt.Rows)
	            {
	                try
	                {

	                    recarga = double.Parse(dr["soma"].ToString());
	                }
	                catch
	                {
		                recarga=0;
	                }
	            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return recarga;
    }

	public int totalCliente(String datainicial, String datafinal)
    {
        int recarga=0;
		String sql="select sum(QTD_CLIENTE) soma from VENDA_POSICAO_LOJA_DIA where trndat between '" + datainicial +"' AND '" + datafinal + "'";
        try{
            FbCommand fbc = new FbCommand(sql,con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();                        
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];            
            foreach(DataRow dr in dt.Rows)
            {
                try
                {

                    recarga = int.Parse(dr["soma"].ToString());
                }
                catch
                {
	                recarga=0;
                }
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return recarga;
    }
	
    public double totalRecarga(String datainicial, String datafinal)
    {
        double recarga=0.0;
        String sql="select sum(trnvlr) soma from transacao where trndat between '" + datainicial +"' AND '" + datafinal + "' and trntip='5' and trnvlr>5 ";
        try{
            FbCommand fbc = new FbCommand(sql,con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();                        
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];            
            foreach(DataRow dr in dt.Rows)
            {
                try
                {

                    recarga = double.Parse(dr["soma"].ToString());
                }
                catch
                {
	                recarga=0;
                }
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return recarga;
    }

    public Recarga totalRecargaPorOperadora(DateTime datainicial, string Loja, string Operadora)
    {
    	Recarga r = new Recarga();
    	DateTime referencia = new DateTime(2018,7,11);
    	double recarga=0.0;
        String sql=String.Format("select teftc_590 Operadora, Sum(teffzdvlr) Valor, trndat from transacaotefdll where trndat between '{0}' and '{1}' and teftip='R' and teftc_590='{2}' group by 1, 3", datainicial.ToString("yyyy-MM-dd"), datainicial.ToString("yyyy-MM-dd"), Operadora);
        try{
            FbCommand fbc = new FbCommand(sql,con);
            FbDataAdapter fbDA = new FbDataAdapter(fbc);
            DataSet secao = new DataSet();                        
            fbDA.Fill(secao);
            DataTable dt = secao.Tables[0];            
            foreach(DataRow dr in dt.Rows)
            {
                try
                {              
                	r.Operadora = dr["Operadora"].ToString();
                	r.Valor = decimal.Parse(dr["Valor"].ToString());
                	if(datainicial < referencia)
                	{
                		r.Percentual = r.Valor * 3.5m/100m;
                	}
                	else
                	{
                		r.Percentual = r.Valor * retornaPercentual(r.Operadora)/100m;
                	}
                	r.Loja=Loja;
                	r.Venda=DateTime.Parse(dr["trndat"].ToString());
                }
                catch
                {
                	r.Operadora = dr["Operadora"].ToString();
                	r.Valor = 0;                	
            		r.Percentual = 0;                
                	r.Loja=Loja;
                	r.Venda=DateTime.Parse(dr["trndat"].ToString());
                }
            }
        }
        catch (FbException ex)
        {
            throw ex;
            message=ex.ToString();
        }
        finally
        {
            Fecha();    
        }
        return r;
    }
}

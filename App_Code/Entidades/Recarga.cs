using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Recarga
{
    public DateTime Venda{get;set;}
    public string Operadora{get;set;}
	public decimal Percentual{get;set;}
	public decimal Valor{get;set;}
	public string Loja{get;set;}

	public Recarga(){}

    public Recarga(String Operadora, decimal Percentual, decimal Valor, String Loja, DateTime Venda)
    {
        this.Operadora=Operadora;
        this.Valor=Valor;
        this.Percentual=Percentual;
        this.Loja=Loja;
        this.Venda=Venda;
    }    
}

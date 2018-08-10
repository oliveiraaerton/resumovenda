using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Oi
{
    public decimal Valor{get;set;}
	public string Loja{get;set;}
	public decimal Percentual{get;set;}

	public Oi(){}

    public Oi(decimal Valor, String Loja, decimal Percentual)
    {
        this.Valor=Valor;
        this.Loja=Loja;
        this.Percentual=Percentual;
    }    
}

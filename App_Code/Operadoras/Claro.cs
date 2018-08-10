using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Claro
{
    public decimal Valor{get;set;}
	public string Loja{get;set;}
    public decimal Percentual{get;set;}

	public Claro(){}

    public Claro(decimal Valor, String Loja, decimal Percentual)
    {
        this.Loja=Loja;
        this.Valor=Valor;
        this.Percentual=Percentual;
    }    
}

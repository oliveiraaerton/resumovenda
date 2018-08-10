using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Vivo
{
    public decimal Valor{get;set;}
	public string Loja{get;set;}
	public decimal Percentual{get;set;}

	public Vivo(){}

    public Vivo(decimal Valor, String Loja, decimal Percentual)
    {
        this.Valor=Valor;
        this.Loja=Loja;
        this.Percentual=Percentual;
    }    
}

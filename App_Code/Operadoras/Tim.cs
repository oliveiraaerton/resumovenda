using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Tim
{
    public decimal Valor{get;set;}
	public string Loja{get;set;}
	public decimal Percentual{get;set;}

	public Tim(){}

    public Tim(decimal Valor, String Loja, decimal Percentual)
    {
        this.Valor=Valor;
        this.Loja=Loja;
        this.Percentual=Percentual;
    }    
}

using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Loja
{
    public string loja{get;set;}
	public decimal valor{get;set;}


    public Loja(String loja, decimal valor)
    {
        this.loja=loja;
        this.valor=valor;
    }    
}

using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class Semana
{
    public string diadasemana{get;set;}
	public decimal valor{get;set;}

    public Semana(String diadasemana, decimal valor)
    {
        this.diadasemana=diadasemana;
        this.valor=valor;
    }    
}

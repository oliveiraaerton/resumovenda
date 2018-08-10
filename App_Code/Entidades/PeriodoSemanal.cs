using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class PeriodoSemanal
{
    public DateTime inicial{get;set;}
	public DateTime final{get;set;}

    public PeriodoSemanal(DateTime inicial, DateTime final)
    {
        this.inicial = inicial;
        this.final = final;
    }    
}

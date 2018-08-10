using System;
using System.Collections.Generic;

public class RelatorioLoja
{
    public string seccod{get;set;}
    public string secdes{get;set;}
	public List<Loja> lojas {get;set;}

	public RelatorioLoja(){}
    public RelatorioLoja(String seccod, String secdes, List<Loja> lojas)
    {
        this.seccod=seccod;
        this.secdes=secdes;
		this.lojas = lojas;
    }    
}

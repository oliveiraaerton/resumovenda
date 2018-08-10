using System;

public class CompraEfetivaDiaria
{
    public string loja{get;set;}
    public string seccod{get;set;}
    public string secdes{get;set;}
    public DateTime diadacompra{get;set;}
    public decimal valor{get;set;}
	public string cor{get;set;}

    public CompraEfetivaDiaria(String loja, String seccod, String secdes, DateTime diadacompra, Decimal valor)
    {

        this.loja=loja;
        this.seccod=seccod;
        this.secdes=secdes;
        this.diadacompra=diadacompra;
        this.valor=valor;
    }
}

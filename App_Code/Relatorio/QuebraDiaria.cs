using System;

public class QuebraDiaria
{
    public string loja{get;set;}
    public string seccod{get;set;}
    public string secdes{get;set;}
    public DateTime diadaquebra{get;set;}
    public decimal valor{get;set;}
	public string cor{get;set;}

    public QuebraDiaria(String loja, String seccod, String secdes, DateTime diadaquebra, Decimal valor)
    {

        this.loja=loja;
        this.seccod=seccod;
        this.secdes=secdes;
        this.diadaquebra=diadaquebra;
        this.valor=valor;
    }
}

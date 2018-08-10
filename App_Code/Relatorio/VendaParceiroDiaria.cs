using System;

public class VendaParceiroDiaria
{
    public string loja{get;set;}
    public string seccod{get;set;}
    public string secdes{get;set;}
    public DateTime diadavenda{get;set;}
    public decimal valor{get;set;}
	public string cor{get;set;}

    public VendaParceiroDiaria(String loja, String seccod, String secdes, DateTime diadavenda, Decimal valor)
    {

        this.loja=loja;
        this.seccod=seccod;
        this.secdes=secdes;
        this.diadavenda=diadavenda;
        this.valor=valor;
    }
}

using System;

public class EntradaTransferenciaDiaria
{
    public string loja{get;set;}
    public string seccod{get;set;}
    public string secdes{get;set;}
    public DateTime diadaentrada{get;set;}
    public decimal valor{get;set;}
	public string cor{get;set;}

    public EntradaTransferenciaDiaria(String loja, String seccod, String secdes, DateTime diadaentrada, Decimal valor)
    {

        this.loja=loja;
        this.seccod=seccod;
        this.secdes=secdes;
        this.diadaentrada=diadaentrada;
        this.valor=valor;
    }
}

using System;

public class SaidaTransferenciaDiaria
{
    public string loja{get;set;}
    public string seccod{get;set;}
    public string secdes{get;set;}
    public DateTime diadasaida{get;set;}
    public decimal valor{get;set;}
	public string cor{get;set;}

    public SaidaTransferenciaDiaria(String loja, String seccod, String secdes, DateTime diadasaida, Decimal valor)
    {
        //
        // TODO: Add constructor logic here
        //
        this.loja=loja;
        this.seccod=seccod;
        this.secdes=secdes;
        this.diadasaida=diadasaida;
        this.valor=valor;
    }
}

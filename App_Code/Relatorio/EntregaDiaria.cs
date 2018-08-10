using System;

public class EntregaDiaria
{
    public string loja{get;set;}
    public DateTime diadaentrega{get;set;}
    public decimal valor{get;set;}

    public EntregaDiaria(String loja, DateTime diadaentrega, Decimal valor)
    {
        this.loja=loja;
        this.diadaentrega=diadaentrega;
        this.valor=valor;
    }
}

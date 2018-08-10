using System;

public class RecargaDiaria
{
    public string loja{get;set;}
    public DateTime diadarecarga{get;set;}
    public decimal valor{get;set;}

    public RecargaDiaria(String loja, DateTime diadarecarga, Decimal valor)
    {
        this.loja=loja;
        this.diadarecarga=diadarecarga;
        this.valor=valor;
    }
}

using System;

public class CancelamentoDiario
{
    public string loja{get;set;}
    public DateTime diadocancelamento{get;set;}
    public decimal valor{get;set;}

    public CancelamentoDiario(String loja, DateTime diadocancelamento, Decimal valor)
    {
        this.loja=loja;
        this.diadocancelamento=diadocancelamento;
        this.valor=valor;
    }
}

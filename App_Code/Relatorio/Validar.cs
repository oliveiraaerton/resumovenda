using System;

public class Validar
{
    public DateTime diainicial{get;set;}
    public decimal valor{get;set;}


    public Validar(DateTime diainicial, Decimal valor)
    {
        this.diainicial=diainicial;
        this.valor=valor;

    }
}
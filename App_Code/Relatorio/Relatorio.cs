using System;

public class Relatorio
{
    public string seccod{get;set;}
    public string secdes{get;set;}
    public string referencia{get;set;}
    public string comparacao{get;set;}
    public string diferencaValor{get;set;}
    public string diferencaPerc{get;set;}

    public Relatorio(String seccod, String secdes, string referencia, string comparacao, string diferencaValor, string diferencaPerc)
    {
        this.seccod=seccod;
        this.secdes=secdes;
        this.referencia=referencia;
        this.comparacao=comparacao;
        this.diferencaValor=diferencaValor;
        this.diferencaPerc=diferencaPerc;
    }    
}

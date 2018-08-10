using System;

public class ClienteDiario
{
    public string loja{get;set;}
    public DateTime diadavenda{get;set;}
    public int quantidade{get;set;}

    public ClienteDiario(String loja, DateTime diadavenda, int quantidade)
    {
        this.loja=loja;
        this.diadavenda=diadavenda;
        this.quantidade=quantidade;
    }
}

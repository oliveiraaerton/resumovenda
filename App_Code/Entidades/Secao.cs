using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Secao
/// </summary>
public class Secao
{
    public String seccod;
    public String secdes;
	public String cor;
    public Secao(){}
    public Secao(String seccod, String secdes, String cor)
    {
        //
        // TODO: Add constructor logic here
        //
        this.seccod=seccod;
        this.secdes=secdes;
		this.cor=cor;
    }
}

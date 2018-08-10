using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public class RelatorioCompra
{
    public string DataRelatorio{get;set;}
    public string Codigo{get;set;}
    public string Descricao{get;set;}
    public string CompraGeral{get;set;}
    public string VendaParceiro{get;set;}
    public string EntradaTransferencia{get;set;}
    public string SaidaTransferencia{get;set;}
    public string CompraEfetiva{get;set;}// CE = CG - VP + ET - ST
    public string VendaCliente{get;set;}// VC somente venda PDV e CFE
    public string MetaCompra{get;set;}// MC = VC - 75%
    public string Desvio{get;set;}// DV = MC - CE
    public string CompraSobreVenda{get;set;}// CSV = CE / VC * 100
}

using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;
/// <summary>
/// Configuracao
/// </summary>
public class Configuracao
{
    public string arquivoPDF;
    public string userSyspdv;
    public string passwordSyspdv;
    public string databaseSyspdv;
    public string datasourceSyspdv;
    public bool usaDezembro;
    public string smtpServer;
    public int smtpPort;
    public bool enableSsl;
    public bool smtpCredentials; 
    public string usernameEmail;
    public string passwordEmail;
    public string from;
    public string sendto;
    public string cc;
    public string cco;
    public string nomeEmpresa;

    public Configuracao()
    {
        //Database db=Database.Open("ResumoVenda");
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
        var sql=db.QuerySingle("select top 1 * from config");
        arquivoPDF=sql.arquivoPDF;
        userSyspdv=sql.userSyspdv;
        passwordSyspdv=sql.passwordSyspdv;
        databaseSyspdv=sql.databaseSyspdv;
        datasourceSyspdv=sql.datasourceSyspdv;
        usaDezembro=sql.usaDezembro;
        smtpServer=sql.smtpServer;
        smtpPort=sql.smtpPort;
        enableSsl=sql.enableSsl;
        smtpCredentials=sql.smtpCredentials;
        usernameEmail=sql.usernameEmail;
        passwordEmail=sql.passwordEmail;
        from=sql.from;
        sendto=sql.sendto;
        cc=sql.cc;
        cco=sql.cco;
        nomeEmpresa=sql.nomeEmpresa;
		db.Close();
    }

    public void SaveConfiguracao(string userSyspdv, string passwordSyspdv, string databaseSyspdv, string datasourceSyspdv, bool usaDezembro, string smtpServer, int smtpPort, bool enableSsl,bool smtpCredentials,string usernameEmail, string passwordEmail,string from, string sendto, string cc, string cco, string nomeEmpresa)
    {
        var db = Database.OpenConnectionString("Data Source=|DataDirectory|\\ResumoVenda.sdf", "System.Data.SqlServerCe.4.0");
            db.Execute("insert into ");
        db.Close();
    }
}

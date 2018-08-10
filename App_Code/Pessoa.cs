
using System;
using System.Data;
using System.Collections.Generic;

public class Pessoa
{
    public Pessoa(string cpf, string nome)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new Exception("Cpf cannot be null");
        


        if (string.IsNullOrWhiteSpace(nome))
          throw new Exception("Nome cannot be null");

        this.Cpf = (string)cpf;    
        this.Nome = nome;    
              
    }
 
    public virtual string Cpf { get; protected set; }
 
    public virtual string Nome { get; set; }
       
}
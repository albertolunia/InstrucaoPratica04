﻿namespace pogDev;

public class Medico : Pessoa{
    private string crm;
    public string Crm{
        get{
            return crm;
        }
        set{
            crm = value;
        }
    }
        public Medico(string nome,string cpf,string dataDeNascimento,string crm) : base(nome,cpf,dataDeNascimento){
        this.crm = crm;
        
    }
}
using System.Runtime;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Data;


namespace Namespace;
public class Pessoa
{
    public string Nome{get; set;}
    private DateTime _dataNascimento;
    public DateTime dataNascimento{
        get{
            return _dataNascimento;
        }
        set{
            if(value.Year > DateTime.Now.Year){
                throw new Exception("Ano inválido");
            }
            else{
                this._dataNascimento = value;
            }
        }
    }
    private string _cpf;
    public string CPF{
        get{
            return this._cpf;
        } 
        set{
            if(value.Length != 11){
                throw new Exception("CPF possui apenas com 11 dígitos");
            }
            else{
                this._cpf = value;
            }
        }
    }
    public int getIdade(){
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
        int idade =  DateTime.Now.Year - dataNascimento.Year;
        if(dataNascimento.Month < DateTime.Now.Month){
            idade--;
        }
        else if( dataNascimento.Month == DateTime.Now.Month){
                if(dataNascimento.Day < DateTime.Now.Day)
                    idade--;
            }
        
        return idade;
    }
    
}

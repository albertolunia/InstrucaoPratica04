using System.Net.WebSockets;

namespace ConsultorioMedico{
    class Paciente: Pessoa{
        private string _sexo;
        private string _sintomas;

        public string Sexo{
            get{
                return _sexo;
            }
            set{
                if(value == "M" || value == "m" || value == "F" || value == "f")
                    _sexo = value;
            }
        }

        public string Sintomas{
            get{
                return _sintomas;
            }
            set{
                _sintomas = value;
            }
        }

        public Paciente(string nome, string dataNascimento, string cpf, string sexo, string sintomas){
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Sexo = sexo;
            Sintomas = sintomas;
        }

        public Paciente(){
            
        }
    }
}
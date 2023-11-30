namespace ConsultorioMedico{
    class Medico: Pessoa{
        private string _crm;
        public string Crm{
            get{
                return _crm;
            }
            set{
                _crm = value;
            }
        }

        public Medico(string nome, string dataNascimento, string cpf, string crm){
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Crm = crm;
        }

        public Medico(){
            
        }
    }
}
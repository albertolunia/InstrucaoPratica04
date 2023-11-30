namespace ConsultorioMedico{
    class Pessoa{
        private string _nome;
        private string _dataNascimento;
        private string _cpf;

        public string Nome{
            get{
                return _nome;
            }
            set{
                _nome = value;
            }
        }

        public string DataNascimento{
            get{
                return _dataNascimento;
            }
            set{
                _dataNascimento = value;
            }
        }

        public string Cpf{
            get{
                return _cpf;
            }
            set{
                _cpf = value;
            }
        }

        public int CalcularIdade(){
            int anoNascimento = int.Parse(DataNascimento.Substring(4, 4));
            int anoAtual = int.Parse(DateTime.Now.ToString("yyyy"));
            return anoAtual - anoNascimento;
        }
    }
}
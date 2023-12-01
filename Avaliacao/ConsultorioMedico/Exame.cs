namespace ConsultorioMedico{
    class Exame{
        private string _titulo;
        private double _valor;
        private string _descricao;
        private string _local;

        public string Titulo{
            get{
                return _titulo;
            }
            set{
                _titulo = value;
            }
        }

        public double Valor{
            get{
                return _valor;
            }
            set{
                _valor = value;
            }
        }

        public string Descricao{
            get{
                return _descricao;
            }
            set{
                _descricao = value;
            }
        }

        public string Local{
            get{
                return _local;
            }
            set{
                _local = value;
            }
        }
    }
}
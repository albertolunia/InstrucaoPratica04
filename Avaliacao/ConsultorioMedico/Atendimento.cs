namespace ConsultorioMedico{
    class Atendimento{
        private DateTime _dataHora;
        private string _suspeitaInicial;
        private List<(Exame, string)> _examesResultado;
        private double _valor;

        private DateTime _fimAtendimento;
        private Medico _medicoResponsavel;
        private Paciente _pacienteAtendido;
        private string _diagnosticoFinal;

        public DateTime DataHora{
            get{
                return _dataHora;
            }
            set{
                _dataHora = value;
            }
        }

        public string SuspeitaInicial{
            get{
                return _suspeitaInicial;
            }
            set{
                _suspeitaInicial = value;
            }
        }

        public List<(Exame, string)> ExamesResultado{
            get{
                return _examesResultado;
            }
            set{
                _examesResultado = value;
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

        public DateTime FimAtendimento{
            get{
                return _fimAtendimento;
            }
            set{
                _fimAtendimento = value;
            }
        }

        public Medico MedicoResponsavel{
            get{
                return _medicoResponsavel;
            }
            set{
                _medicoResponsavel = value;
            }
        }

        public Paciente PacienteAtendido{
            get{
                return _pacienteAtendido;
            }
            set{
                _pacienteAtendido = value;
            }
        }

        public string DiagnosticoFinal{
            get{
                return _diagnosticoFinal;
            }
            set{
                _diagnosticoFinal = value;
            }
        }

    }
}
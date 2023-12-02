namespace ConsultorioMedico{
    class Atendimento{
        private DateTime _inicioAtendimento;
        private string _suspeitaInicial;
        private List<(Exame, string)> _examesResultado;
        private double _valor;

        private DateTime _fimAtendimento;
        private Medico _medicoResponsavel;
        private Paciente _pacienteAtendido;
        private string _diagnosticoFinal;

        public Atendimento(){
            _inicioAtendimento = DateTime.Now;
            _suspeitaInicial = "";
            _examesResultado = new();
            _valor = 0;

            _fimAtendimento = DateTime.Now;
            _medicoResponsavel = new();
            _pacienteAtendido = new();
            _diagnosticoFinal = "";
        }

        public Atendimento(Paciente paciente, Medico medico, string suspeitaInicial){
            _inicioAtendimento = DateTime.Now;
            _suspeitaInicial = suspeitaInicial;
            _medicoResponsavel = medico;
            _pacienteAtendido = paciente;
            _examesResultado = new();
        }

        public DateTime InicioAtendimento{
            get{
                return _inicioAtendimento;
            }
            set{
                _inicioAtendimento = value;
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
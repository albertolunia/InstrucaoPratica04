﻿using pogDev;

Consultorio pogdev = new Consultorio();

List<Paciente> pacientes = new List<Paciente>();
List<Medico> medicos = new List<Medico>();
List<Exame> exames = new List<Exame>();
List<Atendimento> atendimentos = new List<Atendimento>();





Relatorios.PacientesOrdemAlfabetica(pacientes);
Relatorios.PacienteIdade(pacientes,24,30);
Relatorios.PacientesComSintomas(pacientes,"dor");


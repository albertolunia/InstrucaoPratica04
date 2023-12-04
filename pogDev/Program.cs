﻿using pogDev;

List<Paciente> pacientes = new List<Paciente>();
List<Medico> medicos = new List<Medico>();
List<Exame> exames = new List<Exame>();
List<Atendimento> atendimentos = new List<Atendimento>();

Consultorio.menu(pacientes,medicos,exames,atendimentos);

Relatorios.PacientesOrdemAlfabetica(pacientes);
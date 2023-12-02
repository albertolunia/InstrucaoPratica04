﻿using pogDev;

Consultorio pogdev = new Consultorio();

pogdev.adicionaPaciente(new Paciente("Zoka","00000000000","2000/03/14", "masculino",new List<string>{"dor", "tosse"}));
pogdev.adicionaPaciente(new Paciente("Maria","00000000001","1997/2/3","feminino",new List<string>()));

Relatorios.PacientesOrdemAlfabetica(pogdev.Pacientes);
Relatorios.PacienteIdade(pogdev.Pacientes,24,30);
Relatorios.PacientesComSintomas(pogdev.Pacientes,"dor");


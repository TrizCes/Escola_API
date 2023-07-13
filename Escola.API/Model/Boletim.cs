using Escola.API.DTO;
using System;
using System.Collections.Generic;

namespace Escola.API.Model
{
    public class Boletim
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public DateTime DateTime { get; set; }
        public ICollection<NotasMateria> NotasMaterias { get; set; }

        public Boletim (BoletimDTO boletimDTO)
        {
            Id = boletimDTO.Id;
            AlunoId = boletimDTO.AlunoId;
            if (DateTime.TryParse(boletimDTO.DateTime, out var dateTime))
                DateTime = dateTime;
            else
                throw new ArgumentException("Erro ao converter a data de edição");
        }

    }
}

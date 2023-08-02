using Escola.API.Model;
using System.Collections.Generic;
using System;

namespace Escola.API.DTO
{
    public class BoletimDTO
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        
        public DateTime DateTime { get; set; }

        public BoletimDTO() { }

        public BoletimDTO(Boletim boletim)
        {
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
            DateTime = boletim.DateTime;
        }
        
    }
}

using Escola.API.Model;
using System;

namespace Escola.API.DTO.Responses
{
    public class BoletimResponseDTO
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }

        public DateTime DateTime { get; set; }

        public BoletimResponseDTO() { }

        public BoletimResponseDTO(Boletim boletim)
        {
            Id = boletim.Id;
            AlunoId = boletim.AlunoId;
            DateTime = boletim.DateTime;
        }
    }
}

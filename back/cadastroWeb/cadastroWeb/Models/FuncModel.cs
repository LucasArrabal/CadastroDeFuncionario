using cadastroWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace cadastroWeb.Models
{
    public class FuncModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DerpartamentoEnum Derpartamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DtDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DtDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}

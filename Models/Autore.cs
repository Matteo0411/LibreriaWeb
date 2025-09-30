using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaWeb.Models
{
    public class Autore
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può superare i 50 caratteri")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il cognome non può superare i 50 caratteri")]
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data di Nascita")]
        public DateTime DataNascita { get; set; }

        [StringLength(50, ErrorMessage = "La nazionalità non può superare i 50 caratteri")]
        public string? Nazionalita { get; set; }

        [Display(Name = "Nome Completo")]
        public string NomeCompleto => $"{Nome} {Cognome}";

        public ICollection<Libro>? Libri { get; set; }
    }
}


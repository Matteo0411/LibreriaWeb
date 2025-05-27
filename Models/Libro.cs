using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaWeb.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il titolo è obbligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Il titolo deve essere tra 3 e 100 caratteri")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "L'anno di pubblicazione è obbligatorio")]
        [Range(1000, 2100, ErrorMessage = "Inserisci un anno valido")]
        public int AnnoPubblicazione { get; set; }

        [Required(ErrorMessage = "Il genere è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il genere non può superare i 50 caratteri")]
        public string Genere { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        [Range(0.01, 1000, ErrorMessage = "Il prezzo deve essere tra 0.01 e 1000")]
        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }

        [Display(Name = "Disponibile")]
        public bool Disponibile { get; set; }

        [Display(Name = "Autore")]
        public int AutoreId { get; set; }

        [ForeignKey("AutoreId")]
        public Autore? Autore { get; set; }

        [Display(Name = "Data Aggiunta")]
        [DataType(DataType.Date)]
        public DateTime DataAggiunta { get; set; }

        [StringLength(500, ErrorMessage = "La descrizione non può superare i 500 caratteri")]
        public string? Descrizione { get; set; }
    }
}
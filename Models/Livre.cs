using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotheque.Models
{
    public class Livre
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string nomLivre { get; set; }
        public string langue { get; set; }
        public string isbn { get; set; }

        [Key]
        public int idLivre { get; set; }

        [Required(ErrorMessage = "{0}est un champ requis !")]
        [Display(Name = "Auteur")]
        public string auteur { get; set; }

        [Column("annee")]
        [Display(Name = "Date de publication")]
        public DateTime anneePublication
        { get; set; }

        public string image { get; set; }

        [Column("categorie")]
        public string Categorie { get; set; }
    }
}

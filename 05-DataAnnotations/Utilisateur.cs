using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    [Table("t_utilisateurs")]
    public class Utilisateur
    {
        /*
         * Si la classe ne possède d'attribut nommé Id: utilisez [Key] pour choisir la clé primaire
         */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // l'id est en auto incrément en BD
        public int UserId { get; set; }

        [Column("Firstname")]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("Lastname")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [EmailAddress] //valider le format de l'email
        [MaxLength(2000)] //la taille est nécessaire pour les colonnes indéxeés
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] //permet de personnaliser le champs de saisie dand MVC
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateNaissance { get; set; }

        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string Adresse { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public string Photo { get; set; }

        [Required]
        [Range(1,10)]
        public int Evaluation { get; set; }

        //propriété dérivée
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_DataAnnotations
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }

        //renommer la colonne de la clé de jointure car EF utilise un undescore dans le nom de la colonne
        //- optionnel (_ en BD est déconseillé)
        //Si ajout de ForeignKey: on doit ajouter l'attribut AuthorId -> cla de jointure en BD
        [ForeignKey("AuthorId")] 
        public Author Author { get; set; } //propriété de navigation
        public int AuthorId { get; set; } // la clé de jointure

        //ManyToMany
        public List<Tag> Tags { get; set; } = new List<Tag>();
        //public Cover  Cover { get; set; }
    }
}

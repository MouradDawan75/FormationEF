using System;
using System.Data.Entity;
using System.Linq;

namespace _06_FluentApi
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
            //Afficher dans les logs les requêtes sql générées par EF
            Database.Log = chaine => Console.WriteLine(chaine);

            //Expression Lambda: méthode ano,nyme: (params) => instructions
            Action<string> myMethod = str => Console.WriteLine(str);
            Func<int,int,int> fct = (x,y) => x + y;
            Predicate<string> test = c => c.Contains("t");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cover> Covers { get; set; }

        //FluentApi: ovveride de la méthode OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Contraintes et relations
            #region Course

            modelBuilder.Entity<Course>()
                .ToTable("t_course");

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //OneToMany avec Author
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses) // relation dans l'autre sens
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(true);

            //ManyToMany avec Tag
            modelBuilder.Entity<Course>()
                .HasMany(a => a.Tags)
                .WithMany(t => t.Courses)
                .Map(m => m.ToTable("CourseTag").MapLeftKey("CourseId").MapRightKey("TagId"));

            //OneToOne avec Cover
            //La FluentApi: permet la gestion du OneToOne dans les 2 sens
            //Chose que ne permettent pas les annotations.
            //Via les annotations, on peut gérer le OneToOne que dans un seul sens (Choisir la classe principale)
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover) //HasOptional si Course ne possède pas d'attribut Cover
                .WithRequiredPrincipal(cv => cv.Course);

            #endregion

            #region Author

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        


    }

    
}
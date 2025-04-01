namespace _06_FluentApi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_06_FluentApi.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_06_FluentApi.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            #region Tag

            var tags = new Dictionary<string, Tag>
            {
                { "c#", new Tag{Id = 1, Name = "c#"} },
                { "angular", new Tag{Id = 2, Name = "Angular"} },
                { "javascript", new Tag{Id = 3, Name = "Javascript"} }
               
                };

            foreach (var item in tags.Values) {
                context.Tags.AddOrUpdate(t => t.Id, item);
            }

            #endregion

            #region Author

            var authors = new List<Author>
            {
                new Author{ Id = 1, Name = "Dawan"},
                new Author{ Id = 2, Name = "Jeahann"},
                new Author{ Id = 3, Name = "Jean"}
            };

            foreach (var author in authors)
            {
                context.Authors.AddOrUpdate(a => a.Id, author);
            }

            #endregion

            #region Course

            var courses = new List<Course> {

                new Course{ Id = 1,
                            Name = "c# Basic",
                            AuthorId = 1,
                            FullPrice = 20,
                            Description = "c# initiation",
                            Tags = new List<Tag>
                            {
                                tags["c#"]
                            }
                },
                new Course{ Id = 2,
                            Name = "Angular",
                            AuthorId = 2,
                            FullPrice = 30,
                            Description = "Angular Formation",
                            Tags = new List<Tag>
                            {
                                tags["angular"]
                            }
                },
                new Course{ Id = 3,
                            Name = "Javascript",
                            AuthorId = 3,
                            FullPrice = 20,
                            Description = "Javascript initiation",
                            Tags = new List<Tag>
                            {
                                tags["javascript"]
                            }
                }


            };

            foreach (var item in courses)
            {
                context.Courses.AddOrUpdate(c => c.Id, item);
            }

            #endregion
        }
    }
}

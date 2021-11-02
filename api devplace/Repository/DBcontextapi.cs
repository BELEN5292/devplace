using api.devplace.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DevPlace.Blog.API.Repository
{
    public class DBcontextapi : DbContext
    {
        public DBcontextapi(DbContextOptions<DBcontextapi> options)
           : base(options)
        {
        }

        public DbSet<ArticuloBlog> Articulos { get; set; }
        public DbSet<ComentarioBlog> Commentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<ArticuloBlog>().HasData(
                new ArticuloBlog()
                {
                    Id = 1,
                    Titulo = "Berry",
                    Descripcion = "Griffin Beak Eldritch",
                    
                },
                new ArticuloBlog()
                {
                    Id = 2,
                    Titulo = "Nancy",
                    Descripcion = "Swashbuckler Rye",
                    
                },
                new ArticuloBlog()
                {
                    Id = 3,
                    Titulo = "Eli",
                    Descripcion = "Ivory Bones Sweet",
                    
                },
                new ArticuloBlog()
                {
                    Id = 4,
                    Titulo = "Arnold",
                    Descripcion = "The Unseen Stafford",
                    
                },
                new ArticuloBlog()
                {
                    Id = 5,
                    Titulo = "Seabury",
                    Descripcion = "Toxic Reyson",
                    
                },
                new ArticuloBlog()
                {
                    Id = 6,
                    Titulo = "Rutherford",
                    Descripcion = "Fearless Cloven",
                    
                },
                new ArticuloBlog()
                {
                    Id = 7,
                    Titulo = "Atherton",
                    Descripcion = "Crow Ridley",
                   
                },
                new ArticuloBlog()
                {
                    Id = 8,
                    Titulo = "Huxford",
                    Descripcion = "The Hawk Morris",
                   
                },
                 new ArticuloBlog()
                 {
                     Id = 9,
                     Titulo = "Dwennon",
                     Descripcion = "Rigger Quye",
                     
                 },
                 new ArticuloBlog()
                 {
                     Id = 10,
                     Titulo = "Rushford",
                     Descripcion = "Subtle Asema",
                     
                 }
                );

            modelBuilder.Entity<ComentarioBlog>().HasData(
               new ComentarioBlog ()
               {
                   Id = 1,
                   ArticuloId = 1,
                   Texto = "Commandeering a Ship Without Getting Caught",
                   
               },
               new ComentarioBlog ()
               {
                   Id = 2,
                   ArticuloId = 1,
                   Texto = "Overthrowing Mutiny",
                   
               },
               new ComentarioBlog ()
               { 
                   Id = 3,
                   ArticuloId = 2,
                   Texto = "Avoiding Brawls While Drinking as Much Rum as You Desire",
                  
               },
                new ComentarioBlog ()
                {
                    Id = 4,
                    ArticuloId = 2,
                    Texto = "Singalong Pirate Hits",
                   
                });

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

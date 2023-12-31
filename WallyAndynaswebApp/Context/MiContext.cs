﻿using Microsoft.EntityFrameworkCore;
using WallyAndynaswebApp.Models;

namespace WallyAndynaswebApp.Context
{
    public class MiContext:DbContext
    {
        public MiContext(DbContextOptions options):base(options) 
        {
            
        }
        //que modelos deben de trabajar con la base de datos
        //estas clases persistentes, se van a transformar en tablas en la BdD
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<Alquiler> Alquilers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhotoSmart.Core.Models;
using static Mysqlx.Error.Types;
namespace PhotoSmart.Data;

public class PhotoSmartContext : DbContext
{
    public PhotoSmartContext(DbContextOptions<PhotoSmartContext> options)
        : base(options)
    {

    }

   
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
public DbSet<User> Users { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Guest> Guests { get; set; }

    


}



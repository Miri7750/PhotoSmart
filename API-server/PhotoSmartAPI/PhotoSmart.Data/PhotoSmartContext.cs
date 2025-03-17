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

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

}
   

    
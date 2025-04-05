using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zadania.Models;

public partial class AaaonninenContext : DbContext
{
    public AaaonninenContext()
    {
    }

    public AaaonninenContext(DbContextOptions<AaaonninenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobTime> JobTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=aaaonninen.mssql.somee.com;packet size=4096;user id=onninen_SQLLogin_1;pwd=dh8ozr3fa8;data source=aaaonninen.mssql.somee.com;persist security info=False;initial catalog=aaaonninen;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

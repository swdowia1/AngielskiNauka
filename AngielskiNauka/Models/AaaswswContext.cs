using Microsoft.EntityFrameworkCore;

namespace AngielskiNauka.Models;

public partial class AaaswswContext : DbContext
{
    public AaaswswContext()
    {
    }

    public AaaswswContext(DbContextOptions<AaaswswContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dane> Danes { get; set; }



    public virtual DbSet<Poziom> Pozioms { get; set; }

    public virtual DbSet<Stat> Stats { get; set; }
    public virtual DbSet<Ustawienia> Ustawienias { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("workstation id=aaaswsw.mssql.somee.com;packet size=4096;user id=swdowia1_SQLLogin_2;pwd=kr62j5x3px;data source=aaaswsw.mssql.somee.com;persist security info=False;initial catalog=aaaswsw;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Dane>(entity =>
        {
            entity.HasIndex(e => e.PoziomId, "IX_Danes_PoziomId");

            entity.HasOne(d => d.Poziom).WithMany(p => p.Danes).HasForeignKey(d => d.PoziomId);
        });



        modelBuilder.Entity<Stat>(entity =>
        {
            entity.HasIndex(e => e.PoziomId, "IX_Stats_PoziomId");

            entity.HasOne(d => d.Poziom).WithMany(p => p.Stats).HasForeignKey(d => d.PoziomId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

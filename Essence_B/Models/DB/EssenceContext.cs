using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Essence_B.Models.DB;

public partial class EssenceContext : DbContext
{
    public EssenceContext()
    {
    }

    public EssenceContext(DbContextOptions<EssenceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tbconcentration> Tbconcentrations { get; set; }

    public virtual DbSet<Tbgender> Tbgenders { get; set; }

    public virtual DbSet<Tbhouse> Tbhouses { get; set; }

    public virtual DbSet<Tbnote> Tbnotes { get; set; }

    public virtual DbSet<TbnoteType> TbnoteTypes { get; set; }

    public virtual DbSet<Tborigin> Tborigins { get; set; }

    public virtual DbSet<Tbperfum> Tbperfums { get; set; }

    public virtual DbSet<TbperfumNote> TbperfumNotes { get; set; }

    public virtual DbSet<Tbrol> Tbrols { get; set; }

    public virtual DbSet<Tbsale> Tbsales { get; set; }

    public virtual DbSet<Tbsize> Tbsizes { get; set; }

    public virtual DbSet<Tbuser> Tbusers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=JAMES; Database=Essence; Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tbconcentration>(entity =>
        {
            entity.HasKey(e => e.IdConcentration).HasName("PK__TBConcen__DF3630AC563C9CC7");

            entity.ToTable("TBConcentration");

            entity.Property(e => e.IdConcentration).HasColumnName("idConcentration");
            entity.Property(e => e.Concentration)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("concentration");
        });

        modelBuilder.Entity<Tbgender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("PK__TBGender__85D207807CFD4774");

            entity.ToTable("TBGenders");

            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Tbhouse>(entity =>
        {
            entity.HasKey(e => e.IdHouse).HasName("PK__TBHouses__AF515CBF06E9DFF6");

            entity.ToTable("TBHouses");

            entity.Property(e => e.IdHouse).HasColumnName("idHouse");
            entity.Property(e => e.House)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("house");
            entity.Property(e => e.IdOrigin).HasColumnName("idOrigin");

            entity.HasOne(d => d.IdOriginNavigation).WithMany(p => p.Tbhouses)
                .HasForeignKey(d => d.IdOrigin)
                .HasConstraintName("FK_House_Origin");
        });

        modelBuilder.Entity<Tbnote>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PK__TBNotes__AD5F462A3150464C");

            entity.ToTable("TBNotes");

            entity.Property(e => e.IdNote).HasColumnName("idNote");
            entity.Property(e => e.Note)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("note");
        });

        modelBuilder.Entity<TbnoteType>(entity =>
        {
            entity.HasKey(e => e.IdNoteType).HasName("PK__TBNoteTy__B5A3DA07B151EAE6");

            entity.ToTable("TBNoteTypes");

            entity.Property(e => e.IdNoteType).HasColumnName("idNoteType");
            entity.Property(e => e.NoteType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("noteType");
        });

        modelBuilder.Entity<Tborigin>(entity =>
        {
            entity.HasKey(e => e.IdOrigin).HasName("PK__TBOrigin__9F19086AE6A9CED3");

            entity.ToTable("TBOrigins");

            entity.Property(e => e.IdOrigin).HasColumnName("idOrigin");
            entity.Property(e => e.Origin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("origin");
        });

        modelBuilder.Entity<Tbperfum>(entity =>
        {
            entity.HasKey(e => e.IdPerfum).HasName("PK__TBPerfum__40F3E0609A28FBA1");

            entity.ToTable("TBPerfums");

            entity.Property(e => e.IdPerfum).HasColumnName("idPerfum");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdConcentration).HasColumnName("idConcentration");
            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.IdHouse).HasColumnName("idHouse");
            entity.Property(e => e.IdOrigin).HasColumnName("idOrigin");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .HasMaxLength(3000)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdConcentrationNavigation).WithMany(p => p.Tbperfums)
                .HasForeignKey(d => d.IdConcentration)
                .HasConstraintName("FK_Perfum_Concentration");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Tbperfums)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("FK_Perfum_Gender");

            entity.HasOne(d => d.IdHouseNavigation).WithMany(p => p.Tbperfums)
                .HasForeignKey(d => d.IdHouse)
                .HasConstraintName("FK_Perfum_House");

            entity.HasOne(d => d.IdOriginNavigation).WithMany(p => p.Tbperfums)
                .HasForeignKey(d => d.IdOrigin)
                .HasConstraintName("FK_Perfums_Origins");

            entity.HasMany(d => d.IdSizes).WithMany(p => p.IdPerfums)
                .UsingEntity<Dictionary<string, object>>(
                    "TbperfumSize",
                    r => r.HasOne<Tbsize>().WithMany()
                        .HasForeignKey("IdSize")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Size_Perfum"),
                    l => l.HasOne<Tbperfum>().WithMany()
                        .HasForeignKey("IdPerfum")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Perfum_PerfumSize"),
                    j =>
                    {
                        j.HasKey("IdPerfum", "IdSize").HasName("PK__TBPerfum__EC9A1A6506CC1730");
                        j.ToTable("TBPerfum_Size");
                        j.IndexerProperty<int>("IdPerfum").HasColumnName("idPerfum");
                        j.IndexerProperty<short>("IdSize").HasColumnName("idSize");
                    });
        });

        modelBuilder.Entity<TbperfumNote>(entity =>
        {
            entity.HasKey(e => new { e.IdPerfum, e.IdNote, e.IdNoteType }).HasName("PK__TBPerfum__FC93B7D8A6044DC8");

            entity.ToTable("TBPerfum_Note");

            entity.Property(e => e.IdPerfum).HasColumnName("idPerfum");
            entity.Property(e => e.IdNote).HasColumnName("idNote");
            entity.Property(e => e.IdNoteType).HasColumnName("idNoteType");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdNoteNavigation).WithMany(p => p.TbperfumNotes)
                .HasForeignKey(d => d.IdNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Note_PerfumNote");

            entity.HasOne(d => d.IdNoteTypeNavigation).WithMany(p => p.TbperfumNotes)
                .HasForeignKey(d => d.IdNoteType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NoteType_PerfumNote");

            entity.HasOne(d => d.IdPerfumNavigation).WithMany(p => p.TbperfumNotes)
                .HasForeignKey(d => d.IdPerfum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Perfum_PerfumNote");
        });

        modelBuilder.Entity<Tbrol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__TBRols__3C872F765F6FA3A9");

            entity.ToTable("TBRols");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<Tbsale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__TBSales__C4AEB198A7684E5F");

            entity.ToTable("TBSales");

            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IdPerfum).HasColumnName("idPerfum");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SendDate).HasColumnName("sendDate");

            entity.HasOne(d => d.IdPerfumNavigation).WithMany(p => p.Tbsales)
                .HasForeignKey(d => d.IdPerfum)
                .HasConstraintName("FK_Sale_Perfum");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Tbsales)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Sale_User");
        });

        modelBuilder.Entity<Tbsize>(entity =>
        {
            entity.HasKey(e => e.IdSize).HasName("PK__TBSizes__C69FA05B59078756");

            entity.ToTable("TBSizes");

            entity.Property(e => e.IdSize).HasColumnName("idSize");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<Tbuser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__TBUsers__3717C9822418D3B5");

            entity.ToTable("TBUsers");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.HashPassword)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("hashPassword");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.SaltPassword)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("saltPassword");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Tbusers)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_User_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

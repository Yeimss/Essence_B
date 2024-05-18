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

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<TbConcentration> TbConcentrations { get; set; }

    public virtual DbSet<TbGender> TbGenders { get; set; }

    public virtual DbSet<TbHouse> TbHouses { get; set; }

    public virtual DbSet<TbNote> TbNotes { get; set; }

    public virtual DbSet<TbNoteType> TbNoteTypes { get; set; }

    public virtual DbSet<TbOrigin> TbOrigins { get; set; }

    public virtual DbSet<TbPerfum> TbPerfums { get; set; }

    public virtual DbSet<TbPerfumNote> TbPerfumNotes { get; set; }

    public virtual DbSet<TbRol> TbRols { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=JAMES; Database=Essence; Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__Sales__C4AEB1984A0318CD");

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

            entity.HasOne(d => d.IdPerfumNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdPerfum)
                .HasConstraintName("FK_Sale_Perfum");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Sale_User");
        });

        modelBuilder.Entity<TbConcentration>(entity =>
        {
            entity.HasKey(e => e.IdConcentration).HasName("PK__TB_Conce__DF3630AC029E868B");

            entity.ToTable("TB_Concentration");

            entity.Property(e => e.IdConcentration).HasColumnName("idConcentration");
            entity.Property(e => e.Concentration)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("concentration");
        });

        modelBuilder.Entity<TbGender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("PK__TB_Gende__85D20780360E0CA0");

            entity.ToTable("TB_Genders");

            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<TbHouse>(entity =>
        {
            entity.HasKey(e => e.IdHouse).HasName("PK__TB_House__AF515CBF83BAAF08");

            entity.ToTable("TB_Houses");

            entity.Property(e => e.IdHouse).HasColumnName("idHouse");
            entity.Property(e => e.House)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("house");
            entity.Property(e => e.IdOrigin).HasColumnName("idOrigin");

            entity.HasOne(d => d.IdOriginNavigation).WithMany(p => p.TbHouses)
                .HasForeignKey(d => d.IdOrigin)
                .HasConstraintName("FK_House_Origin");
        });

        modelBuilder.Entity<TbNote>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PK__TB_Notes__AD5F462AD30708F1");

            entity.ToTable("TB_Notes");

            entity.Property(e => e.IdNote).HasColumnName("idNote");
            entity.Property(e => e.Note)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("note");
        });

        modelBuilder.Entity<TbNoteType>(entity =>
        {
            entity.HasKey(e => e.IdNoteType).HasName("PK__TB_NoteT__B5A3DA07D0410A9E");

            entity.ToTable("TB_NoteTypes");

            entity.Property(e => e.IdNoteType).HasColumnName("idNoteType");
            entity.Property(e => e.NoteType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("noteType");
        });

        modelBuilder.Entity<TbOrigin>(entity =>
        {
            entity.HasKey(e => e.IdOrigin).HasName("PK__TB_Origi__9F19086AD20A1B48");

            entity.ToTable("TB_Origins");

            entity.Property(e => e.IdOrigin).HasColumnName("idOrigin");
            entity.Property(e => e.Origin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("origin");
        });

        modelBuilder.Entity<TbPerfum>(entity =>
        {
            entity.HasKey(e => e.IdPerfum).HasName("PK__TB_Perfu__40F3E060D8063BD3");

            entity.ToTable("TB_Perfums");

            entity.Property(e => e.IdPerfum).HasColumnName("idPerfum");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdConcentration).HasColumnName("idConcentration");
            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.IdHouse).HasColumnName("idHouse");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdConcentrationNavigation).WithMany(p => p.TbPerfums)
                .HasForeignKey(d => d.IdConcentration)
                .HasConstraintName("FK_Perfum_Concentration");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.TbPerfums)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("FK_Perfum_Gender");

            entity.HasOne(d => d.IdHouseNavigation).WithMany(p => p.TbPerfums)
                .HasForeignKey(d => d.IdHouse)
                .HasConstraintName("FK_Perfum_House");
        });

        modelBuilder.Entity<TbPerfumNote>(entity =>
        {
            entity.HasKey(e => new { e.IdPerfum, e.IdNote, e.IdNoteType }).HasName("PK__TB_Perfu__FC93B7D8D8DCAE01");

            entity.ToTable("TB_Perfum_Note");

            entity.Property(e => e.IdPerfum).HasColumnName("idPerfum");
            entity.Property(e => e.IdNote).HasColumnName("idNote");
            entity.Property(e => e.IdNoteType).HasColumnName("idNoteType");
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdNoteNavigation).WithMany(p => p.TbPerfumNotes)
                .HasForeignKey(d => d.IdNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Note_PerfumNote");

            entity.HasOne(d => d.IdNoteTypeNavigation).WithMany(p => p.TbPerfumNotes)
                .HasForeignKey(d => d.IdNoteType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NoteType_PerfumNote");

            entity.HasOne(d => d.IdPerfumNavigation).WithMany(p => p.TbPerfumNotes)
                .HasForeignKey(d => d.IdPerfum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Perfum_PerfumNote");
        });

        modelBuilder.Entity<TbRol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__TB_Rols__3C872F7685D28057");

            entity.ToTable("TB_Rols");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__TB_Users__3717C9823B0AF5B0");

            entity.ToTable("TB_Users");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("firstname");
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

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_User_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

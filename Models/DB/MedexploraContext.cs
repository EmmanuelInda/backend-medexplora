using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MedExploraAPI.Models.DB;

public partial class MedexploraContext : DbContext
{
    public MedexploraContext()
    {
    }

    public MedexploraContext(DbContextOptions<MedexploraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyPart> BodyParts { get; set; }

    public virtual DbSet<BodySection> BodySections { get; set; }

    public virtual DbSet<ExamStep> ExamSteps { get; set; }

    public virtual DbSet<ExamType> ExamTypes { get; set; }

    public virtual DbSet<Hotspot> Hotspots { get; set; }

    public virtual DbSet<MediaAsset> MediaAssets { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RelatedPart> RelatedParts { get; set; }

    public virtual DbSet<SectionExam> SectionExams { get; set; }

    public virtual DbSet<Synonym> Synonyms { get; set; }

    public virtual DbSet<Models.DB.System> Systems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
            optionsBuilder.UseMySql(
                "server=localhost;port=3307;database=cuerpohumano;user=root;treattinyasboolean=true",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<BodyPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("body_parts")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ModelId, "fk_bp_model");

            entity.HasIndex(e => e.ParentId, "fk_bp_parent");

            entity.HasIndex(e => e.RegionCode, "fk_bp_region");

            entity.HasIndex(e => e.SystemCode, "fk_bp_system");

            entity.HasIndex(e => e.Slug, "slug").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DescriptionEn)
                .HasColumnType("text")
                .HasColumnName("description_en");
            entity.Property(e => e.DescriptionEs)
                .HasColumnType("text")
                .HasColumnName("description_es");
            entity.Property(e => e.IsVisible)
                .HasDefaultValueSql("'1'")
                .HasColumnName("is_visible");
            entity.Property(e => e.MeshKey)
                .HasMaxLength(160)
                .HasColumnName("mesh_key");
            entity.Property(e => e.ModelId)
                .HasColumnType("int(11)")
                .HasColumnName("model_id");
            entity.Property(e => e.NameEn)
                .HasMaxLength(160)
                .HasColumnName("name_en");
            entity.Property(e => e.NameEs)
                .HasMaxLength(160)
                .HasColumnName("name_es");
            entity.Property(e => e.ParentId)
                .HasColumnType("int(11)")
                .HasColumnName("parent_id");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(32)
                .HasColumnName("region_code");
            entity.Property(e => e.Sex)
                .HasDefaultValueSql("'na'")
                .HasColumnType("enum('masculino','femenino','ambos','na')")
                .HasColumnName("sex");
            entity.Property(e => e.Side)
                .HasDefaultValueSql("'medio'")
                .HasColumnType("enum('izquierda','derecha','medio','ambas')")
                .HasColumnName("side");
            entity.Property(e => e.Slug)
                .HasMaxLength(96)
                .HasColumnName("slug");
            entity.Property(e => e.SortOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("sort_order");
            entity.Property(e => e.SystemCode)
                .HasMaxLength(32)
                .HasColumnName("system_code");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Model).WithMany(p => p.BodyParts)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("fk_bp_model");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_bp_parent");

            entity.HasOne(d => d.RegionCodeNavigation).WithMany(p => p.BodyParts)
                .HasForeignKey(d => d.RegionCode)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_bp_region");

            entity.HasOne(d => d.SystemCodeNavigation).WithMany(p => p.BodyParts)
                .HasForeignKey(d => d.SystemCode)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_bp_system");
        });

        modelBuilder.Entity<BodySection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("body_sections")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.BodyPartId, "fk_section_part");

            entity.HasIndex(e => e.Slug, "slug").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BodyPartId)
                .HasColumnType("int(11)")
                .HasColumnName("body_part_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.NameEn)
                .HasMaxLength(160)
                .HasColumnName("name_en");
            entity.Property(e => e.NameEs)
                .HasMaxLength(160)
                .HasColumnName("name_es");
            entity.Property(e => e.Slug)
                .HasMaxLength(96)
                .HasColumnName("slug");
            entity.Property(e => e.SortOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("sort_order");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.BodyPart).WithMany(p => p.BodySections)
                .HasForeignKey(d => d.BodyPartId)
                .HasConstraintName("fk_section_part");
        });

        modelBuilder.Entity<ExamStep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("exam_steps")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.SectionExamId, "fk_step_section_exam");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DetailEn)
                .HasColumnType("text")
                .HasColumnName("detail_en");
            entity.Property(e => e.DetailEs)
                .HasColumnType("text")
                .HasColumnName("detail_es");
            entity.Property(e => e.LabelEn)
                .HasMaxLength(200)
                .HasColumnName("label_en");
            entity.Property(e => e.LabelEs)
                .HasMaxLength(200)
                .HasColumnName("label_es");
            entity.Property(e => e.SectionExamId)
                .HasColumnType("int(11)")
                .HasColumnName("section_exam_id");
            entity.Property(e => e.StepOrder)
                .HasColumnType("int(11)")
                .HasColumnName("step_order");

            entity.HasOne(d => d.SectionExam).WithMany(p => p.ExamSteps)
                .HasForeignKey(d => d.SectionExamId)
                .HasConstraintName("fk_step_section_exam");
        });

        modelBuilder.Entity<ExamType>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity
                .ToTable("exam_types")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Code)
                .HasMaxLength(32)
                .HasColumnName("code");
            entity.Property(e => e.NameEn)
                .HasMaxLength(80)
                .HasColumnName("name_en");
            entity.Property(e => e.NameEs)
                .HasMaxLength(80)
                .HasColumnName("name_es");
            entity.Property(e => e.SortOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("sort_order");
        });

        modelBuilder.Entity<Hotspot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hotspots")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.BodyPartId, "fk_hot_bp");

            entity.HasIndex(e => new { e.ModelId, e.MeshName }, "uq_hotspot").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BodyPartId)
                .HasColumnType("int(11)")
                .HasColumnName("body_part_id");
            entity.Property(e => e.MeshName)
                .HasMaxLength(160)
                .HasColumnName("mesh_name");
            entity.Property(e => e.ModelId)
                .HasColumnType("int(11)")
                .HasColumnName("model_id");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");
            entity.Property(e => e.Z).HasColumnName("z");

            entity.HasOne(d => d.BodyPart).WithMany(p => p.Hotspots)
                .HasForeignKey(d => d.BodyPartId)
                .HasConstraintName("fk_hot_bp");

            entity.HasOne(d => d.Model).WithMany(p => p.Hotspots)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("fk_hot_model");
        });

        modelBuilder.Entity<MediaAsset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("media_assets")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.BodyPartId, "fk_media_bp");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Attribution)
                .HasMaxLength(255)
                .HasColumnName("attribution");
            entity.Property(e => e.BodyPartId)
                .HasColumnType("int(11)")
                .HasColumnName("body_part_id");
            entity.Property(e => e.CaptionEn)
                .HasMaxLength(255)
                .HasColumnName("caption_en");
            entity.Property(e => e.CaptionEs)
                .HasMaxLength(255)
                .HasColumnName("caption_es");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.License)
                .HasMaxLength(120)
                .HasColumnName("license");
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .HasColumnName("path");
            entity.Property(e => e.Type)
                .HasColumnType("enum('image','video','audio','model','pdf','link')")
                .HasColumnName("type");

            entity.HasOne(d => d.BodyPart).WithMany(p => p.MediaAssets)
                .HasForeignKey(d => d.BodyPartId)
                .HasConstraintName("fk_media_bp");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("models")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(64)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("file_path");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Version)
                .HasMaxLength(32)
                .HasColumnName("version");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity
                .ToTable("regions")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Code)
                .HasMaxLength(32)
                .HasColumnName("code");
            entity.Property(e => e.NameEn)
                .HasMaxLength(120)
                .HasColumnName("name_en");
            entity.Property(e => e.NameEs)
                .HasMaxLength(120)
                .HasColumnName("name_es");
        });

        modelBuilder.Entity<RelatedPart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("related_parts")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.SourcePartId, "fk_rel_src");

            entity.HasIndex(e => e.TargetPartId, "fk_rel_tgt");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.RelationType)
                .HasColumnType("enum('parte_de','componente_de','inervada_por','irrigada_por','drena_a','relacionada_con')")
                .HasColumnName("relation_type");
            entity.Property(e => e.SourcePartId)
                .HasColumnType("int(11)")
                .HasColumnName("source_part_id");
            entity.Property(e => e.TargetPartId)
                .HasColumnType("int(11)")
                .HasColumnName("target_part_id");

            entity.HasOne(d => d.SourcePart).WithMany(p => p.RelatedPartSourceParts)
                .HasForeignKey(d => d.SourcePartId)
                .HasConstraintName("fk_rel_src");

            entity.HasOne(d => d.TargetPart).WithMany(p => p.RelatedPartTargetParts)
                .HasForeignKey(d => d.TargetPartId)
                .HasConstraintName("fk_rel_tgt");
        });

        modelBuilder.Entity<SectionExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("section_exams")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.ExamTypeCode, "fk_se_exam_type");

            entity.HasIndex(e => new { e.SectionId, e.ExamTypeCode }, "uq_sec_exam").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ExamTypeCode)
                .HasMaxLength(32)
                .HasColumnName("exam_type_code");
            entity.Property(e => e.SectionId)
                .HasColumnType("int(11)")
                .HasColumnName("section_id");
            entity.Property(e => e.SourceRef)
                .HasMaxLength(255)
                .HasColumnName("source_ref");
            entity.Property(e => e.SummaryEn)
                .HasColumnType("text")
                .HasColumnName("summary_en");
            entity.Property(e => e.SummaryEs)
                .HasColumnType("text")
                .HasColumnName("summary_es");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(160)
                .HasColumnName("title_en");
            entity.Property(e => e.TitleEs)
                .HasMaxLength(160)
                .HasColumnName("title_es");

            entity.HasOne(d => d.ExamTypeCodeNavigation).WithMany(p => p.SectionExams)
                .HasForeignKey(d => d.ExamTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_se_exam_type");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionExams)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("fk_se_section");
        });

        modelBuilder.Entity<Synonym>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("synonyms")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.BodyPartId, e.Lang, e.Term }, "uq_syn").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BodyPartId)
                .HasColumnType("int(11)")
                .HasColumnName("body_part_id");
            entity.Property(e => e.Lang)
                .HasColumnType("enum('es','en')")
                .HasColumnName("lang");
            entity.Property(e => e.Term)
                .HasMaxLength(160)
                .HasColumnName("term");

            entity.HasOne(d => d.BodyPart).WithMany(p => p.Synonyms)
                .HasForeignKey(d => d.BodyPartId)
                .HasConstraintName("fk_syn_bp");
        });

        modelBuilder.Entity<System>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");

            entity
                .ToTable("systems")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Code)
                .HasMaxLength(32)
                .HasColumnName("code");
            entity.Property(e => e.NameEn)
                .HasMaxLength(120)
                .HasColumnName("name_en");
            entity.Property(e => e.NameEs)
                .HasMaxLength(120)
                .HasColumnName("name_es");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

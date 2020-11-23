namespace TRKPortfolio.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TRKPortfolio.Data.Common.Models;
    using TRKPortfolio.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paragraph> Paragraphs { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        public DbSet<PostLike> PostLikes { get; set; }

        public DbSet<PostSave> PostSaves { get; set; }

        public DbSet<PostParagraph> PostParagraphs { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectAttachment> ProjectAttachments { get; set; }

        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbSet<ProjectLike> ProjectLikes { get; set; }

        public DbSet<ProjectSave> ProjectSaves { get; set; }

        public DbSet<ProjectSkill> ProjectSkills { get; set; }

        public DbSet<ProjectParagraph> ProjectParagraphs { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<TestimonialAttachment> TestimonialAttachments { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Set composite keys
            builder.Entity<ProjectAttachment>()
               .HasKey(k => new { k.ProjectId, k.AttachmentId });

            builder.Entity<TestimonialAttachment>()
               .HasKey(k => new { k.TestimonialId, k.AttachmentId });

            builder.Entity<PostCategory>()
               .HasKey(k => new { k.PostId, k.CategoryId });

            builder.Entity<ProjectCategory>()
               .HasKey(k => new { k.ProjectId, k.CategoryId });

            builder.Entity<ProjectSkill>()
               .HasKey(k => new { k.ProjectId, k.SkillId });

            builder.Entity<PostParagraph>()
              .HasKey(k => new { k.PostId, k.ParagraphId });

            builder.Entity<ProjectParagraph>()
              .HasKey(k => new { k.ProjectId, k.ParagraphId });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}

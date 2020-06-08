using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TechlandMysqlMigrateApi.Model
{
    public partial class techlandContext : DbContext
    {
        public string ConnectionString { get; set; }

        public techlandContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private techlandContext GetConnection()
        {
            return new techlandContext(ConnectionString);
        }
        //public techlandContext()
        //{
        //}

        //public techlandContext(DbContextOptions<techlandContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<WpCommentmeta> WpCommentmeta { get; set; }
        public virtual DbSet<WpComments> WpComments { get; set; }
        public virtual DbSet<WpLinks> WpLinks { get; set; }
        public virtual DbSet<WpOptions> WpOptions { get; set; }
        public virtual DbSet<WpPostmeta> WpPostmeta { get; set; }
        public virtual DbSet<WpPosts> WpPosts { get; set; }
        public virtual DbSet<WpTermRelationships> WpTermRelationships { get; set; }
        public virtual DbSet<WpTermTaxonomy> WpTermTaxonomy { get; set; }
        public virtual DbSet<WpTermmeta> WpTermmeta { get; set; }
        public virtual DbSet<WpTerms> WpTerms { get; set; }
        public virtual DbSet<WpUsermeta> WpUsermeta { get; set; }
        public virtual DbSet<WpUsers> WpUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=elcin123;database=techland");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WpCommentmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_commentmeta");

                entity.HasIndex(e => e.CommentId)
                    .HasName("comment_id");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpComments>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_comments");

                entity.HasIndex(e => e.CommentAuthorEmail)
                    .HasName("comment_author_email");

                entity.HasIndex(e => e.CommentDateGmt)
                    .HasName("comment_date_gmt");

                entity.HasIndex(e => e.CommentParent)
                    .HasName("comment_parent");

                entity.HasIndex(e => e.CommentPostId)
                    .HasName("comment_post_ID");

                entity.HasIndex(e => new { e.CommentApproved, e.CommentDateGmt })
                    .HasName("comment_approved_date_gmt");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentAgent)
                    .IsRequired()
                    .HasColumnName("comment_agent")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentApproved)
                    .IsRequired()
                    .HasColumnName("comment_approved")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CommentAuthor)
                    .IsRequired()
                    .HasColumnName("comment_author")
                    .HasColumnType("tinytext");

                entity.Property(e => e.CommentAuthorEmail)
                    .IsRequired()
                    .HasColumnName("comment_author_email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentAuthorIp)
                    .IsRequired()
                    .HasColumnName("comment_author_IP")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentAuthorUrl)
                    .IsRequired()
                    .HasColumnName("comment_author_url")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasColumnName("comment_content");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CommentDateGmt)
                    .HasColumnName("comment_date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CommentKarma).HasColumnName("comment_karma");

                entity.Property(e => e.CommentParent)
                    .HasColumnName("comment_parent")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentPostId)
                    .HasColumnName("comment_post_ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentType)
                    .IsRequired()
                    .HasColumnName("comment_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpLinks>(entity =>
            {
                entity.HasKey(e => e.LinkId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_links");

                entity.HasIndex(e => e.LinkVisible)
                    .HasName("link_visible");

                entity.Property(e => e.LinkId)
                    .HasColumnName("link_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.LinkDescription)
                    .IsRequired()
                    .HasColumnName("link_description")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkImage)
                    .IsRequired()
                    .HasColumnName("link_image")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkName)
                    .IsRequired()
                    .HasColumnName("link_name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkNotes)
                    .IsRequired()
                    .HasColumnName("link_notes")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.LinkOwner)
                    .HasColumnName("link_owner")
                    .HasColumnType("bigint unsigned")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LinkRating).HasColumnName("link_rating");

                entity.Property(e => e.LinkRel)
                    .IsRequired()
                    .HasColumnName("link_rel")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkRss)
                    .IsRequired()
                    .HasColumnName("link_rss")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkTarget)
                    .IsRequired()
                    .HasColumnName("link_target")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkUpdated)
                    .HasColumnName("link_updated")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.LinkUrl)
                    .IsRequired()
                    .HasColumnName("link_url")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LinkVisible)
                    .IsRequired()
                    .HasColumnName("link_visible")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Y'");
            });

            modelBuilder.Entity<WpOptions>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_options");

                entity.HasIndex(e => e.OptionName)
                    .HasName("option_name")
                    .IsUnique();

                entity.Property(e => e.OptionId)
                    .HasColumnName("option_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Autoload)
                    .IsRequired()
                    .HasColumnName("autoload")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'yes'");

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasColumnName("option_name")
                    .HasMaxLength(191)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.OptionValue)
                    .IsRequired()
                    .HasColumnName("option_value")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<WpPostmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_postmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.PostId)
                    .HasName("post_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpPosts>(entity =>
            {
                entity.ToTable("wp_posts");

                entity.HasIndex(e => e.PostAuthor)
                    .HasName("post_author");

                entity.HasIndex(e => e.PostName)
                    .HasName("post_name");

                entity.HasIndex(e => e.PostParent)
                    .HasName("post_parent");

                entity.HasIndex(e => new { e.PostType, e.PostStatus, e.PostDate, e.Id })
                    .HasName("type_status_date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.CommentCount).HasColumnName("comment_count");

                entity.Property(e => e.CommentStatus)
                    .IsRequired()
                    .HasColumnName("comment_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'open'");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("guid")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MenuOrder).HasColumnName("menu_order");

                entity.Property(e => e.PingStatus)
                    .IsRequired()
                    .HasColumnName("ping_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'open'");

                entity.Property(e => e.Pinged)
                    .IsRequired()
                    .HasColumnName("pinged");

                entity.Property(e => e.PostAuthor)
                    .HasColumnName("post_author")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.PostContent)
                    .IsRequired()
                    .HasColumnName("post_content")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostContentFiltered)
                    .IsRequired()
                    .HasColumnName("post_content_filtered")
                    .HasColumnType("longtext");

                entity.Property(e => e.PostDate)
                    .HasColumnName("post_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostDateGmt)
                    .HasColumnName("post_date_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostExcerpt)
                    .IsRequired()
                    .HasColumnName("post_excerpt");

                entity.Property(e => e.PostMimeType)
                    .IsRequired()
                    .HasColumnName("post_mime_type")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostModified)
                    .HasColumnName("post_modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostModifiedGmt)
                    .HasColumnName("post_modified_gmt")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasColumnName("post_name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostParent)
                    .HasColumnName("post_parent")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.PostPassword)
                    .IsRequired()
                    .HasColumnName("post_password")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PostStatus)
                    .IsRequired()
                    .HasColumnName("post_status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'publish'");

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasColumnName("post_title");

                entity.Property(e => e.PostType)
                    .IsRequired()
                    .HasColumnName("post_type")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'post'");

                entity.Property(e => e.ToPing)
                    .IsRequired()
                    .HasColumnName("to_ping");
            });

            modelBuilder.Entity<WpTermRelationships>(entity =>
            {
                entity.HasKey(e => new { e.ObjectId, e.TermTaxonomyId })
                    .HasName("PRIMARY");

                entity.ToTable("wp_term_relationships");

                entity.HasIndex(e => e.TermTaxonomyId)
                    .HasName("term_taxonomy_id");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TermTaxonomyId)
                    .HasColumnName("term_taxonomy_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.TermOrder).HasColumnName("term_order");
            });

            modelBuilder.Entity<WpTermTaxonomy>(entity =>
            {
                entity.HasKey(e => e.TermTaxonomyId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_term_taxonomy");

                entity.HasIndex(e => e.Taxonomy)
                    .HasName("taxonomy");

                entity.HasIndex(e => new { e.TermId, e.Taxonomy })
                    .HasName("term_id_taxonomy")
                    .IsUnique();

                entity.Property(e => e.TermTaxonomyId)
                    .HasColumnName("term_taxonomy_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Taxonomy)
                    .IsRequired()
                    .HasColumnName("taxonomy")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpTermmeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_termmeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.TermId)
                    .HasName("term_id");

                entity.Property(e => e.MetaId)
                    .HasColumnName("meta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpTerms>(entity =>
            {
                entity.HasKey(e => e.TermId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_terms");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.Slug)
                    .HasName("slug");

                entity.Property(e => e.TermId)
                    .HasColumnName("term_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TermGroup).HasColumnName("term_group");
            });

            modelBuilder.Entity<WpUsermeta>(entity =>
            {
                entity.HasKey(e => e.UmetaId)
                    .HasName("PRIMARY");

                entity.ToTable("wp_usermeta");

                entity.HasIndex(e => e.MetaKey)
                    .HasName("meta_key");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.UmetaId)
                    .HasColumnName("umeta_id")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.MetaKey)
                    .HasColumnName("meta_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaValue)
                    .HasColumnName("meta_value")
                    .HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint unsigned");
            });

            modelBuilder.Entity<WpUsers>(entity =>
            {
                entity.ToTable("wp_users");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("user_email");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("user_login_key");

                entity.HasIndex(e => e.UserNicename)
                    .HasName("user_nicename");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("bigint unsigned");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("display_name")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserActivationKey)
                    .IsRequired()
                    .HasColumnName("user_activation_key")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("user_login")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserNicename)
                    .IsRequired()
                    .HasColumnName("user_nicename")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasColumnName("user_pass")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.UserRegistered)
                    .HasColumnName("user_registered")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.UserStatus).HasColumnName("user_status");

                entity.Property(e => e.UserUrl)
                    .IsRequired()
                    .HasColumnName("user_url")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

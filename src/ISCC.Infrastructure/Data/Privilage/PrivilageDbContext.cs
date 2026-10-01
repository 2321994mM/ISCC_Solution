using Microsoft.EntityFrameworkCore;

namespace ISCC.Infrastructure.Data.Privilage;

/// <summary>
/// The second and only other DbContext: <c>dbPrivilage</c>, which holds the RBAC and
/// user data.
/// </summary>
/// <remarks>
/// <para>
/// <b>Deliberately a separate context, not more <c>DbSet</c>s on
/// <see cref="PlantQuarantineDbContext"/>.</b> The two databases have different
/// lifetimes, different backup schedules and different owners, and the legacy
/// application already treated them as two independent connections. Merging them would
/// mean a single context spanning two databases, which forces cross-database joins EF
/// Core cannot express and puts the auth tables at risk from the same migrations as the
/// 298 business tables.
/// </para>
/// <para>
/// Mirrors the legacy <c>PlantQuarantine.NewMvc</c> design, which held both a
/// <c>Privilege</c> and a <c>PlantQuarantine</c> connection string. The outlet lookup
/// that enriches the signed-in user crosses the boundary, and is done deliberately in
/// <c>UserAuthenticationService</c> rather than through a navigation property, because
/// EF cannot join across two contexts.
/// </para>
/// <para>
/// Registered in <see cref="Infrastructure.DependencyInjection"/> against the
/// <c>PrivilegeConnection</c> connection string. Only three tables are mapped; see
/// <see cref="PrUser"/> for why the other nine are not.
/// </para>
/// </remarks>
public class PrivilageDbContext : DbContext
{
    /// <summary>Creates a context with no configured provider. Used by design-time tooling only.</summary>
    public PrivilageDbContext()
    {
    }

    /// <summary>Creates a context with an explicit provider configuration.</summary>
    /// <param name="options">Provider options, normally built by the DI container.</param>
    public PrivilageDbContext(DbContextOptions<PrivilageDbContext> options)
        : base(options)
    {
    }

    /// <summary>Staff accounts.</summary>
    public virtual DbSet<PrUser> PrUsers { get; set; } = null!;

    /// <summary>Security groups.</summary>
    public virtual DbSet<PrGroup> PrGroups { get; set; } = null!;

    /// <summary>Group memberships, carrying the per-user CRUD flags.</summary>
    public virtual DbSet<PrUserGroup> PrUserGroups { get; set; } = null!;

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PrUser>(entity =>
        {
            entity.ToTable("PR_User");

            // smallint, no identity, no default and no trigger: the legacy application
            // supplied the key itself. ValueGeneratedNever stops EF Core from expecting
            // the database to produce one on insert.
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();

            // The legacy code passes @LoginName as NVarChar(50) against a 100-char column.
            // Sized to the column here so the parameter type cannot drift from the schema.
            entity.Property(e => e.LoginName).HasColumnName("LoginName").HasMaxLength(100);
            entity.Property(e => e.PlaintextPassword).HasColumnName("Password").HasMaxLength(300);
            entity.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(300);
            entity.Property(e => e.FullNameEn).HasColumnName("FullNameEn").HasMaxLength(300);
            entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(300);
            entity.Property(e => e.JobTitleName).HasColumnName("JobTitleName").HasMaxLength(300);
            entity.Property(e => e.AdressAr).HasColumnName("Adress_Ar").HasMaxLength(300);
            entity.Property(e => e.AdressEn).HasColumnName("Adress_En").HasMaxLength(300);
            entity.Property(e => e.TelHome).HasColumnName("TEL_HOME").HasMaxLength(100);
            entity.Property(e => e.TelMobil).HasColumnName("TEL_MOBIL").HasMaxLength(100);

            entity.Property(e => e.Active).HasColumnName("Active");
            entity.Property(e => e.EmpId).HasColumnName("EmpId");
            entity.Property(e => e.OutletId).HasColumnName("Outlet_ID");
            entity.Property(e => e.DomainLKDirectorateId).HasColumnName("DomainLK_DirectorateId");
            entity.Property(e => e.IsChangePassword).HasColumnName("IS_Change_Password");
            entity.Property(e => e.RegisterationDate).HasColumnName("RegisterationDate");
            entity.Property(e => e.LastLoginDate).HasColumnName("LastLoginDate");
        });

        modelBuilder.Entity<PrGroup>(entity =>
        {
            entity.ToTable("PR_Group");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();
            entity.Property(e => e.GroupName).HasColumnName("GroupName").HasMaxLength(300);
            entity.Property(e => e.GroupNameEn).HasColumnName("GroupName_En").HasMaxLength(150);
            entity.Property(e => e.Active).HasColumnName("Active");
            entity.Property(e => e.IsMinistry).HasColumnName("IsMinistry");
            entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
            entity.Property(e => e.LastModifiedDate).HasColumnName("LastModifiedDate");
            entity.Property(e => e.Note).HasColumnName("Note").HasMaxLength(300);
            entity.Property(e => e.PrApplicationId).HasColumnName("PR_ApplicationId");
            entity.Property(e => e.PrApplicationCategoryId).HasColumnName("PR_ApplicationCategoryId");
        });

        modelBuilder.Entity<PrUserGroup>(entity =>
        {
            entity.ToTable("PR_UserGroup");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();
            entity.Property(e => e.PrUserId).HasColumnName("PR_UserId");
            entity.Property(e => e.PrGroupId).HasColumnName("PR_GroupId");
            entity.Property(e => e.Active).HasColumnName("Active");
            entity.Property(e => e.CanView).HasColumnName("CanView");
            entity.Property(e => e.CanAdd).HasColumnName("CanAdd");
            entity.Property(e => e.CanEdit).HasColumnName("CanEdit");
            entity.Property(e => e.CanDelete).HasColumnName("CanDelete");
            entity.Property(e => e.CanPrint).HasColumnName("CanPrint");

            entity.HasOne(e => e.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(e => e.PrUserId)
                .HasConstraintName("FK_PR_UserGroup_PR_User");

            entity.HasOne(e => e.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(e => e.PrGroupId)
                .HasConstraintName("FK_PR_UserGroup_PR_Group");
        });
    }
}

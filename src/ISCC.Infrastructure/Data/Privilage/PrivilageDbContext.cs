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
/// <c>PrivilegeConnection</c> connection string. See <see cref="PrUser"/> for why the
/// remaining tables are not mapped.
/// </para>
/// <para>
/// The five navigation tables were added for the menu port. They are read-only: nothing in
/// this solution writes to them, and the menu is a projection of existing rows rather than a
/// new source of truth.
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

    /// <summary>Registered applications, reachable to filter groups by category.</summary>
    public virtual DbSet<PrApplication> PrApplications { get; set; } = null!;

    /// <summary>Functional modules: the middle level of the navigation tree.</summary>
    public virtual DbSet<PrModule> PrModules { get; set; } = null!;

    /// <summary>Menu leaves: the clickable entries at the bottom of the navigation tree.</summary>
    public virtual DbSet<PrMenu> PrMenus { get; set; } = null!;

    /// <summary>Which leaves belong to which module in which group, and in what order.</summary>
    public virtual DbSet<PrGroupModuleMenu> PrGroupModuleMenus { get; set; } = null!;

    /// <summary>Per-user permission rows. This is what filters the menu, not PrUserGroups.</summary>
    public virtual DbSet<PrGroupModuleMenuPrivilage> PrGroupModuleMenuPrivilages { get; set; } = null!;

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

        // The five navigation tables below. All read-only, mapped to the live schema exactly.

        modelBuilder.Entity<PrApplication>(entity =>
        {
            entity.ToTable("PR_Application");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();
            entity.Property(e => e.ApplicationName).HasColumnName("ApplicationName").HasMaxLength(300);
            entity.Property(e => e.ApplicationDescription).HasColumnName("ApplicationDescription").HasMaxLength(500);
            entity.Property(e => e.PrApplicationCategoryId).HasColumnName("PR_ApplicationCategoryId");
        });

        modelBuilder.Entity<PrModule>(entity =>
        {
            entity.ToTable("PR_Module");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();
            entity.Property(e => e.ModuleName).HasColumnName("ModuleName").HasMaxLength(300);

            // varchar, not nvarchar, in the live table. Unlike the other bilingual columns
            // this one cannot hold non-Latin text at all. Preserved rather than "fixed",
            // because widening it is a schema change to a database this port must not touch.
            entity.Property(e => e.ModuleNameEn).HasColumnName("ModuleName_En").HasMaxLength(150);

            entity.Property(e => e.ModuleDescription).HasColumnName("ModuleDescription").HasMaxLength(500);
            entity.Property(e => e.Active).HasColumnName("Active");
            entity.Property(e => e.PrApplicationId).HasColumnName("PR_ApplicationId");
            entity.Property(e => e.PrApplicationCategoryId).HasColumnName("PR_ApplicationCategoryId");

            entity.HasOne<PrApplication>()
                .WithMany()
                .HasForeignKey(e => e.PrApplicationId)
                .HasConstraintName("FK_PR_Module_PR_Application");
        });

        modelBuilder.Entity<PrMenu>(entity =>
        {
            entity.ToTable("PR_Menu");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();
            entity.Property(e => e.MenuTitle).HasColumnName("MenuTitle").HasMaxLength(300);
            entity.Property(e => e.MenuTitleEn).HasColumnName("MenuTitle_En").HasMaxLength(300);
            entity.Property(e => e.MenuUrl).HasColumnName("MenuURL").HasMaxLength(500);
            entity.Property(e => e.Active).HasColumnName("Active");
            entity.Property(e => e.PrMenuId).HasColumnName("PR_MenuId");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.PrModuleId).HasColumnName("PR_ModuleId");
            entity.Property(e => e.PrApplicationId).HasColumnName("PR_ApplicationId");
            entity.Property(e => e.PrApplicationCategoryId).HasColumnName("PR_ApplicationCategoryId");

            entity.HasOne<PrModule>()
                .WithMany()
                .HasForeignKey(e => e.PrModuleId)
                .HasConstraintName("FK_PR_Menu_PR_Module");
        });

        modelBuilder.Entity<PrGroupModuleMenu>(entity =>
        {
            entity.ToTable("PR_GroupModuleMenu");

            // Composite key, matching PK_PR_GroupModuleMenu. No surrogate Id column exists,
            // so there is nothing to mark ValueGeneratedNever on here.
            entity.HasKey(e => new { e.PrGroupId, e.PrModuleId, e.PrMenuId });

            // The table's own column names are PR_GroupId, PR_ModuleId and PR_MenuId — no
            // "Pr" prefix stripped and no rename. Without these three HasColumnName calls
            // EF uses the CLR property names (PrGroupId) verbatim and the generated SQL
            // fails with "Invalid column name 'PrGroupId'".
            entity.Property(e => e.PrGroupId).HasColumnName("PR_GroupId");
            entity.Property(e => e.PrModuleId).HasColumnName("PR_ModuleId");
            entity.Property(e => e.PrMenuId).HasColumnName("PR_MenuId");

            entity.Property(e => e.IsActive).HasColumnName("IS_Active");
            entity.Property(e => e.OrderBy).HasColumnName("Order_BY");
        });

        modelBuilder.Entity<PrGroupModuleMenuPrivilage>(entity =>
        {
            entity.ToTable("PR_GroupModuleMenuPrivilage");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id").ValueGeneratedNever();

            // Every key except Id is nullable, and one live row has all of them NULL. A
            // required property here would make that row fail to materialise rather than
            // simply not match, so nullability is kept as the schema has it.
            entity.Property(e => e.PrGroupId).HasColumnName("PR_GroupId");
            entity.Property(e => e.PrModuleId).HasColumnName("PR_ModuleId");
            entity.Property(e => e.PrMenuId).HasColumnName("PR_MenuId");
            entity.Property(e => e.PrUserId).HasColumnName("PR_User_id");

            entity.Property(e => e.CanView).HasColumnName("CanView");
            entity.Property(e => e.CanAdd).HasColumnName("CanAdd");
            entity.Property(e => e.CanEdit).HasColumnName("CanEdit");
            entity.Property(e => e.CanDelete).HasColumnName("CanDelete");
            entity.Property(e => e.CanPrint).HasColumnName("CanPrint");
            entity.Property(e => e.IsActive).HasColumnName("IS_Active");
        });
    }
}

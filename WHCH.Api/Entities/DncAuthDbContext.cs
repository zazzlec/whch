/******************************************
 * AUTHOR:          Rector
 * CREATEDON:       2018-09-26
 * OFFICIAL_SITE:    码友网(https://codedefault.com)--专注.NET/.NET Core
 * 版权所有，请勿删除
 ******************************************/

using WHCH.Api.Entities.QueryModels.DncPermission;
using Microsoft.EntityFrameworkCore;
using WHCH.Api.Utils;

namespace WHCH.Api.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class WHCHDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public WHCHDbContext(DbContextOptions<WHCHDbContext> options) : base(options)
        {

        }
 
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<DncUser> DncUser { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<DncRole> DncRole { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<DncMenu> DncMenu { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public DbSet<DncIcon> DncIcon { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public DbSet<DncMessage> DncMessage { get; set; }
        /// <summary>
        /// 用户-角色多对多映射
        /// </summary>
        public DbSet<DncUserRoleMapping> DncUserRoleMapping { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public DbSet<DncPermission> DncPermission { get; set; }
        /// <summary>
        /// 角色-权限多对多映射
        /// </summary>
        public DbSet<DncRolePermissionMapping> DncRolePermissionMapping { get; set; }


        /// <summary>
        /// DncLog
        /// </summary>
        public DbSet<DncLog> DncLog { get; set; }

        /// <summary>
        /// dncboiler
        /// </summary>
        public DbSet<Dncboiler> Dncboiler { get; set; }
        /// <summary>
        /// dnccharea
        /// </summary>
        public DbSet<Dnccharea> Dnccharea { get; set; }
        /// <summary>
        /// dncchareahis
        /// </summary>
        public DbSet<Dncchareahis> Dncchareahis { get; set; }
        /// <summary>
        /// dncchlist
        /// </summary>
        public DbSet<Dncchlist> Dncchlist { get; set; }
        /// <summary>
        /// dncchqpoint
        /// </summary>
        public DbSet<Dncchqpoint> Dncchqpoint { get; set; }
        /// <summary>
        /// dncfuelpara
        /// </summary>
        public DbSet<Dncfuelpara> Dncfuelpara { get; set; }
        /// <summary>
        /// dnchzpoint
        /// </summary>
        public DbSet<Dnchzpoint> Dnchzpoint { get; set; }
        /// <summary>
        /// dnchzpointnow
        /// </summary>
        public DbSet<Dnchzpointnow> Dnchzpointnow { get; set; }

        /// <summary>
        /// dncparameter
        /// </summary>
        public DbSet<Dncparameter> Dncparameter { get; set; }
        /// <summary>
        /// dncpointkks
        /// </summary>
        public DbSet<Dncpointkks> Dncpointkks { get; set; }
        /// <summary>
        /// dnctype
        /// </summary>
        public DbSet<Dnctype> Dnctype { get; set; }
        public DbSet<Dncchrunlist_kyq> Dncchrunlist_kyq { get; set; }
        public DbSet<Dncclasses> Dncclasses { get; set; }
        public DbSet<Dnchfburn> Dnchfburn { get; set; }
        public DbSet<Dnclzburn> Dnclzburn { get; set; }

        #region DbQuery


        public DbQuery<DncPermissionWithAssignProperty> DncPermissionWithAssignProperty { get; set; }
        public DbQuery<DncPermissionWithMenu> DncPermissionWithMenu { get; set; }
        public DbQuery<DncPermissionWithAssignPropertyMysql> DncPermissionWithAssignPropertyMysql { get; set; }
        public DbQuery<DncPermissionWithMenuMysql> DncPermissionWithMenuMysql { get; set; }


        #endregion

        #region menu汇总
       // public DbQuery<DncPermissionWithMenuMysql> DncPermissionWithMenuMysql { get; set; }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //builder.Property(ci => ci.ID).IsRequired().HasMaxLength(36).HasColumnType("char(36)");

            if (ToolService.DbType.Equals("mysql"))
            {
                modelBuilder.Entity<DncUser>(entity =>
                {
                    entity.Property(x => x.Guid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.CreatedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.ModifiedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                });

                modelBuilder.Entity<DncIcon>(entity =>
                {
                    entity.Property(x => x.ModifiedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.CreatedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                });

                modelBuilder.Entity<DncMenu>(entity =>
                {
                    entity.Property(x => x.Guid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.ParentGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.CreatedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.ModifiedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                });

                modelBuilder.Entity<DncPermission>(entity =>
                {
                    entity.HasIndex(x => x.Code)
                        .IsUnique();

                    entity.HasOne(x => x.Menu)
                        .WithMany(x => x.Permissions)
                        .HasForeignKey(x => x.MenuGuid);

                    entity.Property(x => x.MenuGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.CreatedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.ModifiedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");

                });

                modelBuilder.Entity<DncRole>(entity =>
                {
                    entity.HasIndex(x => x.Code).IsUnique();
                    entity.Property(x => x.CreatedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.ModifiedByUserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");
                    entity.Property(x => x.IsSuperAdministrator).IsRequired().HasColumnType("bit");
                    entity.Property(x => x.IsBuiltin).IsRequired().HasColumnType("bit");
                });

                modelBuilder.Entity<DncUserRoleMapping>(entity =>
                {
                    entity.Property(x => x.UserGuid).IsRequired().HasMaxLength(36).HasColumnType("char(36)");


                    entity.HasKey(x => new
                    {
                        x.UserGuid,
                        x.RoleCode
                    });

                    entity.HasOne(x => x.DncUser)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.UserGuid)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(x => x.DncRole)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.RoleCode)
                        .OnDelete(DeleteBehavior.Restrict);
                });
            }
            else
            {
                modelBuilder.Entity<DncPermission>(entity =>
                {
                    entity.HasIndex(x => x.Code)
                        .IsUnique();

                    entity.HasOne(x => x.Menu)
                        .WithMany(x => x.Permissions)
                        .HasForeignKey(x => x.MenuGuid);
                });

                modelBuilder.Entity<DncRole>(entity =>
                {
                    entity.HasIndex(x => x.Code).IsUnique();
                });

                modelBuilder.Entity<DncUserRoleMapping>(entity =>
                {
                    entity.HasKey(x => new
                    {
                        x.UserGuid,
                        x.RoleCode
                    });

                    entity.HasOne(x => x.DncUser)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.UserGuid)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(x => x.DncRole)
                        .WithMany(x => x.UserRoles)
                        .HasForeignKey(x => x.RoleCode)
                        .OnDelete(DeleteBehavior.Restrict);
                });
            }


            modelBuilder.Entity<DncRolePermissionMapping>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.RoleCode,
                    x.PermissionCode
                });

                entity.HasOne(x => x.DncRole)
                    .WithMany(x => x.Permissions)
                    .HasForeignKey(x => x.RoleCode)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DncPermission)
                    .WithMany(x => x.Roles)
                    .HasForeignKey(x => x.PermissionCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

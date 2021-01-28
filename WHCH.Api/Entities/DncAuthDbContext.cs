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
        /// dncerror_parameter
        /// </summary>
        public DbSet<Dncerror_parameter> Dncerror_parameter { get; set; }
        /// <summary>
        /// dncfireerror_advice
        /// </summary>
        public DbSet<Dncfireerror_advice> Dncfireerror_advice { get; set; }
        /// <summary>
        /// dncfireerror_mid
        /// </summary>
        public DbSet<Dncfireerror_mid> Dncfireerror_mid { get; set; }
        /// <summary>
        /// dnchzpoint_type
        /// </summary>
        public DbSet<Dnchzpoint_type> Dnchzpoint_type { get; set; }
        /// <summary>
        /// dnchztemp_mid
        /// </summary>
        public DbSet<Dnchztemp_mid> Dnchztemp_mid { get; set; }
        /// <summary>
        /// dnchztemp_point
        /// </summary>
        public DbSet<Dnchztemp_point> Dnchztemp_point { get; set; }
        /// <summary>
        /// dnchztemp_real
        /// </summary>
        public DbSet<Dnchztemp_real> Dnchztemp_real { get; set; }
        /// <summary>
        /// dnco2nox_point
        /// </summary>
        public DbSet<Dnco2nox_point> Dnco2nox_point { get; set; }
        /// <summary>
        /// dncsrm_parameter
        /// </summary>
        public DbSet<Dncsrm_parameter> Dncsrm_parameter { get; set; }
        /// <summary>
        /// dnctype
        /// </summary>
        public DbSet<Dnctype> Dnctype { get; set; }

        public DbSet<Dncerror_status> Dncerror_status { get; set; }

        public DbSet<Dncexpand3d> Dncexpand3d { get; set; }
        public DbSet<Dncexpand3d_base> Dncexpand3d_base { get; set; }
        public DbSet<Dncexpandgroup> Dncexpandgroup { get; set; }

        public DbSet<Dncscrpoint> Dncscrpoint { get; set; }
        public DbSet<Dncscrpointdata> Dncscrpointdata { get; set; }

        public DbSet<Dncboilerstatus> Dncboilerstatus { get; set; }
        public DbSet<Dncgwfspoint> Dncgwfspoint { get; set; }
        public DbSet<Dncgwfspointdata> Dncgwfspointdata { get; set; }
        public DbSet<Dncgwfspointreset> Dncgwfspointreset { get; set; }
        public DbSet<Dncgwfs_parameter> Dncgwfs_parameter { get; set; }
        public DbSet<Dncwind> Dncwind { get; set; }
        public DbSet<Dncwindbase> Dncwindbase { get; set; }
        public DbSet<Dncwinddata> Dncwinddata { get; set; }
        public DbSet<Dncwindgroup> Dncwindgroup { get; set; }


        public DbSet<Dnckyqresultdata> Dnckyqresultdata { get; set; }
        public DbSet<Dnckyqresult_fastdata> Dnckyqresult_fastdata { get; set; }
        /// <summary>
        /// dnckyqconfig
        /// </summary>
        public DbSet<Dnckyqconfig> Dnckyqconfig { get; set; }
        /// <summary>
        /// dnckyqpoint
        /// </summary>
        public DbSet<Dnckyqpoint> Dnckyqpoint { get; set; }
        public DbSet<Dnckyqpointdata> Dnckyqpointdata { get; set; }
        /// <summary>
        /// dnckyqresult
        /// </summary>
        public DbSet<Dnckyqresult> Dnckyqresult { get; set; }
        /// <summary>
        /// dnckyqresult_fast
        /// </summary>
        public DbSet<Dnckyqresult_fast> Dnckyqresult_fast { get; set; }
        /// <summary>
        /// dnckyqtype
        /// </summary>
        public DbSet<Dnckyqtype> Dnckyqtype { get; set; }
        public DbSet<Dnckyq> Dnckyq { get; set; }
        /// <summary>
        /// dnccharea
        /// </summary>
        public DbSet<Dnccharea> Dnccharea { get; set; }
        public DbSet<Dnckyqmade> Dnckyqmade { get; set; }
        
        /// <summary>
        /// dncchhzpoint
        /// </summary>
        public DbSet<Dncchhzpoint> Dncchhzpoint { get; set; }
        /// <summary>
        /// dncchhztype
        /// </summary>
        public DbSet<Dncchhztype> Dncchhztype { get; set; }
        /// <summary>
        /// dncchlist
        /// </summary>
        public DbSet<Dncchlist> Dncchlist { get; set; }

        /// <summary>
        /// dncchqpoint
        /// </summary>
        public DbSet<Dncchqpoint> Dncchqpoint { get; set; }
        /// <summary>
        /// dncchqpointdata
        /// </summary>
        public DbSet<Dncchqpointdata> Dncchqpointdata { get; set; }
        /// <summary>
        /// dncchrunlist
        /// </summary>
        public DbSet<Dncchrunlist> Dncchrunlist { get; set; }
        /// <summary>
        /// dncchstatus
        /// </summary>
        public DbSet<Dncchstatus> Dncchstatus { get; set; }
        /// <summary>
        /// dncchtype
        /// </summary>
        public DbSet<Dncchtype> Dncchtype { get; set; }

        /// <summary>
        /// dncch_parameter
        /// </summary>
        public DbSet<Dncch_parameter> Dncch_parameter { get; set; }
        /// <summary>
        /// dncfhdata
        /// </summary>
        public DbSet<Dncfhdata> Dncfhdata { get; set; }


        public DbSet<Dncchpoint_wrl> Dncchpoint_wrl { get; set; }
        public DbSet<Dncchrunlist_kyq> Dncchrunlist_kyq { get; set; }

        public DbSet<Dnccharea_his> Dnccharea_his { get; set; }

        public DbSet<Dncchqkks> Dncchqkks { get; set; }
        
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



namespace prjFin052701.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Common;//新增
    using System.Data.Entity.Core.EntityClient;//新增
    using System.Configuration;//新增

    public partial class dbBookEntities : DbContext
    {
        public dbBookEntities()
            : base("name=dbBookEntities")
        {
            //以下均為新增
            var originalConnectionString = ConfigurationManager.ConnectionStrings["dbBookEntities"].ConnectionString;//修改Entities名稱
            var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
            var providerBuilder = factory.CreateConnectionStringBuilder();

            providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;

            providerBuilder.Add("Password", "yzuim1102netdbB"); // 加入SQL密碼資料

            entityBuilder.ProviderConnectionString = providerBuilder.ToString();

            this.Database.Connection.ConnectionString = entityBuilder.ProviderConnectionString;

        
    }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TableBooks1091711> TableBooks1091711 { get; set; }
        public virtual DbSet<TableClasss1091711> TableClasss1091711 { get; set; }
    }
}

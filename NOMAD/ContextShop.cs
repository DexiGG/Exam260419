namespace NOMAD
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextShop : DbContext
    {
        // Контекст настроен для использования строки подключения "ContextShop" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "NOMAD.ContextShop" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ContextShop" 
        // в файле конфигурации приложения.
        public ContextShop()
            : base("name=ContextShop")
        {
        }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Company> Companies{ get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
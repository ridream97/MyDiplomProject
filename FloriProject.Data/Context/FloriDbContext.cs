namespace FloriProject.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FloriDbContext : DbContext
    {
        // Контекст настроен для использования строки подключения "FloriDbContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "FloriProject.Data.Context.FloriDbContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "FloriDbContext" 
        // в файле конфигурации приложения.
        public FloriDbContext()
            : base("name=FloriDbContext")
        {
        }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
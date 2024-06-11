using Microsoft.EntityFrameworkCore;

namespace Project__Otdel_Cadrov
{
    internal class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=employee.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.PersonId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    PersonId = 1,
                    Name = "Илья",
                    Department = "Отдел кадров",
                    Institute = "Институт кадров М. Громова",
                    Birth = 2006,
                    Place = "Старый Оскол",
                    Address = "Пушкина",
                    Phone = 973256789,
                    Education = "Высшее",
                    Year = 2019,
                    Passport = 216612474,
                    Post = "Менеджер"
                },
                new Employee
                {
                    PersonId = 2,
                    Name = "Виталя",
                    Department = "Отдел кадров",
                    Institute = "Институт кадров Ж. Жучкова",
                    Birth = 2005,
                    Place = "Москва",
                    Address = "Кабанья",
                    Phone = 787256582,
                    Education = "Высшее",
                    Year = 2017,
                    Passport = 623467321,
                    Post = "Ассистент"
                },
                new Employee
                {
                    PersonId = 3,
                    Name = "Николай",
                    Department = "Отдел кадров",
                    Institute = "Институт кадров Е. Махачкалов",
                    Birth = 1995,
                    Place = "Ленинград",
                    Address = "Ленина",
                    Phone = 975614329,
                    Education = "Высшее",
                    Year = 2012,
                    Passport = 615907423,
                    Post = "Инспектор"
                }
            );
        }
    }
}

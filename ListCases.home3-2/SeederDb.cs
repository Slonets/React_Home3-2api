using DateAccess.Data;
using DateAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ListCases.home3_2
{
    public static class SeederDb
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var service = scope.ServiceProvider;

                var context = service.GetRequiredService<CaseDbContext>();

                context.Database.Migrate();

                if (!context.Task.Any())
                {
                    Case[] caseArray = new Case[]
                    {
                        new Case
                        {
                            Id=1,
                            Name="Зарядка зранку",
                            Description="Встати о 6 годині ранку, щоб встигнути попідтягуватися на турніку й покачати прес перед роботою"
                        },
                        new Case
                        {
                            Id=2,
                            Name="Приготувати їжу",
                            Description="Зайнятися готуванням їжі"
                        },

                        new Case
                        {
                            Id=3,
                            Name="Купити книгу по С#",
                            Description="Зайти у книгарню 'Є' та подивитися книги з програмування"
                        },
                        new Case
                        {
                            Id=4,
                            Name="Виконати домашню",
                            Description="Прийти раніше з роботи, щоб мати змогу виконати завдання, які задав викладач"
                        }
                    };

                    context.Task.AddRange(caseArray);
                    context.SaveChanges();
                }

            }
        }
    }
}

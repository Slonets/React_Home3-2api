using DateAccess.Date;
using DateAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Task.home3
{
    public static class SeederDb
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var service = scope.ServiceProvider;

                var context = service.GetRequiredService<TaskDbContext>();

                context.Database.Migrate();

                if (!context.Tasks.Any())
                {
                    TaskEntity[] taskArray = new TaskEntity[]
                    {
                         new TaskEntity
    {
        
        Name="Зарядка зранку",
        Description="Встати о 6 годині ранку, щоб встигнути попідтягуватися на турніку й покачати прес перед роботою"
    },
    new  TaskEntity
    {
        
        Name="Приготувати їжу",
        Description="Зайнятися готуванням їжі"
    },

    new TaskEntity
    {
        
        Name="Купити книгу по С#",
        Description="Зайти у книгарню 'Є' та подивитися книги з програмування"
    },
    new TaskEntity
    {
        
        Name="Виконати домашню",
        Description="Прийти раніше з роботи, щоб мати змогу виконати завдання, які задав викладач"
    }
                    };


                    context.Tasks.AddRange(taskArray);
                    context.SaveChanges();
                }

            }
        }
    }
}

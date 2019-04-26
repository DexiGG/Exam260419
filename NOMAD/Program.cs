using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMAD
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ContextShop())
            {
                //Добавление журнала
                Console.WriteLine("Сколько журналов добавить");
                int countShop = int.Parse(Console.ReadLine());
                for (int i = 0; i < countShop; i++)
                {
                    Console.WriteLine("Введите номер журнала");
                    int jNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите название журнала");
                    string jName = Console.ReadLine();

                    Console.WriteLine("Введите сумму подписки на журнал");
                    int jMoney = int.Parse(Console.ReadLine());

                    var shop = new Shop
                    {
                        JournalNumber = jNumber,
                        JournalName = jName,
                        JournalMoney = jMoney
                    };
                    context.Shops.Add(shop);
                    context.SaveChanges();

                }

                //Добавление пользователя
                Console.WriteLine("Сколько пользователей добавить?");
                int countUsers = int.Parse(Console.ReadLine());
                for(int i=0;i<countUsers;i++)
                {
                    Console.WriteLine("Введите email пользователя");
                    string emailUsers = Console.ReadLine();

                    Console.WriteLine("На сколько месяцев хотите оформить подписку (12,24,36)");
                    int month =int.Parse(Console.ReadLine());

                    Console.WriteLine("Есть ли подписка (no=0/ yes=1)");
                    int subscribe = int.Parse(Console.ReadLine());

                    if (subscribe == 0)
                    {
                        var users = new User
                        {
                            Email = emailUsers,
                            DateSubscribe = month,
                            IfSubscribe = subscribe,
                        };
                        context.Users.Add(users);
                        context.SaveChanges();
                    }

                    else if (subscribe == 1)
                    {

                        Console.WriteLine("Выберите номер журана на который хотите подписаться");

                        for (int j = 0; j < context.Shops.Count(); j++)
                        {
                            Console.WriteLine(context.Shops.ToList()[j].JournalNumber);
                        }
                        int numberShop = int.Parse(Console.ReadLine());
                        var getIdShop = (from shop in context.Shops where shop.JournalNumber == numberShop select shop.Id).FirstOrDefault();
                        var getMoneyShop = (from shop in context.Shops where shop.JournalNumber == numberShop select shop.JournalMoney).FirstOrDefault();

                        Console.WriteLine("Введите дату подписки, год-месяц-день");
                        int year  =int.Parse(Console.ReadLine());
                        int months =int.Parse(Console.ReadLine());
                        int day =int.Parse(Console.ReadLine());
                 
                        var user = new User
                        {
                            Email = emailUsers,
                            DateSubscribe = month,
                            IfSubscribe = subscribe,
                            MoneySubcription = getMoneyShop * month,
                            ShopId = getIdShop,
                            DeadLine = new DateTime(year, months, day),
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }

                var getUserId = from user in context.Users select user;

                foreach (User users in getUserId)
                {
                    var getShopId = (from shop in context.Shops where users.ShopId== shop.Id select shop.Id).FirstOrDefault();
                
                    var getReportMoney = (from user in context.Users select user.MoneySubcription).FirstOrDefault();

                    var getCountSubscribe = (from user in context.Users where users.IfSubscribe==1 & getShopId == users.ShopId select context.Users.Count()).FirstOrDefault();

                    TimeSpan DifferenceDate = DateTime.Now - users.DeadLine;
                    var company = new Company
                    {
                        UserId = users.Id,
                        ShopId = getShopId,
                        ReportMoney = getReportMoney,
                        ReportSubscibe = getCountSubscribe,
                        EndSubscribe = DifferenceDate.TotalDays / 30
                        };
                    context.Companies.Add(company);
                }
                context.SaveChanges();
            }
        }
    }
}


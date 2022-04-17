using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreYx.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bogus;

namespace StoreYx.Models
{
    public static class SeedData
    {

        private static List<Message> FakeMessages(int count)
        {
            
            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName)
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.CreatedAt, f => f.Date.Past());
            return messageFaker.Generate(count);

        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())){

                if (!context.Message.Any())
                    context.Message.AddRange(FakeMessages(100));

                
                context.SaveChanges();
            }
        }
    }
}
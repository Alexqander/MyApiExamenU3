using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace MyApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
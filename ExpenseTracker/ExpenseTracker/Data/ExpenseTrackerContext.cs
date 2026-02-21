using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerContext : IdentityDbContext
    {
        public ExpenseTrackerContext (DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseTracker.Models.Transaction> Transaction { get; set; } = default!;
    }
}

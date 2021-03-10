using Microsoft.EntityFrameworkCore;
using ProcessPaymentDataLayer.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessPaymentDataLayer.Contexts
{
    public class ProcessPaymentContext: DbContext
    {
        public DbSet<PaymentDo> Payment { get; set; }

        public DbSet<RequestStatusDo> RequestStatus { get; set; }

        public static string connectiongString = "Server=(localDB)\\mssqllocaldb;Database=PaymentProcessDB;Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= .; Initial Catalog=PaymentProcessDB; Integrated Security=true ");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NorthwestLabs.Models;
using System.Data.Entity;

namespace NorthwestLabs.DAL
{
    public class NWLMasterContext : DbContext
    {
        public NWLMasterContext() : base("NWLMasterContext")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
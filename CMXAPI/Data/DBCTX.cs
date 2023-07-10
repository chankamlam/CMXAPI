using System;
using CMXAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CMXAPI.Data
{
	public class DBCTX : DbContext
    {
		public DBCTX(DbContextOptions<DBCTX> opt) :base(opt)
		{
		}

		public DbSet<Document> Documents { get; set; }
	}
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top10Words.DAL.Entities;

namespace Top10Words.DAL.EFCore
{
    public interface ITop10WordsContext
    {
        DbSet<Book> Books { get; set; }
        // ....
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

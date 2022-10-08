using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace Exercise_LeHongAnh.Pages.CandidateProfiles
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public IndexModel(DataAccess.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; }

        public async Task OnGetAsync()
        {
            CandidateProfile = await _context.CandidateProfiles
                .Include(c => c.Posting).ToListAsync();
        }
    }
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static async Task<PaginatedList<T>> CreateAsync
            (IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}

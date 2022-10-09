using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Exercise_LeHongAnh.Pages.Hraccounts
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public IndexModel(DataAccess.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        public IList<Hraccount> Hraccount { get;set; }

        public async Task OnGetAsync()
        {
            Hraccount = await _context.Hraccounts.ToListAsync();
        }
    }
}

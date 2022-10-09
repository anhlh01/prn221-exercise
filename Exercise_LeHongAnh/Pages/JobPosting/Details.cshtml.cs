using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Exercise_LeHongAnh.Pages.JobPosting
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public DetailsModel(DataAccess.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        public DataAccess.Models.JobPosting JobPosting { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobPosting = await _context.JobPostings.FirstOrDefaultAsync(m => m.PostingId == id);

            if (JobPosting == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public DeleteModel(DataAccess.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobPosting = await _context.JobPostings.FindAsync(id);

            if (JobPosting != null)
            {
                _context.JobPostings.Remove(JobPosting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

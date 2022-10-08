using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Exercise_LeHongAnh.Pages.JobPosting
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public EditModel(DataAccess.Models.CandidateManagementContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JobPosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(JobPosting.PostingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobPostingExists(string id)
        {
            return _context.JobPostings.Any(e => e.PostingId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Exercise_LeHongAnh.Pages.CandidateProfiles
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public DetailsModel(DataAccess.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        public CandidateProfile CandidateProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CandidateProfile = await _context.CandidateProfiles
                .Include(c => c.Posting).FirstOrDefaultAsync(m => m.CandidateId == id);

            if (CandidateProfile == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

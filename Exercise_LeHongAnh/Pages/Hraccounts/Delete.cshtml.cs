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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.Models.CandidateManagementContext _context;

        public DeleteModel(DataAccess.Models.CandidateManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hraccount Hraccount { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hraccount = await _context.Hraccounts.FirstOrDefaultAsync(m => m.Email == id);

            if (Hraccount == null)
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

            Hraccount = await _context.Hraccounts.FindAsync(id);

            if (Hraccount != null)
            {
                _context.Hraccounts.Remove(Hraccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

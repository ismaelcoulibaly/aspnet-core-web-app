using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bibliotheque.Data;
using Bibliotheque.Models;

namespace Bibliotheque.Pages.Livres
{
    public class DetailsModel : PageModel
    {
        private readonly Bibliotheque.Data.BibliothequeContext _context;

        public DetailsModel(Bibliotheque.Data.BibliothequeContext context)
        {
            _context = context;
        }

        public Livre Livre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livre = await _context.Livre.FirstOrDefaultAsync(m => m.idLivre == id);

            if (Livre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

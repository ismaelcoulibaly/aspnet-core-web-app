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
    public class IndexModel : PageModel
    {
        private readonly Bibliotheque.Data.BibliothequeContext _context;

        public IndexModel(Bibliotheque.Data.BibliothequeContext context)
        {
            _context = context;
        }

        public IList<Livre> Livre { get;set; }

        public async Task OnGetAsync()
        {
            Livre = await _context.Livre.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotheque.Models;
using Bibliotheque.Pages.Livres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bibliotheque.Pages
{
    public class IndexModelLivre : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Bibliotheque.Data.BibliothequeContext _context;

        public IndexModelLivre(ILogger<IndexModel> logger, Bibliotheque.Data.BibliothequeContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IList<Livre> Livre { get; set; }
        public async Task OnGetAsync()
        {
            Livre = await _context.Livre.ToListAsync();
        }
    }
}

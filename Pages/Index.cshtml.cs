using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotheque.Models;
using Bibliotheque.Pages.Livres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // besion using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string LivreCategories { get; set; }
        public async Task OnGetAsync()
        {
            //Recipe = await _context.Recipe.ToListAsync();






            // Use LINQ to get list of Categories.
            IQueryable<string> categQuery = from m in _context.Livre
                                            orderby m.Categorie.ToString()
                                            select m.Categorie.ToString();

            var livres = from m in _context.Livre
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                livres = livres.Where(s => s.nomLivre.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(LivreCategories))
            {

                livres = livres.Where(s => s.Categorie.ToString() == LivreCategories);
            }


            //Categories = new SelectList(await categQuery.Distinct().ToListAsync());

            Livre = await livres.ToListAsync();
        }
    }
}

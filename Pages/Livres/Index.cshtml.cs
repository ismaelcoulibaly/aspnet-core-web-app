using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bibliotheque.Data;
using Bibliotheque.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
       
        [BindProperty(SupportsGet = true)]
        public string SearchStringTitre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchStringAuteur { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchStringISBN { get; set; }

        // besion using Microsoft.AspNetCore.Mvc.Rendering;
        public string LivreCategories { get; set; }
        public string LivreAuteurs { get;  set; }
        public string LivreISBN { get; set; }


        public async Task OnGetAsync()
        {
            // Livre = await _context.Livre.ToListAsync();


            // Use LINQ to get list of Categories.
            IQueryable<string> categQuery = from m in _context.Livre
                                            orderby m.Categorie.ToString()
                                            select m.Categorie.ToString();

            var livres = from m in _context.Livre
                          select m;

            if (!string.IsNullOrEmpty(SearchStringTitre))
            {
                livres = livres.Where(s => s.nomLivre.Contains(SearchStringTitre));
            }
            if (!string.IsNullOrEmpty(SearchStringAuteur))
            {
                livres = livres.Where(s => s.auteur.Contains(SearchStringAuteur));
            }

            if (!string.IsNullOrEmpty(SearchStringISBN))
            {
                livres = livres.Where(s => s.isbn.Contains(SearchStringISBN));
            }

            //Categories = new SelectList(await categQuery.Distinct().ToListAsync());

            Livre = await livres.ToListAsync();
        }
    }
    
}

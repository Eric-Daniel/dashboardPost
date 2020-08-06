using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages.PostList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Dashboard Dashboard { get; set; }

        public async Task OnGet(int id)
        {
            Dashboard = await _db.Dashboard.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var PostFromDb = await _db.Dashboard.FindAsync(Dashboard.Id);
                PostFromDb.Title = Dashboard.Title;
                PostFromDb.Description = Dashboard.Description;
                PostFromDb.Time = Dashboard.Time;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
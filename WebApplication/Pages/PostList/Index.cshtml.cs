using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Migrations;
using WebApplication.Model;

namespace WebApplication.Pages.PostList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Dashboard> DashboardPosts { get; set; }
        public async Task OnGet()
        {
            DashboardPosts = await _db.Dashboard.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var dashboardPost = await _db.Dashboard.FindAsync(id);
            if (dashboardPost==null)
            {
                return NotFound();
            }
            _db.Dashboard.Remove(dashboardPost);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
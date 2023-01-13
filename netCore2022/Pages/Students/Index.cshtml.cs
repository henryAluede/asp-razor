using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using netCore2022.Data;
using netCore2022.Models;

namespace netCore2022.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly netCore2022.Data.SchoolContext _context;

        public IndexModel(netCore2022.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}

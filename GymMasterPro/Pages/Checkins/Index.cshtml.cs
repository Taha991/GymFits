﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GymMasterPro.Data;
using GymMasterPro.Model;

namespace GymMasterPro.Pages.Checkins
{
    public class IndexModel : PageModel
    {
        private readonly GymMasterPro.Data.ApplicationDbContext _context;

        public IndexModel(GymMasterPro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Checkin> Checkin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Checkins != null)
            {
                Checkin = await _context.Checkins
                .Include(c => c.Member)
                .ThenInclude(c=>c.Memberships).
                ToListAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GSS.Database;
using eUniverzitet.Web.Helper;
using GSS.Web.Helper;
using GSS.Web.Viewmodels;

namespace GSS.Web.Controllers
{
    [Authorization(superuser: true, organizacija: true)]
    public class ManagersController : Controller
    {
        private readonly GSSContext _context;

        public ManagersController(GSSContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Index(int Id)
        {
            var user = HttpContext.GetLogiraniKorisnik<LoggedInUser>();
            if (user.Role == typeof(User) && Id != user.Id)
            {
                return RedirectToAction("Index", new { Id = user.Id });
            }

            var managers = _context.Managers.Where(x => x.UserId == Id);

            var organization = await _context.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (organization == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = Id;
            ViewData["OrganizationName"] = organization.OrganizationName;
            return View(await managers.ToListAsync());
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // GET: Managers/Create
        public IActionResult Create(int Id)
        {
            var manager = new Manager { UserId = Id };
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "OrganizationName", manager);
            ViewData["Gender"] = Enum.GetValues(typeof(Gender)).OfType<Gender>().Select(m => new { Text = m.ToString(), Value = (int)m }).ToList();
            return View(manager);
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,UserId,EmailAddress,Phone,Gender,BirthDate")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                manager.Active = true;
                _context.Add(manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { Id = manager.UserId });
            }
            return View(manager);
        }

        // GET: Managers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "OrganizationName", manager);
            ViewData["Gender"] = Enum.GetValues(typeof(Gender)).OfType<Gender>().Select(m => new { Text = m.ToString(), Value = (int)m }).ToList();
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId,Active,EmailAddress,Phone,Gender,BirthDate")] Manager manager)
        {
            if (id != manager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerExists(manager.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { Id = manager.UserId });
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "OrganizationName", manager.UserId);
            return View(manager);
        }

        // GET: Managers/Deactivate/5
        public async Task<IActionResult> Deactivate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            manager.Active = false;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new { Id = manager.UserId });
        }
        // GET: Managers/Activate/5
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Managers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            manager.Active = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { Id = manager.UserId });
        }

        private bool ManagerExists(int id)
        {
            return _context.Managers.Any(e => e.Id == id);
        }
    }
}

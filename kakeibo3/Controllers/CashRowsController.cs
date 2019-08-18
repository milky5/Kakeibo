using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kakeibo3.Models;

namespace kakeibo3.Controllers
{
    public class CashRowsController : Controller
    {
        private readonly kakeibo3Context _context;

        public CashRowsController(kakeibo3Context context)
        {
            _context = context;
        }

        // GET: CashRows
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.CashRow.ToListAsync());
        //}

        // GET: CashRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashRow = await _context.CashRow
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cashRow == null)
            {
                return NotFound();
            }

            return View(cashRow);
        }

        // GET: CashRows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PayDate,PayItem,Price,Payer,Payment,CostType,StartDate,EndDate,ForMonth")] CashRow cashRow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashRow);
        }

        // GET: CashRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashRow = await _context.CashRow.FindAsync(id);
            if (cashRow == null)
            {
                return NotFound();
            }
            return View(cashRow);
        }

        // POST: CashRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PayDate,PayItem,Price,Payer,Payment,CostType,StartDate,EndDate,ForMonth")] CashRow cashRow)
        {
            if (id != cashRow.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashRowExists(cashRow.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cashRow);
        }

        // GET: CashRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashRow = await _context.CashRow
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cashRow == null)
            {
                return NotFound();
            }

            return View(cashRow);
        }

        // POST: CashRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashRow = await _context.CashRow.FindAsync(id);
            _context.CashRow.Remove(cashRow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashRowExists(int id)
        {
            return _context.CashRow.Any(e => e.ID == id);
        }








        public async Task<IActionResult> Index()
        {
            var cashrows = from c in _context.CashRow select c;
            cashrows = cashrows.Where(c => c.PayDate.Year == DateTime.Now.Year && c.PayDate.Month == DateTime.Now.Month);
            cashrows = cashrows.OrderBy(m => m.PayDate);
            ViewBag.Date = DateTime.Now;
            ViewBag.DateStr = $"{DateTime.Now.Year}年{DateTime.Now.Month}月";

            return View(await cashrows.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime date,int add)
        {
            date = date.AddMonths(add);
            var cashrows = from c in _context.CashRow select c;
            cashrows = cashrows.Where(c => c.PayDate.Year == date.Year && c.PayDate.Month == date.Month);
            cashrows = cashrows.OrderBy(m => m.PayDate);
            ViewBag.Date = date;
            ViewBag.DateStr = $"{date.Year}年{date.Month}月";

            return View(await cashrows.ToListAsync());
        }




        public async Task<IActionResult> Calculate()
        {
            var cashrows = from c in _context.CashRow select c;
            cashrows = cashrows.Where(c => c.PayDate.Year == DateTime.Now.Year && c.PayDate.Month == DateTime.Now.Month);
            cashrows = cashrows.OrderBy(m => m.PayDate);
            ViewBag.Date = DateTime.Now;
            ViewBag.DateStr = $"{DateTime.Now.Year}年{DateTime.Now.Month}月";

            return View(await cashrows.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(DateTime date,int add)
        {
            date = date.AddMonths(add);
            var cashrows = from c in _context.CashRow select c;
            cashrows = cashrows.Where(c => c.PayDate.Year == date.Year && c.PayDate.Month == date.Month);
            cashrows = cashrows.OrderBy(m => m.PayDate);
            ViewBag.Date = date;
            ViewBag.DateStr = $"{date.Year}年{date.Month}月";

            return View(await cashrows.ToListAsync());
        }


    }
}

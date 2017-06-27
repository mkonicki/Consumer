using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentApp.DB;
using RecruitmentApp.DB.Repository;
using RecruitmentApp.Entities;

namespace RecruitmentApp.Controllers
{
    public class ConsumersController : Controller
    {
        private readonly ConsumerContext _context;
        private readonly IConsumerRepository _repository;

        public ConsumersController(ConsumerContext context, IConsumerRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consumer.ToListAsync());
        }

        // GET: Consumers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await _context.Consumer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }

        // GET: Consumers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Number,Address.Street, Address.City")] Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                consumer.Id = Guid.NewGuid();
                _context.Add(consumer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consumer);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await _context.Consumer.SingleOrDefaultAsync(m => m.Id == id);
            if (consumer == null)
            {
                return NotFound();
            }
            return View(consumer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Surname,Number,AddressId")] Consumer consumer)
        {
            if (id != consumer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumerExists(consumer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(consumer);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await _context.Consumer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consumer = await _context.Consumer.SingleOrDefaultAsync(m => m.Id == id);
            _context.Consumer.Remove(consumer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsumerExists(Guid id)
        {
            return _context.Consumer.Any(e => e.Id == id);
        }
    }
}

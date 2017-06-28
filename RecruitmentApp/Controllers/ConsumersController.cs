using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentApp.DB.Repository;
using RecruitmentApp.Entities;

namespace RecruitmentApp.Controllers
{
    public class ConsumersController : Controller
    {
        private readonly IConsumerRepository _repository;

        public ConsumersController(IConsumerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var consumer = await _repository.GetById(id);
            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consumer consumer)
        {
            if (!ModelState.IsValid) return View(consumer);
            var result = await _repository.Add(consumer);
            return !result ? (IActionResult) BadRequest() : RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var consumer = await _repository.GetById(id);
            if (consumer == null)
            {
                return NotFound();
            }
            return View(consumer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Consumer consumer)
        {
            if (id != consumer.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(consumer);
            var result = await _repository.Update(consumer);
            return !result ? (IActionResult) BadRequest() : RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var consumer = await _repository.GetById(id);
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
            var result = await _repository.DeleteById(id);
            return result ? (IActionResult)BadRequest() : RedirectToAction("Index");
        }

      
    }
}
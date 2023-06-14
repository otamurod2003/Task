using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    [Authorize]
    public class SubjectsController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var subjects = _subjectRepository.GetAllSubjects();
            return View(subjects);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var subject = _subjectRepository.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subjectRepository.Create(subject);
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        public IActionResult Update(int id)
        {
            var subject = _subjectRepository.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        [HttpPost]
        public IActionResult Update(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _subjectRepository.Update(subject);
                return RedirectToAction(nameof(Index));
            }

            return View(subject);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var subject = _subjectRepository.GetSubject(id);
            if (subject == null)
            {
                return NotFound();
            }
            _subjectRepository.Delete(subject.Id);
            return RedirectToAction("index", "subjects");
        }

      
    }
}

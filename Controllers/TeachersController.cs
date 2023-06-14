using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var teacher = _teacherRepository.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherRepository.Create(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        public IActionResult Update(int id)
        {
            var teacher = _teacherRepository.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Update(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _teacherRepository.Update(teacher);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teacher = _teacherRepository.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _teacherRepository.Delete(teacher.Id);
            return RedirectToAction("Index","Teachers");
        }

      }
}

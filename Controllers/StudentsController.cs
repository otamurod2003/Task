using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            return View(students);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {               
                _studentRepository.Create(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Update(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existStudent =_studentRepository.Update(student);
                return RedirectToAction("index","students");
            }

            return View(student);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
                return NotFound();
            _studentRepository.Delete(student.Id);
            return RedirectToAction("index", "students");
        }


    }

}


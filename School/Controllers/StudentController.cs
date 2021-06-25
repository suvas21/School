using School.Common;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        private clsStudents objStudent = new clsStudents();
        // GET: Student
        public ActionResult Index()
        {
            int rowPerPage = 10;
            var studentsList = objStudent.GetStudentsList('',0, rowPerPage);
            ViewBag.RowCount = studentsList.Count();
            return View(studentsList);
        }

        public ActionResult LoadMoreStudentsList(string searchValue, int recordCount = 0)
        {
            clsStudents objStudent = new clsStudents();
            int rowPerPage = 15;
            var studentsList = objStudent.GetStudentsList(searchValue, recordCount, rowPerPage);
            ViewBag.RowCount = studentsList.Count();
            return Json(studentsList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Students student)
        {
            objStudent.AddStudent(student);
            return View("CreateStudent");
        }
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = objStudent.GetStudent(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Students students)
        {
            objStudent.UpdateStudent(students);
            return View();
        }
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            objStudent.DeleteStudent(id);
            return RedirectToAction("index");
        }
        public ActionResult StudentDetail(int id)
        {
            var student = objStudent.GetStudent(id);
            return View(student);
        }
        [HttpGet]
        public ActionResult AddSubject(int studentId)
        {
            ViewBag.SubjectsList = objStudent.GetSubjectsList();
            ViewBag.StudentId = studentId;
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(Course course)
        {
            objStudent.AddSubject(course);
            return RedirectToAction("StudentDetail");
        }
    }
}
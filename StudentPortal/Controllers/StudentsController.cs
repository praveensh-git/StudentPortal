
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entitie;

using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext context;
        public StudentsController(StudentContext context) {

            this.context = context;
        }
        
        public IActionResult Add()
        {       Student std= new Student();
           
            return PartialView("_Add",std);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student std)
        {

            if (!ModelState.IsValid)
            {
                var list = new List<string>();
                foreach (var prop in ModelState.Values)
                {
                    foreach (var err in prop.Errors)
                    {
                        list.Add(err.ErrorMessage);
                    }
                }
                string error = string.Join("\n", list);
                return BadRequest(error);
            }

            await context.Students.AddAsync(std);
               await context.SaveChangesAsync();
              var students = await context.Students.ToListAsync();
                return Ok(students);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            await context.SaveChangesAsync();
            var student = await context.Students.ToListAsync();
            return View(student);
        }
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var student = await context.Students.FindAsync(id);
        //    return View(student);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(Student viewModel)
        //{
        //    var student = await context.Students.FindAsync(viewModel.Id);
        //    if (student is not null)
        //    {
        //        student.Name = viewModel.Name;
        //        student.Email = viewModel.Email;
        //        student.Phone = viewModel.Phone;
        //        student.Percentage = viewModel.Percentage;
        //        await context.SaveChangesAsync();
               
        //    }
        //    var students = await context.Students.ToListAsync();
        //    return PartialView("_List10", students);

        //}

        [HttpPost]
        public async Task<JsonResult> UpdateStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = context.Students.Find(student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Email = student.Email;
                    existingStudent.Phone = student.Phone;
                    existingStudent.Percentage = student.Percentage;

                  await context.SaveChangesAsync();

                    return Json(new { success = true, message = "Student updated successfully!" });
                    //return Ok();
                }
                else
                {
                    return Json(new { success = false, message = "Student not found." });
                  //return NotFound();
                }
            }

            return Json(new { success = false, message = "Validation failed." });
          //  return BadRequest();
        }
    

    [HttpPost]
        public async Task<IActionResult> Delete(Student std)
        {
            var student = await context.Students.FindAsync(std.Id);
            if (student is not null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

       



        [HttpPost]
        public async Task<IActionResult> TransferStudent( [FromBody] Student student)
        {
            if (student.Id <= 0)
            {
                return BadRequest("Invalid student ID.");
            }

            var student10 = await context.Students.FindAsync(student.Id);

            if (student10 == null)
            {
                return NotFound("Student not found.");
            }

            //var isExists = await context.Students11.AnyAsync(a => a.StudentId == student10.Id);
            //if (isExists)
            //{
            //    return Json(new { success = false, redirectUrl = Url.Action("Warning", "Students") });
            //}
            if(student10.Percentage>60)
            {
                var studentToPromote = new Student11
                {
                    Name = student10.Name,
                    Email = student10.Email,
                    Phone = student10.Phone,
                    Percentage = student10.Percentage,
                    StudentId = student10.Id
                };

                await context.Students11.AddAsync(studentToPromote);
                await context.SaveChangesAsync();

                context.Students.Remove(student10);
                await context.SaveChangesAsync();
                var students = await context.Students.ToListAsync();
                return Ok(students);

                // return Json(new { success = true, promotedStudent = studentToPromote });
                //return RedirectToAction("ListStudent11", "Students");
            }
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> ListStudent11()
        {
            var students = await context.Students11.ToListAsync();
            return PartialView("_Transfer",students);
        }





















    }
}




////< script src = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js" ></ script >
//< script >
//    $(document).ready(function() {
//        $('#addStudentForm').on('submit', function(event) {
//            event.preventDefault();

//        var formData = {
//                Name: $("#Name").val(),
//                Email: $("#Email").val(),
//                Phone: $("#Phone").val(),
//                Percentage: $("#Percentage").val()
//            };

//    let formValid = false;


//            $.ajax({
//    type: 'POST',
//                url: '@Url.Action("Create", "Students")',
//                data: formData,
//                success: function(student) {
                   
//                        `< tr >


//                          < td >${ student.Name}</ td >
//                          < td >${ student.Email}</ td >
//                          < td >${ student.Phone}</ td >
//                          < td >${ student.Percentage}</ td >


//                          </ tr >`
                    
//                },
//                error: function(xhr, status, error) {
//            console.error(error);
//            alert("An error occurred while saving the student.");
//        }
//    });
//});
//    });
//</ script >
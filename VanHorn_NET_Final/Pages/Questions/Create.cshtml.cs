using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using VanHorn_NET_Final.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace VanHorn_NET_Final.Pages.Questions
{
    [Authorize(Policy = "TeacherOnly")]
    public class CreateModel : PageModel
    {
        private readonly VanHorn_NET_Final.Models.DomainContext _context;

        public CreateModel(VanHorn_NET_Final.Models.DomainContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int quizId)
        {
            QuizId = quizId;
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; } = default!;

        [BindProperty]
        public int QuizId { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Question question = new Question
            {
                QuizId = QuizId,
                QuestionText = Question.QuestionText
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Options/Create", new { questionId = Question.QuestionId});
        }
    }
}

//< div class= "row" >
//    < div class= "col-md-4" >
//        < form method = "post" >
//            < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
//            < div class= "form-group" >
//                < label asp -for= "Question.QuizId" class= "control-label" ></ label >
//                < select asp -for= "Question.QuizId" class= "form-control" asp - items = "ViewBag.QuizId" ></ select >
//            </ div >
//            < div class= "form-group" >
//                < label asp -for= "Question.QuestionText" class= "control-label" ></ label >
//                < input asp -for= "Question.QuestionText" class= "form-control" />
//                < span asp - validation -for= "Question.QuestionText" class= "text-danger" ></ span >
//            </ div >
//            < div class= "form-group" >
//                < input type = "submit" value = "Add options" class= "btn btn-primary" />
//            </ div >
//        </ form >
//    </ div >
//</ div >

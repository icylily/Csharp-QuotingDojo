using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("quotes")]
        [HttpPost]
        public IActionResult quotes(Quote currentQuote)
        {

            if (!ModelState.IsValid)
            {
                // do somethng!  maybe insert into db?  then we will redirect
                return View("Index");
            }
            else
            {
                string query = $"INSERT INTO quotes (name, quote) VALUES ('{currentQuote.Name}', '{currentQuote.Quotecomment}')";
                DbConnector.Execute(query);
                return View("Result");
            }

        }

        [Route("quotes")]
        [HttpGet]
        public IActionResult GetQuotes(Quote currentQuote)
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes order by created_at;");
            // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
            ViewBag.Quotes = AllQuotes;
            return View("Result");

        }



    }
}

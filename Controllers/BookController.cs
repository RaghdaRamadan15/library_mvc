using DayMvctoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace DayMvctoApi.Controllers
{
    public class BookController : Controller
    {
        bookwithAuthor book=new bookwithAuthor();
        HttpClient client=new HttpClient();
        string endpoint = "http://localhost:5152/api/BOOK";
        //get
        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<bookwithAuthor> boo = await client.GetFromJsonAsync<List<bookwithAuthor>>(endpoint);

            return View(boo);
        }

        #endregion

        #region create
        [HttpGet]
        public async Task<IActionResult> create()
        {
            List<Author> au = await client.GetFromJsonAsync<List<Author>>("http://localhost:5152/api/Author");
            ViewData["AuthorId"] = new SelectList(au, "id", "Name");
            return View();
        }

        #endregion


        #region create_post
        [HttpPost]
        public async Task<IActionResult> create(bookwithAuthor b)
        {
            if (ModelState.IsValid)
            {
                var res = await client.PostAsJsonAsync<bookwithAuthor>(endpoint, b);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }


            List<Author> authors = await client.GetFromJsonAsync<List<Author>>("http://localhost:5152/api/Author");
            ViewData["AuthorId"] = new SelectList(authors, "id", "Name");
            return View(b);
        }

        #endregion

        //delete
        #region delete
        [HttpPost]
        public async Task<IActionResult> delelet(int id)
        {
            var res = await client.DeleteAsync($"{endpoint}/{id}");
            return RedirectToAction("Index");
        }

        #endregion



        #region edit_get
        //getby_id
        [HttpGet]
        public async Task<IActionResult> edit(int id)
        {
            bookwithAuthor b = await client.GetFromJsonAsync<bookwithAuthor>(endpoint + "/" + id);

            return View(b);
        }

        #endregion



        #region edit_post
        [HttpPost]
        public async Task<IActionResult> edit(bookwithAuthor b)
        {
            var res = await client.PutAsJsonAsync<bookwithAuthor>(endpoint + "/" + b.id, b);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(b);
        }


        #endregion
    }
}

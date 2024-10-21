using Microsoft.AspNetCore.Mvc;
using DayMvctoApi.Models;
using System.Collections.Generic;
namespace DayMvctoApi.Controllers

{
    public class AUTHERSController : Controller
    {

        HttpClient client = new HttpClient();
        string endpoint = "http://localhost:5152/api/Author";
        Author author = new Author();


        #region Index
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            List<Author> au = await client.GetFromJsonAsync<List<Author>>(endpoint);


            return View(au);
        }

        #endregion

        #region create_get
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        #endregion

        #region create_post
        [HttpPost]
        public async Task<IActionResult> create(Author a)
        {
            if (ModelState.IsValid)
            {

                author.Name = a.Name;
                var res = await client.PostAsJsonAsync<Author>(endpoint, a);
                if (res.IsSuccessStatusCode)
                {

                    //return Content("hhh");
                    return RedirectToAction("Index");

                }
            }


            return View(a);
        }

        #endregion

        #region edit_get
        [HttpGet]
        //[HttpGet("{id}")]

        //[Route("{id}")]
        public async Task<IActionResult> edit(int id)
        {

            Author au = await client.GetFromJsonAsync<Author>($"{endpoint}/{id}");
            return View(au);
        }

        #endregion


        #region edit_post
        [HttpPost]
        public async Task<IActionResult> edit(Author a)
        {
            if (ModelState.IsValid)
            {
                await client.PutAsJsonAsync<Author>($"{endpoint}/{a.id}", a);
                return RedirectToAction("Index");
            }

            //Author au = await client.GetFromJsonAsync<Author>($"{endpoint}/{id}");
            return View(a);
        }

        #endregion


        #region delete
        [HttpPost]
        public async Task<IActionResult> delete(int id)
        {
            var res = await client.DeleteAsync($"{endpoint}/{id}");

            return RedirectToAction("Index"); ;



        }

        #endregion


        //delete
    }
}

    
    

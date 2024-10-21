using DayMvctoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DayMvctoApi.Controllers
{
    public class LabController : Controller
    {
        HttpClient client = new HttpClient();
        string endpoint = "http://localhost:5152/api/lab";
        #region getall
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<labwithauthor> library = await client.GetFromJsonAsync<List<labwithauthor>>(endpoint);

            return View(library);
        }
        #endregion

        #region create
        [HttpGet]
        public async Task<IActionResult> create()
        {

            List<Author> au = await client.GetFromJsonAsync<List<Author>>("http://localhost:5152/api/Author");
            List<SelectListItem> authorList = au.Select(a => new SelectListItem
            {
                Value = a.id.ToString(), 
                Text = a.Name 
            }).ToList();

            ViewData["AuthorList"] = authorList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(labwithauthor lab)
        {
            if (ModelState.IsValid)
            {
                var res = await client.PostAsJsonAsync<labwithauthor>(endpoint, lab);
                if (res.IsSuccessStatusCode) {
                  return RedirectToAction("Index");
                
                }
            }
            List<Author> au = await client.GetFromJsonAsync<List<Author>>("http://localhost:5152/api/Author");
            List<SelectListItem> authorList = au.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.Name
            }).ToList();
            ViewData["AuthorList"] = authorList;
            return View(lab);

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

        #region edit_get
        [HttpGet]
        
        public async Task<IActionResult> edit(int id)
        {

            labwithauthor lab = await client.GetFromJsonAsync<labwithauthor>($"{endpoint}/{id}");
            return View(lab);
        }

        #endregion


        #region edit_post
        [HttpPost]
        public async Task<IActionResult> edit(labwithauthor lab)
        {
            if (ModelState.IsValid)
            {
                await client.PutAsJsonAsync<labwithauthor>($"{endpoint}/{lab.id}", lab);
                return RedirectToAction("Index");
            }

            //Author au = await client.GetFromJsonAsync<Author>($"{endpoint}/{id}");
            return View(lab);
        }

        #endregion


    }
}

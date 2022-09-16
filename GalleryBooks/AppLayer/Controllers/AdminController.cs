using AppLayer.Filters;
using AppLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppLayer.Controllers
{
    public class AdminController : Controller
    {
        private IConfiguration configuration;
        private string baseUrl;
        private string Url;
        public AdminController(IConfiguration configuration)
        {
            this.configuration = configuration;
            Url = configuration.GetValue<string>("applicationUrl");
            baseUrl += Url + "Admin";
        }

        public object? BooksList { get; private set; }
        [Route("")]
        [Route("ShowAllBook", Name = "ShowAllBook")]
        public async Task<IActionResult> ShowAllBooks()
        {
            List<Books> booksList = new List<Books>();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"{Url}Books/GetAll"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        booksList = JsonConvert.DeserializeObject<List<Books>>(apiResponse);
                    }
                }
            }

            return View(booksList);
        }

        [Route("Login", Name = "Login")]
        
        public IActionResult Login()
        {
            return View();
        }
       
        [Route("Login", Name = "Login")]
        
        [HttpPost]
        public async Task<IActionResult> Login(Admins admin)
        {

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync($"{baseUrl}/Login", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetString("Email", admin.EmailId);
                        return RedirectToAction("ShowAllBooks");
                    }


                }
                return View();
            }
        }
       

        
        [Route("SaveBook" )]
        [Authorize]


        public IActionResult SaveBook()
        {
            return View();
        }
   
        [Authorize]
        [HttpPost]
        [Route("SaveBook", Name = "SaveBook")]
    

        public async Task<IActionResult> SaveBook(Books books)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(books), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{baseUrl}/SaveBook", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            return RedirectToAction("ShowAllBooks");
                        }



                    }
                    return View();
                }
            }
            return View();


        }
      
        [Route("Logout", Name = "Logout")]

     
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("ShowAllBooks", "Admin");
        }

        [HttpGet]
        [Route("Admin/Delete/{id}", Name = "Delete")]
        [Authorize]



        public async Task<IActionResult> DeleteBook(int? id)
        {



            using (var httpClient = new HttpClient())
            {



                using (var response = await httpClient.DeleteAsync($"{baseUrl}/Delete/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ShowAllBooks", "Admin");
                    }
                }
            }
            return View();
        }
        
        [Route("UpdatesBook/{id}", Name= "UpdatesBook")]
        [Authorize]

        public async Task<IActionResult> UpdatesBooks(int id)
        {           
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");

            Books book = new Books();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"{Url}Books/GetBookByID/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<Books>(apiResponse);
                    }
                }
            }

            return View(book);
         }
        [HttpPost]
        [Route("UpdatesBooks" , Name = "UpdatesBooks")]
        [Authorize]

        public async Task<IActionResult> UpdatesBooks(Books books)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(books), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync($"{baseUrl}/UpdatesBooks", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ShowAllBooks");
                    }

                }
                return View();
            }



        }




    }
}

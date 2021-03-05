using Framework.Models;
using Framework2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace Framework2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Todos(int? pagina)
        {
            TodosModel[] todosModel = null;
            using (var cliente = new HttpClient())
            {
                //      Aqui estou passando para o HttpClient a minha rota
                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

                cliente.DefaultRequestHeaders.Accept.Clear();

                //      Aqui estou mostrando em que formato os dados virão
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //                      Fazendo o HttpClient


                HttpResponseMessage response = await cliente.GetAsync("todos");
                if (response.IsSuccessStatusCode)
                {
                    //      Aqui estou atribuindo a variável "todos" a leitura da string(dados)
                    string todos = await response.Content.ReadAsStringAsync();

                    //      Aqui estou convertendo os dados que estão em Json em um object
                    todosModel = JsonConvert.DeserializeObject<TodosModel[]>(todos);
                }
            }
            //      Aqui estou definindo o tamanho de dados de cada página
            int paginaTamanho = 15;

            //      Aqui estou testando se o número da página é nulo,se for nulo irei atribuir para ele o número 1
            int paginaNumero = (pagina ?? 1);

            //      Aqui estou retornando os dados ja convertidos para um objeto juntamente com a paginação
            return View(todosModel.ToPagedList(paginaNumero, paginaTamanho));
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Albuns(int? pagina)
        {
            AlbunsModel[] albunsModel = null;
            using (var cliente = new HttpClient())
            {
                //      Aqui estou passando para o HttpClient a minha rota
                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                cliente.DefaultRequestHeaders.Accept.Clear();
                //      Aqui estou mostrando em que formato os dados virão
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //                      Fazendo o HttpClient


                HttpResponseMessage response = await cliente.GetAsync("albums");
                if (response.IsSuccessStatusCode)
                {
                    //      Aqui estou atribuindo a variável "todos" a leitura da string(dados)
                    string albuns = await response.Content.ReadAsStringAsync();
                    //      Aqui estou convertendo os dados que estão em Json em um object
                    albunsModel = JsonConvert.DeserializeObject<AlbunsModel[]>(albuns);
                }
            }
            //      Aqui estou definindo o tamanho de dados de cada página
            int paginaTamanho = 10;
            //      Aqui estou testando se o número da página é nulo,se for nulo irei atribuir para ele o número 1
            int paginaNumero = (pagina ?? 1);

            //      Aqui estou retornando os dados ja convertidos para um objeto juntamente com a paginação
            return View(albunsModel.ToPagedList(paginaNumero, paginaTamanho));
        }

        public async Task<IActionResult> Postagens(int? pagina)
        {
            PostagensModel[] postagensModel = null;
            using (var cliente = new HttpClient())
            {
                //      Aqui estou passando para o HttpClient a minha rota
                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                cliente.DefaultRequestHeaders.Accept.Clear();
                //      Aqui estou mostrando em que formato os dados virão
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //                      Fazendo o HttpClient


                HttpResponseMessage response = await cliente.GetAsync("posts");
                if (response.IsSuccessStatusCode)
                {
                    //      Aqui estou atribuindo a variável "todos" a leitura da string(dados)
                    string postagens = await response.Content.ReadAsStringAsync();
                    //      Aqui estou convertendo os dados que estão em Json em um object
                    postagensModel = JsonConvert.DeserializeObject<PostagensModel[]>(postagens);
                }
            }
            //      Aqui estou definindo o tamanho de dados de cada página
            int paginaTamanho = 10;
            //      Aqui estou testando se o número da página é nulo,se for nulo irei atribuir para ele o número 1
            int paginaNumero = (pagina ?? 1);

            //      Aqui estou retornando os dados ja convertidos para um objeto juntamente com a paginação
            return View(postagensModel.ToPagedList(paginaNumero, paginaTamanho));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

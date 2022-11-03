using CepAndHoliday.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace CepAndHoliday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        [HttpGet(Name = "GetAddress")]
        public async Task<Cep> GetAsync(string cep)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://viacep.com.br/ws/") };
                var dados = await client.GetFromJsonAsync<Cep>($"{cep}/json/");
                return dados;
        }
    }
}



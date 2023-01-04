using CRM.Adm.Application.DTOs;
using CRM.Adm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRM.Adm.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _context;

        private readonly JsonSerializerOptions _options;

        private  IHttpClientFactory _clientFactory;
        private  IConfiguration _configuration;
        public ClienteController(IClienteService context
            , IHttpClientFactory clientFactory
            , IConfiguration config
            )
        {
            _context = context;
            _clientFactory = clientFactory;
            _configuration = config;
        }

        private async Task<List<ClienteDTO>>  GetByName(string nome)
        {
            List<ClienteDTO> listClientesDto = new List<ClienteDTO>();
            var baseAddress = _configuration.GetSection("API:baseAddress");
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(baseAddress.Value);
            var url = $"Nome/{nome}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                listClientesDto = JsonConvert.DeserializeObject<List<ClienteDTO>>(apiResponse);
            };

            return listClientesDto.ToList();
        }
        public IActionResult Index()
        {
            //var clientes = await GetByName();
            //var clientes = await _context.GetClientes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string NomeEmpresarial)
        {
            List<ClienteDTO> clientes = await GetByName(NomeEmpresarial);
            if (clientes is null)
                return NotFound("Registro não localizado.");

            return View(clientes);
        }
    }
}

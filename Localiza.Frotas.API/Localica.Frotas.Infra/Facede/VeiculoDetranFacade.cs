using Localica.Frotas.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Localica.Frotas.Infra.Facede
{
    public class VeiculoDetranFacade : IveiculosDetran
    {
        private readonly DetranOptions  detranOptions;
        private readonly IHttpClientFactory htppCliente;
        private readonly IveiculosRepository _repository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> options, IHttpClientFactory htpp, IveiculosRepository repository)
        {
            this.detranOptions = options.CurrentValue;
            this.htppCliente = htpp;
            this._repository = repository;
        }

        public async Task AgendarVistoriaDetran(Guid veiculoID)
        {
            var veiculo = _repository.GetById(veiculoID);

            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(detranOptions.QuantidadeDiasAgendamento)
            };

            var cliente = htppCliente.CreateClient();
            cliente.BaseAddress = new Uri(detranOptions.BaseUrl);
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(json, Encoding.UTF8, "application/json");

            await cliente.PostAsync(detranOptions.VistoriaUri, contentString);

        }
    }
}

using Localica.Frotas.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Localica.Frotas.Infra.Repository.Entiti
{
    public class PopulandoDados 
    {
        public readonly IveiculosRepository iveiculosRepository;

        public  PopulandoDados(IveiculosRepository repository)
        {
            this.iveiculosRepository = repository;
        }

        public void Populando()
        {

            iveiculosRepository.Add(new InputVeiculoViewModel
            {
                AnoFabricacao = new DateTime(2019, 05, 29),
                Marca = "chevrolet",
                Placa = "ABCD1234"
            });

            iveiculosRepository.Add(new InputVeiculoViewModel
            {
                AnoFabricacao = new DateTime(2010, 09, 15),
                Marca = "AUDI",
                Placa = "ABCD6789"
            });

        }


        


    }
}

﻿using Fiap.Web.AspNet.Models;
using Fiap.Web.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Fiap.Web.AspNet.Repository
{
    public class ClienteRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public ClienteRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }


        public IList<ClienteModel> Listar()
        {
            var lista = dataBaseContext.Cliente
                    .Include(c => c.Representante)
                        .ToList<ClienteModel>();

            return lista;

        }


        public ClienteModel Consultar(int id)
        {

            var cliente = new ClienteModel();

            cliente = dataBaseContext.Cliente
                    .Include( c => c.Representante )
                        .Where( c => c.ClienteId == id)
                            .FirstOrDefault();

            return cliente;

        }

        public void Inserir(ClienteModel cliente)
        {
            dataBaseContext.Cliente.Add(cliente);
            dataBaseContext.SaveChanges();
        }


        public void Alterar(ClienteModel cliente)
        {
            dataBaseContext.Cliente.Update(cliente);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var cliente = new ClienteModel { ClienteId = id };

            dataBaseContext.Cliente.Remove(cliente);
            dataBaseContext.SaveChanges();

        }

    }
}

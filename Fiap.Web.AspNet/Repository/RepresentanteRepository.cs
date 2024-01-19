using Fiap.Web.AspNet.Models;
using Fiap.Web.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet.Repository
{
    public class RepresentanteRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public RepresentanteRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<RepresentanteModel> Listar()
        {

            var lista = new List<RepresentanteModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Representante.ToList<RepresentanteModel>();
            
            return lista;
        }

        public IList<RepresentanteModel> ListarRepresentantesComClientes()
        {

            var lista = new List<RepresentanteModel>();

            lista = dataBaseContext.Representante
                    .Include( r => r.Clientes)
                        .ToList<RepresentanteModel>();

            return lista;
        }


        public IList<RepresentanteModel> ListarOrdenadoPorNome()
        {
            var lista = new List<RepresentanteModel>();

            lista = dataBaseContext
                .Representante
                .OrderBy( r => r.NomeRepresentante).ToList<RepresentanteModel>();

            return lista;
        }

        public IList<RepresentanteModel> ListarOrdenadoPorNomeDescendente()
        {
            var lista = new List<RepresentanteModel>();

            lista = dataBaseContext
                .Representante
                .OrderByDescending(r => r.NomeRepresentante).ToList<RepresentanteModel>();

            return lista;
        }


        public RepresentanteModel ConsultarPorCpf(String cpf)
        {
            var representante = dataBaseContext.Representante.
                    Where(r => r.Cpf == cpf).
                        FirstOrDefault<RepresentanteModel>();

            return representante;
        }

        public RepresentanteModel ConsultarPorParteNome(String nomeParcial)
        {
            var representante = dataBaseContext.Representante.
                    Where(r => r.NomeRepresentante.Contains(nomeParcial)).
                        FirstOrDefault<RepresentanteModel>();

            return representante;
        }

        public RepresentanteModel Consultar(int id)
        {
            // Recuperando o objeto Representante de um determinado Id
            var representante = dataBaseContext.Representante.Find(id);

            return representante;
        }

        public void Inserir(RepresentanteModel representante)
        {
            // a propriedade dataBaseContext é declarada no escopo da classe
            // e sua instância é recebida pelo construtor da classe Repository
            // veja na solução final da classe RepresentanteRepository

            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Representante.Add(representante);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(RepresentanteModel representante)
        {
            dataBaseContext.Representante.Update(representante);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var representante = new RepresentanteModel(id,"");

            dataBaseContext.Representante.Remove(representante);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }
}

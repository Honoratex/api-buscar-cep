using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System.Web.Http;
using System.Web.Mvc;
using System.Windows;

namespace buscaCepAPI.Controllers
{
    public class BuscarCepController : ApiController
    {
        // GET: api/buscarCep/5
        public RetornoCep Get(string id)
        {

            var cepUrl = "http://viacep.com.br/ws/";

            var complemento = id + "/json";

            var linkCompleto = cepUrl + complemento;

            var requisicaoWeb = WebRequest.CreateHttp(linkCompleto);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            try
            {
                using (var resposta = requisicaoWeb.GetResponse())
                {

                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);

                    object objResponse = reader.ReadToEnd();

                    var post = JsonConvert.DeserializeObject<RetornoCep>(objResponse.ToString());

                    RetornoCep viaCep = new RetornoCep();

                    viaCep.Cep = post.Cep;

                    viaCep.Logradouro = post.Logradouro;

                    viaCep.Complemento = post.Complemento;

                    viaCep.Bairro = post.Bairro;

                    viaCep.Localidade = post.Localidade;

                    viaCep.Uf = post.Uf;

                    viaCep.Ibge = post.Ibge;

                    viaCep.Ddd = post.Ddd;

                    viaCep.Siafi = post.Siafi;

                    //var Cep = post.Cep;
                    //var Logradouro = post.Logradouro;
                    //var Complemento = post.Complemento;
                    //var Bairro = post.Bairro;
                    //var Localidade = post.Localidade;
                    //var Uf = post.Uf;
                    //var Unidade = post.Unidade;
                    //var Ibge = post.Ibge;
                    //var Gia = post.Gia;

                    if (objResponse == null)
                    {
                        return (RetornoCep)objResponse;
                    }
                    else
                    {

                        return viaCep;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }

}



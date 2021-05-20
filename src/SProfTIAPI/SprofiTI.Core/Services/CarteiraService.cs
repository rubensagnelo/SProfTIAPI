using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using SProfTIAPI.Entities;
using SProfTIAPI.Helpers;
using SProfTIAPI.Models;
using  System.Linq.Expressions;


namespace SProfTIAPI.Services
{
    
    public class CarteiraService {

        private static dbmongo.MongoDatabase<SProfTIAPI.Entities.Carteira> cr = new dbmongo.MongoDatabase<Entities.Carteira>("SProfTIAPI.CARTEIRA");

        public static List<CarteiraItem> Get(out int errcode, string TituloCarteira=""){

                List<CarteiraItem> result = new List<CarteiraItem>();
                errcode = 500;
                try
                {

                    Expression<Func<Carteira, bool>> Filtro =  a => a.Titulo.Contains(TituloCarteira);
                    List<Carteira> Lcrt = cr.GetList(Filtro);


                    errcode = 400;// <response code="400">valor do parametro inválido</response>
                    foreach (var item in Lcrt)
                    {
                        result.Add( 
                                new CarteiraItem(){
                                    Dataatualizaco = item.Dataatualizao,//  DateTime.Now,
                                    Idcarteira = item.Idcarteira,
                                    Titulo = item.Titulo,
                                    Descrcricao = item.Descrcricao
                                });
                    }

                    errcode = 200; // <response code="200">resultados da consulta</response>
                    
                }
                catch (System.Exception ex)
                {

                }


                return result;

        }

        public static CarteiraItem GetById(out int errcode, int? idcarteira){

                CarteiraItem result = null;
                errcode = 500;
                try
                {

                    Expression<Func<Carteira, bool>> Filtro =  a => a.Idcarteira == idcarteira;
                    Carteira item = cr.GetOne(Filtro);

                    if (item != null){
                        errcode = 400;// <response code="400">valor do parametro inválido</response>
                        result = new CarteiraItem(){
                                Dataatualizaco = item.Dataatualizao,
                                Idcarteira = item.Idcarteira,
                                Titulo = item.Titulo,
                                Descrcricao = item.Descrcricao
                        };
                    }
                    

                    errcode = 200; // <response code="200">resultados da consulta</response>
                    
                }
                catch (System.Exception ex)
                {

                }


                return result;

        }

        public static int Add(Models.CarteiraItem item){

                int  result = 201;// 201 - arteira incluida com sucesso

                try
                {

                    result = 401;//401 - parametro ou estrutura de entrada inálida

                    Carteira obj = new Carteira(){
                        Dataatualizao = DateTime.Now,
                        Idcarteira = item.Idcarteira,
                        Titulo = item.Titulo,
                        Descrcricao = item.Descrcricao
                    };


                    Expression<Func<Carteira, bool>> Filtro =  a => a.Idcarteira == obj.Idcarteira || a.Titulo == obj.Titulo;
                    Carteira crt = cr.GetOne(Filtro);

                    
                    if (crt != null) 
                    {
                        result = 409; //carteira já existente (Titulo ou id da carteira ja existe)
                        throw new Exception("409 - carteira já existente (Titulo ou id da carteira ja existe)");
                    }


                    cr.InsertOne(obj);
                    result = 201;// 201 - arteira incluida com sucesso

                }
                catch (System.Exception ex)
                {

                    
                }


                return result;

                // <response code="201">carteira incluida</response>
                // <response code="400">parametro ou estrutura de entrada inálida</response>
                // <response code="409">carteira já existente (nome da carteira ja existe)</response>
        }

        public static void Del(out int errcode, int? idcarteira){

                errcode = 400;// <response code="400">id da carteira inálida</response>
                try
                {

                    Expression<Func<Carteira, bool>> Filtro =  a => a.Idcarteira == idcarteira;
                    Carteira crt = cr.GetOne(Filtro);
                    if (crt == null) 
                    {
                        errcode = 404; //404 - arteira nao encontrada
                        throw new Exception("404 - arteira nao encontrada");
                    }                    

                    // <response code="400">id da carteira inálida</response>

                    cr.DeleteOne(Filtro);
                    errcode=202;// <response code="202">carteira excluída</response>
                    
                }
                catch (System.Exception ex)
                {

                }

        }

        public static int Update(int? Idcarteira, Models.CarteiraItem item){

                int  result = 201;// 201 - arteira incluida com sucesso

                try
                {

                    result = 401;//401 - parametro ou estrutura de entrada inválida

                    Carteira obj = new Carteira(){
                        Dataatualizao = DateTime.Now,
                        Idcarteira = item.Idcarteira,
                        Titulo = item.Titulo,
                        Descrcricao = item.Descrcricao
                    };


                    Expression<Func<Carteira, bool>> Filtro =  a => a.Idcarteira == obj.Idcarteira;
                    Carteira crt = cr.GetOne(Filtro);

                    
                    if (crt == null) 
                    {
                        result = 404; //404 - carteira nao encontrada
                        throw new Exception("409 - carteira já existente (Titulo ou id da carteira ja existe)");
                    }


                    var update = MongoDB.Driver.Builders<Carteira>.Update;
                    var updates = new List<MongoDB.Driver.UpdateDefinition<Carteira>>();
                    updates.Add(update.Set("Dataatualizao",DateTime.Now));
                    updates.Add(update.Set("Titulo",obj.Titulo));
                    updates.Add(update.Set("Descrcricao",obj.Descrcricao));

                    cr.UpdateOne(Filtro, update.Combine(updates));
                    result = 201;// 201 - arteira incluida com sucesso
                    

                }
                catch (System.Exception ex)
                {

                    
                }


                return result;

                // <response code="201">carteira incluida</response>
                // <response code="400">Identificador da carteira fornecido é inválido</response>
                // <response code="401">401 - parametro ou estrutura de entrada inálida</response>
                // <response code="409">carteira já existente (nome da carteira ja existe)</response>
                // <response code="404">carteira nao encontrada</response>
                // <response code="405">Exceção na autalização dos dados da carteira</response>
        }



    }

} 
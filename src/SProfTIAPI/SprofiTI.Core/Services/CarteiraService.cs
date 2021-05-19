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

        private static dbmongo.MongoDatabase<SProfTIAPI.Entities.Carteira> cr = new dbmongo.MongoDatabase<Entities.Carteira>("CARTEIRA");

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


        public static int Add(Models.CarteiraItem item){

                int  result = 201;// 201 - arteira incluida com sucesso

                try
                {

                    result = 401;//401 - parametro ou estrutura de entrada inálida

                    Carteira obj = new Carteira(){
                        Dataatualizao = item.Dataatualizaco,//  DateTime.Now,
                        Idcarteira = item.Idcarteira,
                        Titulo = item.Titulo,
                        Descrcricao = item.Descrcricao
                    };


                    Expression<Func<Carteira, bool>> IDCarteiraExist =  a => a.Idcarteira == obj.Idcarteira || a.Titulo == obj.Titulo;
                    
                    Carteira crt = cr.GetOne(IDCarteiraExist);

                    
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
    }

} 
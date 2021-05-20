using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using idbmongo;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using SProfTIAPI.proxy;
using SProfTIAPI.Entities;



namespace SProfTIAPI.Services
{
    public class GitHubService
{

        public static List<Usuarioplataformaitem> GetUsers(int? IdIni, int? Pagina, enums.enmPlataforma plataforma)
        {
            List<Usuarioplataformaitem> result = new List<Usuarioplataformaitem>();
            GitHubRootUser[] usersRoot = WebAPIProxy.Get<GitHubRootUser[]>("https://api.github.com/users?since="+IdIni.ToString()+"&per_page="+Pagina.ToString());

            foreach (var item in usersRoot)
            {

                GitHubUserDetail userdetail = WebAPIProxy.Get<GitHubUserDetail>(item.url);

                Usuarioplataformaitem usr = new Usuarioplataformaitem(){
                            Nome = userdetail.name,
                            Email = userdetail.email.ToString(),
                            Idplataforma = (int)enums.enmPlataforma.github,
                            localizacao = userdetail.location,
                            Reputacao = userdetail.followers + userdetail.public_repos,
                            Idusuarioplatafaorma = userdetail.id.ToString(),
                            Avatar = userdetail.avatar_url 

                };

                result.Add(usr);
            }

            return result;
            
        }


        public static Usuarioplataformaitem GetUser(int? Id)
        {
                 GitHubUserDetail userdetail = WebAPIProxy.Get<GitHubUserDetail>("https://api.github.com/users/"+Id.ToString());

                Usuarioplataformaitem result = new Usuarioplataformaitem(){
                            Nome = userdetail.name,
                            Email = userdetail.email.ToString(),
                            Idplataforma = (int)enums.enmPlataforma.github,
                            localizacao = userdetail.location,
                            Reputacao = userdetail.followers + userdetail.public_repos,
                            Idusuarioplatafaorma = userdetail.id.ToString(),
                            Avatar = userdetail.avatar_url 

                };

                return result;
        }

}
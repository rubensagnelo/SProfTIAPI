using System.Collections.Generic;
using SProfTIAPI.proxy;
using SProfTIAPI.Entities;
using SProfTIAPI.Models;
using SProfTIAPI.Services;


namespace SProfTIAPI.Services
{
    public class UsuarioPlataformaService
    {

        public static List<Usuarioplataforma> GetUsers(int? IdIni, int? Pagina, enums.enmPlataforma plataforma)
        {
            if (plataforma == enums.enmPlataforma.github)    
                return GitHubService.GetUsers(IdIni,Pagina) ;
            else if (plataforma == enums.enmPlataforma.stackoverflow)
                return new List<Usuarioplataforma>();//TODO: Implementar plataforma stackoverflow
        }


        public static Usuarioplataforma GetUser(int? Id, enums.enmPlataforma plataforma)
        {
            if (plataforma == enums.enmPlataforma.github)    
                return SProfTIAPI.Services.GitHubService.GetUser(Id);
            else if (plataforma == enums.enmPlataforma.stackoverflow)
                return new Usuarioplataforma();//TODO: Implementar plataforma stackoverflow
        }




    }

}
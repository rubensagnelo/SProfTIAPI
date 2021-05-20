using System.Collections.Generic;
using SProfTIAPI.proxy;
using SProfTIAPI.Entities;
using SProfTIAPI.Models;


namespace SProfTIAPI.Services
{
    public class UsuarioPlataformaService
    {

        public static List<Models.Usuarioplataformaitem> GetUsers(int? IdIni, int? Pagina, enums.enmPlataforma plataforma)
        {
            if (plataforma == enums.enmPlataforma.github)    
                return SProfTIAPI.Services.GitHubService.GetUsers(IdIni,Pagina) ;
            else if (plataforma == enums.enmPlataforma.stackoverflow)
                return new List<Models.Usuarioplataformaitem>();//TODO: Implementar plataforma stackoverflow
        }


        public static Models.Usuarioplataformaitem GetUser(int? Id, enums.enmPlataforma plataforma)
        {
            if (plataforma == enums.enmPlataforma.github)    
                return SProfTIAPI.Services.GitHubService.GetUser(Id);
            else if (plataforma == enums.enmPlataforma.stackoverflow)
                return new Models.Usuarioplataformaitem();//TODO: Implementar plataforma stackoverflow
        }




    }

}
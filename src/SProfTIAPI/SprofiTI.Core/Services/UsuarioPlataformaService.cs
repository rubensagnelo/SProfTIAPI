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
            List<Usuarioplataforma> result = new List<Usuarioplataforma>();
            try
            {
                if (IdIni==null || IdIni==0) IdIni=1;
                if (Pagina==null || Pagina==0) Pagina=10;

                if (plataforma == enums.enmPlataforma.github)    
                    result = GitHubService.GetUsers(IdIni,Pagina) ;
                else if (plataforma == enums.enmPlataforma.stackoverflow)
                    result = new List<Usuarioplataforma>();//TODO: Implementar plataforma stackoverflow
            }
            catch (System.Exception ex)
            {
            }
            return result;
        }


        public static Usuarioplataforma GetUser(int? Id, enums.enmPlataforma plataforma)
        {
            Usuarioplataforma result = new Usuarioplataforma();
            try
            {
                if (plataforma == enums.enmPlataforma.github)    
                    result = SProfTIAPI.Services.GitHubService.GetUser(Id);
                else if (plataforma == enums.enmPlataforma.stackoverflow)
                    result = new Usuarioplataforma();//TODO: Implementar plataforma stackoverflow
            }
            catch (System.Exception ex)
            {
            }
            return result;

        }

    }

}
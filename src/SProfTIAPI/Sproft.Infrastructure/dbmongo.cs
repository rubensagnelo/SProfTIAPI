using System;
using MongoDB.Bson;
using MongoDB.Driver;
using ragi.menu;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Authentication;

namespace db
{

    
    public class mongodb
    {
        

        /*
        static void Main(string[] args)
        {
            menu mn = mocmenu();


            //salvarAtlasMongo(mn);//ok
            salvarTXT(mn);
            //salvarMongo(mn);


            string jsonString = JsonSerializer.Serialize(mn);
            


            //var client = new MongoClient("mongodb+srv://rubensagnelo:pitado76@cluster0.wvsyy.mongodb.net/DB1?retryWrites=true&w=majority");
            //var database = client.GetDatabase("menu");
            //IMongoCollection<menu> menu =  database.GetCollection<menu>("menu");

            //Expression<Func<News, bool>> filter = x => x.Title.Contains("s");
            //IList<News> items = colNews.Find(filter).ToList();



            Console.WriteLine(jsonString);
        } */
        


        private static void salvarAtlasMongo(menu mn)
        {
            
            var cclient = new MongoClient("mongodb+srv://rubensagnelo:pitado75@cluster0.wvsyy.mongodb.net/DB1?retryWrites=true&w=majority");
            var database = cclient.GetDatabase("DB1");
            IMongoCollection<menu> colecaoMenu = database.GetCollection<menu>("menu");

            var mnrpl = colecaoMenu.FindOneAndDelete<menu>(
                x =>
                ((chavemenu)x.chave).SO == ((chavemenu)mn.chave).SO &&
                ((chavemenu)x.chave).versaoApp == ((chavemenu)mn.chave).versaoApp);
         
                colecaoMenu.InsertOne(mn);
        }

        private static void salvarMongo(menu mn)
        {
            IMongoDatabase _mongoDb;
            string _host = "191.185.112.62";
            Int32 _port = 27017;// 30017;
            string _userName = "usuario1";
            string _password = "usuario1";
            bool _userTls = true;                  //TODO enable MongoDB Server TLS first, then enable Tls in client app
            string _authMechanism = "SCRAM-SHA-1";
            string _authDbName = "atlasAdmin";
            string _dbName = "DB1";

            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(_host, _port);

            settings.UseTls = _userTls;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoIdentity identity = new MongoInternalIdentity(_authDbName, _userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(_password);

            settings.Credential = new MongoCredential(_authMechanism, identity, evidence);

            MongoClient client = new MongoClient(settings);
            _mongoDb = client.GetDatabase(_dbName);
            IMongoCollection<menu> colecaoMenu = _mongoDb.GetCollection<menu>("menu");
            var mnrpl = colecaoMenu.FindOneAndReplace<menu>(u => u.chave == mn.chave, mn);
            if (mnrpl == null)
                colecaoMenu.InsertOne(mn);

        }

        private static void salvarTXT(menu mn)
        {
            string nomearquivo = System.IO.Directory.GetCurrentDirectory() + @"/menu_" + ((chavemenu)mn.chave).versaoApp + "_" + ((chavemenu)mn.chave).SO + ".json";
            System.IO.TextWriter wr = new System.IO.StreamWriter(nomearquivo);
            try
            {
                if (System.IO.File.Exists(nomearquivo))
                    System.IO.File.Delete(nomearquivo);
                wr.Write(JsonSerializer.Serialize(mn));
                wr.Flush();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                try
                {
                    wr.Close();
                }
                catch{}
            }
        }


        private static menu mocmenu()
        {
            chavemenu cm = new chavemenu();
            cm.versaoApp = "7.04";
            cm.SO = "AND";

            menu mn = new menu(cm);
            string strctn, strctnj = "";
            for (int i = 0; i < 2; i++)
            {
                strctn = i.ToString();

                menu smn = new menu(cm);
                for (int j = 0; j < 5; j++)
                {
                    strctnj = strctn + "." + j.ToString();
                    smn.items.Add(new itemmenu()
                    {
                        id = strctnj,
                        titulo = "Menu" + strctnj,
                        descricao = "Acesso para o Menu" + strctnj,
                        alerta = "0",
                        img = "img" + strctnj,
                        grupo = "0",
                        status = "2",
                        ordem = j.ToString(),
                        filhos = null,
                        funcionalidade = "interface" + strctnj
                    });

                }


                mn.items.Add(new itemmenu()
                {
                    id = strctn,
                    titulo = "Menu" + strctn,
                    descricao = "Acesso para o Menu" + strctn,
                    alerta = "0",
                    img = "img" + strctn,
                    grupo = "0",
                    status = "2",
                    ordem = strctn,
                    filhos = smn,
                    funcionalidade = "interface" + strctn
                });

            }

            return mn;
        }
         

        
    }

    //MOC
    

    public class chavemenu
    {
        public string versaoApp { get; set; }
        public string SO { get; set; }
    }
}
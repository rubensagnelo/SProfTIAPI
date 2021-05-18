using System;
using System.Collections.Generic;

namespace ragi.menu
{

    public class menu
    {

        public Guid _id { get; set; }
        public object chave { get; set; }
        public List<itemmenu> items { get; set; }

        public menu(object pchave)
        {
            chave = pchave;
            items = new List<itemmenu>();
        }

    }


    public class itemmenu
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public string img { get; set; }
        public string descricao { get; set; }
        public string status { get; set; }
        public string alerta { get; set; }
        public string ordem { get; set; }
        public string grupo { get; set; }
        public string funcionalidade { get; set; }
        public menu filhos { get; set; }
    }
}


public enum menustatus
{
    invisivel = 0,
    desabilitado =1,
    habilitado =2
}


//191.185.112.62

//  mongodb + srv://rubensagnelo:<password>@cluster0.wvsyy.mongodb.net/<dbname>?retryWrites=true&w=majority

/*
{
"id":"1",
"titulo":"Jogos"
"descricao":"Jogos do Campeonato Brasileiro",
"menustatus":"2",
"alerta":"0",
"grupo":"0",
"filhos":
}
{
'id':'1',
'titulo':'Jogos',
'descricao':"Jogos do Campeonato Brasileiro",
'menustatus':"2",
'alerta':"0",
'grupo':"0",
'filhos':
}
*/
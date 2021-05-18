using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace SProfTIAPI.Entities
{ 
    public partial class Carteirausuariodetalhado
    { 
        /// <summary>
        /// Identificador da carteira
        /// </summary>
        /// <value>Identificador da carteira</value>
        public int? IdCarteira { get; set; }

        /// <summary>
        /// Identificador da plataforma
        /// </summary>
        /// <value>Identificador da plataforma</value>
        public int? Idplataforma { get; set; }

        /// <summary>
        /// IIdentificado do usuário na plataforma retornado pela API da plataforma
        /// </summary>
        /// <value>IIdentificado do usuário na plataforma retornado pela API da plataforma</value>
        public string Idusuarioplataforma { get; set; }

        /// <summary>
        /// nome do usuáriodescrito na plataforma
        /// </summary>
        /// <value>nome do usuáriodescrito na plataforma</value>
        public string Nome { get; set; }

        /// <summary>
        /// url da imagem do avatar  (profile_image no StackOverflow e avatar_url no GitHub
        /// </summary>
        /// <value>url da imagem do avatar  (profile_image no StackOverflow e avatar_url no GitHub</value>
        public string Avatar { get; set; }

        /// <summary>
        /// e-mail do usuário da
        /// </summary>
        /// <value>e-mail do usuário da</value>
        public string Email { get; set; }

        /// <summary>
        /// valor resultante de formula que cruza alguns dados do usuários nas respectivas plataformas
        /// </summary>
        /// <value>valor resultante de formula que cruza alguns dados do usuários nas respectivas plataformas</value>
        public int? Reputacao { get; set; }

    }
}

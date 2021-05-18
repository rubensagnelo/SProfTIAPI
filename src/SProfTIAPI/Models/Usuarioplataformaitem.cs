/*
 * SProfTI API
 *
 * Seletor de Profissinais de TI API
 *
 * OpenAPI spec version: 1.0.0
 * Contact: rubensagnelo@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SProfTIAPI.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Usuarioplataformaitem : IEquatable<Usuarioplataformaitem>
    { 
        /// <summary>
        /// Identificado do usuário na plataforma retornado pela API da plataforma
        /// </summary>
        /// <value>Identificado do usuário na plataforma retornado pela API da plataforma</value>
        [Required]
        [DataMember(Name="idplataforma")]
        public int? Idplataforma { get; set; }

        /// <summary>
        /// Identificador do usuário na plataforma (user_id no StackOverflow e id no GitHub)
        /// </summary>
        /// <value>Identificador do usuário na plataforma (user_id no StackOverflow e id no GitHub)</value>
        [Required]
        [DataMember(Name="idusuarioplatafaorma")]
        public string Idusuarioplatafaorma { get; set; }

        /// <summary>
        /// nome do usuáriodescrito na plataforma
        /// </summary>
        /// <value>nome do usuáriodescrito na plataforma</value>
        [Required]
        [DataMember(Name="nome")]
        public string Nome { get; set; }

        /// <summary>
        /// url da imagem do avatar  (profile_image no StackOverflow e avatar_url no GitHub
        /// </summary>
        /// <value>url da imagem do avatar  (profile_image no StackOverflow e avatar_url no GitHub</value>
        [DataMember(Name="avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// e-mail do usuário da
        /// </summary>
        /// <value>e-mail do usuário da</value>
        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// valor resultante de formula que cruza alguns dados do usuários nas respectivas plataformas
        /// </summary>
        /// <value>valor resultante de formula que cruza alguns dados do usuários nas respectivas plataformas</value>
        [DataMember(Name="reputacao")]
        public int? Reputacao { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Usuarioplataformaitem {\n");
            sb.Append("  Idplataforma: ").Append(Idplataforma).Append("\n");
            sb.Append("  Idusuarioplatafaorma: ").Append(Idusuarioplatafaorma).Append("\n");
            sb.Append("  Nome: ").Append(Nome).Append("\n");
            sb.Append("  Avatar: ").Append(Avatar).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Reputacao: ").Append(Reputacao).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Usuarioplataformaitem)obj);
        }

        /// <summary>
        /// Returns true if Usuarioplataformaitem instances are equal
        /// </summary>
        /// <param name="other">Instance of Usuarioplataformaitem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Usuarioplataformaitem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Idplataforma == other.Idplataforma ||
                    Idplataforma != null &&
                    Idplataforma.Equals(other.Idplataforma)
                ) && 
                (
                    Idusuarioplatafaorma == other.Idusuarioplatafaorma ||
                    Idusuarioplatafaorma != null &&
                    Idusuarioplatafaorma.Equals(other.Idusuarioplatafaorma)
                ) && 
                (
                    Nome == other.Nome ||
                    Nome != null &&
                    Nome.Equals(other.Nome)
                ) && 
                (
                    Avatar == other.Avatar ||
                    Avatar != null &&
                    Avatar.Equals(other.Avatar)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Reputacao == other.Reputacao ||
                    Reputacao != null &&
                    Reputacao.Equals(other.Reputacao)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Idplataforma != null)
                    hashCode = hashCode * 59 + Idplataforma.GetHashCode();
                    if (Idusuarioplatafaorma != null)
                    hashCode = hashCode * 59 + Idusuarioplatafaorma.GetHashCode();
                    if (Nome != null)
                    hashCode = hashCode * 59 + Nome.GetHashCode();
                    if (Avatar != null)
                    hashCode = hashCode * 59 + Avatar.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Reputacao != null)
                    hashCode = hashCode * 59 + Reputacao.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Usuarioplataformaitem left, Usuarioplataformaitem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Usuarioplataformaitem left, Usuarioplataformaitem right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}

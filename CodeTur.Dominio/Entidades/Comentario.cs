using CodeTur.Comum;
using CodeTur.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Entidades
{
    public class Comentario : Base
    {
        public Comentario(string texto, string sentimento, EnStatusComentario status, Guid idUsuario, Guid idPacote)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(texto, "Texto", "Texto não pode ser vazio")
                .IsNotEmpty(sentimento, "Sentimento", "Sentimento não pode ser vazio")
                .IsNotNull(status, "Status", "Status não pode ser nulo")
                .IsNotNull(idUsuario, "IdUsuario", "Id do Usuario não pode ser nulo")
                .IsNotNull(idPacote, "IdPacote", "Id do Pacote não pode ser nulo")
            );

            if (IsValid)
            {
                Texto = texto;
                Sentimento = sentimento;
                Status = status;
                IdUsuario = idUsuario;
                IdPacote = idPacote;
            }

        }

        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }

        // Composições
        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }

        public Guid IdPacote { get; private set; }
        public Pacote Pacote { get; private set; }
    }
}

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
    public class Pacote : Base
    {
        public Pacote(string titulo, string imagem, string descricao, EnStatusPacote status)
        {

            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(titulo, "Titulo", "Titulo não pode ser vazio")
                .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazio")
                .IsNotEmpty(descricao, "Descrição", "Descrição não pode ser vazio")
                .IsNotNull(status, "Status", "Status não pode ser nulo")
            );

            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
            }

        }

        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public EnStatusPacote Status { get; private set; }


         
        // Composições
        public IReadOnlyCollection<Comentario> Comentarios { get { return _comentarios; } }

        // Para alterar os comentários, vamos precisar de uma lista de apoio
        private List<Comentario> _comentarios { get; set; }

        // O usuário pode ter somente 1 comentário em cada pacote

        public void AdicionarComentario(Comentario comentario)
        {
            if (_comentarios.Any(x => x.IdUsuario == comentario.IdUsuario))
                AddNotification("Comentário", "Este usuário já possui um comentários");

            if (IsValid)
            {
                _comentarios.Add(comentario);
            }
        }
    }
}

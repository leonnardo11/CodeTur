using CodeTur.Comum;
using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio
{
    public class Usuario : Base
    {
        public Usuario(string nome, string email,string senha, EnTipoUsuario tipoUsuario)
        {

            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                .IsEmail(email, "Email", "O formato do email está incorreto")
                .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
            );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }
            
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }

        // Composições
        public IReadOnlyCollection<Comentario> Comentarios { get; private set; }


        public void AtualizarSenha(string senha)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
            );

                if (IsValid)
                    Senha = senha;
        }

        public void AtualizarUsuario(string nome, string email)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                .IsEmail(email, "Email", "O formato do email está incorreto")
            );

                if (IsValid)
                {
                    Nome = nome;
                    Email = email;
                }
        }
    }
}

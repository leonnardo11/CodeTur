using CodeTur.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Testes
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            Usuario usuario = new Usuario(
                "Mauro",
                "mauro.cortez@gmail.com",
                "123456789",
                Comum.EnTipoUsuario.Admin
            );

            Assert.True(usuario.IsValid, "Usuario valido");
        }

        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoSemNome()
        {
            Usuario usuario = new Usuario(
                "",
                "mauro.cortez@gmail.com",
                "123456789",
                Comum.EnTipoUsuario.Admin
            );

            Assert.True(!usuario.IsValid, "Usuario invalido sem nome");
        }

        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoSemEmail()
        {
            Usuario usuario = new Usuario(
                "Mauro",
                "mauro.cortez@",
                "123456789",
                Comum.EnTipoUsuario.Admin
            );

            Assert.True(!usuario.IsValid, "Usuario invalido sem email");
        }

        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoComSenhaFraca()
        {
            Usuario usuario = new Usuario(
                "Mauro",
                "mauro.cortez@gmail.com",
                "1234",
                Comum.EnTipoUsuario.Admin
            );

            Assert.True(!usuario.IsValid, "Usuario invalido com senha fraca");
        }
    }
}

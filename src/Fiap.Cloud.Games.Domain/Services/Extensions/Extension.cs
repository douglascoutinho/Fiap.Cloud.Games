using Fiap.Cloud.Games.Domain.Entity;

namespace Fiap.Cloud.Games.Domain.Services.Extensions
{
  public static class Extension
  {
    public static bool ValidarEmail(this Usuario usuario)
    {
      var email = usuario.Email;
      if (string.IsNullOrEmpty(email))
        return false;

      return email.Contains("@") && email.Contains(".");
    }
  }
} 

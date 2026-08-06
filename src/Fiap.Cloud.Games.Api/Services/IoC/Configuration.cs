namespace Fiap.Cloud.Games.Api.Services.IoC
{
	/// <summary>
	/// Classe de configuração de IoC
	/// </summary>
	public static class Configuration
	{
		/// <summary>
		/// Registrar as dependencias dentro do motor de IoC
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <param name="secretConfiguration"></param>
		/// <returns></returns>
		public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
		{
      // Repositórios
      services.AddScoped<Domain.Repositories.IUsuarioRepository, Infra.Repositories.UsuarioRepository>();

      // Domain Services			
      services.AddScoped<Domain.Services.UsuarioService>();

			return services;
		}
	}
}

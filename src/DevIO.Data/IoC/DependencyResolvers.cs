using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Data.IoC
{
    public static class DependencyResolvers
    {
        public static IServiceCollection AddDependencyInjection( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DevIOContext>();
            services.AddDbContext<DevIOContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConexaoDB")));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            return services;
            

        }
    }
}

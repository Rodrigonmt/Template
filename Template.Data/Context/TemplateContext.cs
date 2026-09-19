using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Template.Data.Mappings;
using Template.Domain.Entities;
using Template.Data.Extensions;

namespace Template.Data.Context
{
    // Declaração da classe TemplateContext que herda de DbContext (a classe base do Entity Framework Core responsável por gerir o acesso ao banco de dados)
    public class TemplateContext : DbContext
    {
        // Construtor que recebe as opções de configuração do contexto (como a string de conexão e o provedor do banco de dados) e as passa para a classe base DbContext
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options) { }

        #region
        // Propriedade DbSet que mapeia a entidade 'User' para a tabela 'Users' no banco de dados, permitindo realizar operações de CRUD
        public DbSet<User> Users { get; set; }
        #endregion

        // Sobrescreve o método interno do EF Core que é executado durante a criação e inicialização do modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica as regras do Fluent API definidas na classe 'UserMap' (como restrições de tamanho, obrigatoriedade de campos, etc.)
            modelBuilder.ApplyConfiguration(new UserMap());

            // Executa um método de extensão personalizado para inserir dados iniciais (seeding) na base de dados
            modelBuilder.SeedDate(); // (Nota: assumindo a correção ortográfica de SeedDate para SeedData)

            // Chama a implementação base de OnModelCreating para garantir que as configurações padrão do EF Core sejam preservadas
            base.OnModelCreating(modelBuilder);
        }
    }
}

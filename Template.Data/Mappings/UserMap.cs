using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    // Declara a classe de mapeamento para a entidade User implementando a interface Fluent API do EF Core
    public class UserMap : IEntityTypeConfiguration<User>
    {
        // Método exigido pela interface para aplicar as regras de esquema do banco de dados sobre a entidade
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configura a propriedade 'Id' para ser gerada como campo obrigatório (NOT NULL)
            builder.Property(x => x.Id).IsRequired();

            // Configura a propriedade 'Name' como obrigatória (NOT NULL) e limita a coluna a no máximo 100 caracteres (nvarchar(100))
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            // Configura a propriedade 'Email' como obrigatória (NOT NULL) e limita a coluna a no máximo 100 caracteres (nvarchar(100))
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        }
    }
}

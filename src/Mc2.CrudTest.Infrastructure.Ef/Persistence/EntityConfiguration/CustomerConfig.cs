namespace Mc2.CrudTest.Infrastructure.Ef.Persistence.EntityConfiguration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class FoodConfig:DbSchemaConfig<Customer>, IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(TableName);
        builder.Property(t => t.Firstname).HasColumnType(ColumnType.Nvarchar).HasMaxLength(ColumnLength._32);
        builder.Property(t => t.Lastname).HasColumnType(ColumnType.Nvarchar).HasMaxLength(ColumnLength._64);
        builder.Property(t => t.DateOfBirth).HasColumnType(ColumnType.Datetime2);
        builder.Property(t => t.PhoneNumber).HasColumnType(ColumnType.Varchar).HasMaxLength(ColumnLength._16);
        builder.Property(t => t.Email).HasColumnType(ColumnType.Varchar).HasMaxLength(ColumnLength._32);
        builder.Property(t => t.BankAccountNumber).HasColumnType(ColumnType.Varchar).HasMaxLength(ColumnLength._32);
        
    }
}
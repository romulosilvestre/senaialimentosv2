/*Construa o LoginEntityConfig
baseado no NivelEntityConfig*/
using SenaiAlimentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SenaiAlimentos.EntityConfigs;

public class LoginEntityConfig : IEntityTypeConfiguration<Login>
{
    //me leva para o cinema
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.ToTable("Login");
        //lambda
        /*
             funcao Somar(inteiro x, inteiro y){
                retorne x+y
             }

             somar => x+y

             F#



        */

        builder.HasKey(l=>l.Id);
        /*nome - email e senha*/
        builder.Property(l=>l.Nome)
               .HasColumnType("varchar(80)")
               .IsRequired();

        builder.Property(l=>l.Email)
               .HasColumnType("varchar(60)")
               .IsRequired();
             
                 builder.Property(l=>l.Senha)
               .HasColumnType("char(8)")
               .IsRequired();
          
    }
}
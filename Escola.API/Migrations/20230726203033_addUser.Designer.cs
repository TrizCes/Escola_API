﻿// <auto-generated />
using System;
using Escola.API.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Escola.API.Migrations
{
    [DbContext(typeof(EscolaDbContexto))]
    [Migration("20230726203033_addUser")]
    partial class addUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Escola.API.Model.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("PK_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Genero")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("GENERO");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("NOME");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("SOBRENOME");

                    b.Property<string>("Telefone")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id")
                        .HasName("Pk_aluno_id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("AlunoTB", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlunoId")
                        .HasColumnType("INT")
                        .HasColumnName("Aluno_FK");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("DATE")
                        .HasColumnName("DATA");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Boletins", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("Materias", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.NotasMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BoletimId")
                        .HasColumnType("INT")
                        .HasColumnName("Boletim_ID");

                    b.Property<int>("MateriaId")
                        .HasColumnType("INT")
                        .HasColumnName("Materia_ID");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoletimId");

                    b.HasIndex("MateriaId");

                    b.ToTable("NotasMaterias", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Curso")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Curso Basico")
                        .HasColumnName("CURSO");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.ToTable("TURMA", (string)null);
                });

            modelBuilder.Entity("Escola.API.Model.Usuario", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Interno")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Login");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.HasOne("Escola.API.Model.Aluno", "Aluno")
                        .WithMany("Boletins")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Escola.API.Model.NotasMateria", b =>
                {
                    b.HasOne("Escola.API.Model.Boletim", "Boletim")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("BoletimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escola.API.Model.Materia", "Materia")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boletim");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Escola.API.Model.Aluno", b =>
                {
                    b.Navigation("Boletins");
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.Navigation("NotasMaterias");
                });

            modelBuilder.Entity("Escola.API.Model.Materia", b =>
                {
                    b.Navigation("NotasMaterias");
                });
#pragma warning restore 612, 618
        }
    }
}

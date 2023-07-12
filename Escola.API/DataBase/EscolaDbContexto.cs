using Microsoft.EntityFrameworkCore;
using Escola.API.Model;


namespace Escola.API.DataBase
{
    public class EscolaDbContexto : DbContext
    {
        public virtual DbSet<Aluno> Alunos { get; set; }

        public virtual DbSet<Turma> Turmas { get; set; }

        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Boletim> Boletins { get; set; }
        public virtual DbSet<NotasMateria> NotasMaterias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Escola-API;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("AlunoTB");

            modelBuilder.Entity<Aluno>().HasKey(x => x.Id)
                                        .HasName("Pk_aluno_id");

            modelBuilder.Entity<Aluno>().Property(x => x.Id)
                                        .HasColumnName("PK_ID")
                                        .HasColumnType("INT");

            modelBuilder.Entity<Aluno>().Property(x => x.Nome)
                                        .IsRequired()
                                        .HasColumnName("NOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);

            modelBuilder.Entity<Aluno>().Property(x => x.Sobrenome)
                                        .IsRequired()
                                        .HasColumnName("SOBRENOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(150);

            modelBuilder.Entity<Aluno>().Property(x => x.Idade)
                                        .HasDefaultValue(null);

            modelBuilder.Entity<Aluno>().Property(x => x.Email)
                                        .IsRequired()
                                        .HasColumnName("EMAIL")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);


            modelBuilder.Entity<Aluno>().HasIndex(x => x.Email)
                                        .IsUnique();

            modelBuilder.Entity<Aluno>().Property(x => x.Genero)
                                        .HasColumnName("GENERO")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(20);

            modelBuilder.Entity<Aluno>().Property(x => x.Telefone)
                                        .HasColumnName("TELEFONE")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(30);

            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento)
                                        .HasColumnName("DATA_NASCIMENTO")
                                        .HasColumnType("datetime2");


            modelBuilder.Entity<Turma>().ToTable("TURMA");

            modelBuilder.Entity<Turma>().Property(x => x.Id)
                                        .HasColumnType("int")
                                        .HasColumnName("ID");

            modelBuilder.Entity<Turma>().HasKey(x => x.Id);


            modelBuilder.Entity<Turma>().Property(x => x.Curso)
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasDefaultValue("Curso Basico")
                            .HasColumnName("CURSO");

            modelBuilder.Entity<Turma>().Property(x => x.Nome)
                            .HasColumnType("varchar")
                            .HasMaxLength(50)
                            .HasColumnName("Nome");

            modelBuilder.Entity<Turma>().HasIndex(x => x.Nome)
                                        .IsUnique();

            modelBuilder.Entity<Materia>().ToTable("Materias");

            modelBuilder.Entity<Materia>().HasKey(x => x.Id);

            modelBuilder.Entity<Materia>().Property(x => x.Id)
                                        .HasColumnName("ID")
                                        .HasColumnType("INT");

            modelBuilder.Entity<Materia>().Property(x => x.Nome)
                                        .IsRequired()
                                        .HasColumnName("NOME")
                                        .HasColumnType("VARCHAR")
                                        .HasMaxLength(50);

            modelBuilder.Entity<Boletim>().ToTable("Boletins");

            modelBuilder.Entity<Boletim>().Property(x => x.Id)
                                        .HasColumnName("ID")
                                        .HasColumnType("INT");

            modelBuilder.Entity<Boletim>().HasKey(x => x.Id);

            modelBuilder.Entity<Boletim>().Property(x => x.DateTime)
                                        .IsRequired()
                                        .HasColumnName("DATA")
                                        .HasColumnType("DATE");

            modelBuilder.Entity<Boletim>().Property(x => x.AlunoId)
                                        .IsRequired()
                                        .HasColumnName("Aluno_FK")
                                        .HasColumnType("INT");

            modelBuilder.Entity<Boletim>().HasOne(x => x.Aluno)
                                        .WithMany(x => x.Boletins)
                                        .HasForeignKey(x => x.AlunoId)
                                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NotasMateria>().ToTable("NotasMaterias");

            modelBuilder.Entity<NotasMateria>().Property(x => x.Id)
                                        .HasColumnName("ID")
                                        .HasColumnType("INT");

            modelBuilder.Entity<NotasMateria>().HasKey(x => x.Id);

            modelBuilder.Entity<NotasMateria>().Property(x => x.BoletimId)
                                        .IsRequired()
                                        .HasColumnName("Boletim_ID")
                                        .HasColumnType("INT");

            modelBuilder.Entity<NotasMateria>().HasOne(x => x.Boletim)
                                        .WithMany(x => x.NotasMaterias)
                                        .HasForeignKey(x => x.BoletimId)
                                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NotasMateria>().Property(x => x.MateriaId)
                                        .IsRequired()
                                        .HasColumnName("Materia_ID")
                                        .HasColumnType("INT");

            modelBuilder.Entity<NotasMateria>().HasOne(x => x.Materia)
                                        .WithMany(x => x.NotasMaterias)
                                        .HasForeignKey(x => x.MateriaId)
                                        .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

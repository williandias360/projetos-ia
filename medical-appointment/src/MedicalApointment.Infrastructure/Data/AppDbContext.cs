using System;
using MedicalApointment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalApointment.Infrastructure.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<Agendamento> Agendamentos => Set<Agendamento>();
  public DbSet<Paciente> Pacientes => Set<Paciente>();
  public DbSet<Medico> Medicos => Set<Medico>();
  public DbSet<Especialidade> Especialidades => Set<Especialidade>();
  public DbSet<MedicoEspecialidade> MedicoEspecialidades => Set<MedicoEspecialidade>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    //Habilitar a extensão PgVector 
    modelBuilder.HasPostgresExtension("vector");

    modelBuilder.Entity<Medico>(builder =>
    {
      builder.ToTable("medicos");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Id)
      .HasColumnName("id_medico")
      .ValueGeneratedOnAdd();

      builder.Property(c => c.Nome)
      .HasColumnName("nome")
      .HasMaxLength(100)
      .IsRequired();

    });

    modelBuilder.Entity<Especialidade>(builder =>
    {
      builder.ToTable("especialidades");

      builder.HasKey(c => c.Id);

      builder.Property(c => c.Id)
      .HasColumnName("id_especialidade")
      .ValueGeneratedOnAdd();

      builder.Property(c => c.Descricao)
      .HasColumnName("descricao")
      .HasMaxLength(350)
      .IsRequired();

      builder.Property(c => c.Ativo)
      .HasColumnName("ativo")
      .HasColumnType("boolean")
      .HasDefaultValue(true);
    });

    modelBuilder.Entity<Paciente>(builder =>
    {
      builder.ToTable("pacientes");
      builder.HasKey(c => c.Id);

      builder.Property(c => c.Id)
      .HasColumnName("id_paciente")
      .ValueGeneratedOnAdd();

      builder.Property(c => c.Nome)
      .HasColumnName("nome")
      .HasMaxLength(250)
      .IsRequired();
    });

    modelBuilder.Entity<Agendamento>(builder =>
    {
      builder.ToTable("agendamentos");
      builder.HasKey(c => c.Id);

      builder.Property(c => c.Id)
      .HasColumnName("id_agendamento")
      .ValueGeneratedOnAdd();

      builder.Property(c => c.Motivo)
      .HasColumnName("motivo")
      .HasMaxLength(500)
      .IsRequired();

      builder.Property(c => c.DataHora)
      .HasColumnName("data_hora")
      .HasColumnType("timestamp with time zone")
      .IsRequired();

      builder.Property(c => c.MedicoId)
      .HasColumnName("id_medico")
      .IsRequired();

      builder.Property(c => c.PacienteId)
      .HasColumnName("id_paciente")
      .IsRequired();

      builder.HasOne(c => c.Medico)
      .WithMany(p => p.Agendamentos)
      .HasForeignKey(a => a.MedicoId)
      .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(c => c.Paciente)
      .WithMany(p => p.Agendamentos)
      .HasForeignKey(a => a.PacienteId)
      .OnDelete(DeleteBehavior.Restrict);
    });

    modelBuilder.Entity<MedicoEspecialidade>(builder =>
    {
      builder.ToTable("medicos_especialidades");
      builder.HasKey(c => new { c.EspecialidadeId, c.MedicoId });

      builder.Property(c => c.EspecialidadeId)
      .HasColumnName("id_especialidade")
      .IsRequired();

      builder.Property(c => c.MedicoId)
      .HasColumnName("id_medico")
      .IsRequired();

      builder.Property(c => c.DataCriacao)
      .HasColumnName("data_criacao")
      .HasColumnType("timestamp")
      .HasDefaultValueSql("NOW()");

      builder.HasOne(a => a.Especialidade)
      .WithMany(a => a.MedicoEspecialidades)
      .HasForeignKey(a => a.EspecialidadeId)
      .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(a => a.Medico)
      .WithMany(a => a.MedicoEspecialidades)
      .HasForeignKey(a => a.MedicoId)
      .OnDelete(DeleteBehavior.Restrict);
    });

    modelBuilder.Entity<Especialidade>().HasData(
      new Especialidade
      {
        Id = 1,
        Descricao = "Cardiologista",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 2,
        Descricao = "Urologista",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 3,
        Descricao = "Pediatra",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 4,
        Descricao = "Neurologista",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 5,
        Descricao = "Neurocirurgião",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 6,
        Descricao = "Ortopedista e Traumotologia",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 7,
        Descricao = "Ginecologia e Obstretícia",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 8,
        Descricao = "Nefrologista",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 9,
        Descricao = "Anestesiologia",
        Ativo = true,
      },
      new Especialidade
      {
        Id = 10,
        Descricao = "Clinico Geral",
        Ativo = true,
      }
    );

    modelBuilder.Entity<Medico>().HasData(
          new Medico
          {
            Id = 1,
            Nome = "Camila Oliveira Santos",
          },
          new Medico
          {
            Id = 2,
            Nome = "Thiago Rezende Costa",
          },
          new Medico
          {
            Id = 3,
            Nome = "Mariana Frota Albuquerque",
          },
          new Medico
          {
            Id = 4,
            Nome = "Rodrigo Pires Nogueira",
          },
          new Medico
          {
            Id = 5,
            Nome = "Letícia Dornelles Schivittz"
          }
        );

    modelBuilder.Entity<MedicoEspecialidade>().HasData(
      new MedicoEspecialidade
      {
        MedicoId = 1,
        EspecialidadeId = 1,
      },
      new MedicoEspecialidade
      {
        MedicoId = 2,
        EspecialidadeId = 2,
      },
      new MedicoEspecialidade
      {
        MedicoId = 3,
        EspecialidadeId = 3,
      },
      new MedicoEspecialidade
      {
        MedicoId = 4,
        EspecialidadeId = 4,
      },
      new MedicoEspecialidade
      {
        MedicoId = 5,
        EspecialidadeId = 5,
      }
    );

    modelBuilder.Entity<Paciente>().HasData(
      new Paciente
      {
        Id = 1,
        Nome = "Bruno Medeiros Viera",
      },
      new Paciente
      {
        Id = 2,
        Nome = "Larissa Couto Fagundes",
      },
      new Paciente
      {
        Id = 3,
        Nome = "Felipe Fontana Castro",
      },
      new Paciente
      {
        Id = 4,
        Nome = "Beatriz Vasconcelos Lima",
      },
      new Paciente
      {
        Id = 5,
        Nome = "Gabriel Silveira Antunes"
      },
      new Paciente
      {
        Id = 6,
        Nome = "Amanda Prestes Guimarães",
      },
      new Paciente
      {
        Id = 7,
        Nome = "Ricardo Junqueira Neto",
      },
      new Paciente
      {
        Id = 8,
        Nome = "Juliana Meirels Rocha",
      },
      new Paciente
      {
        Id = 9,
        Nome = "Matheus Albuquerque Lins"
      },
      new Paciente
      {
        Id = 10,
        Nome = "Carolina Viana Dornelles"
      }
    );

    modelBuilder.Entity<Agendamento>().HasData(
      new Agendamento
      {
        Id = 1,
        MedicoId = 1,
        PacienteId = 2,
        Motivo = "Rotina",
        DataHora = new DateTime(2026, 10, 22, 08, 30, 00),
      },
      new Agendamento
      {
        Id = 2,
        MedicoId = 1,
        PacienteId = 3,
        Motivo = "Retorno",
        DataHora = new DateTime(2026, 10, 22, 09, 00, 00),
      },
      new Agendamento
      {
        Id = 3,
        MedicoId = 2,
        PacienteId = 1,
        Motivo = "Rotina",
        DataHora = new DateTime(2026, 10, 22, 09, 00, 00),
      },
      new Agendamento
      {
        Id = 4,
        MedicoId = 2,
        PacienteId = 4,
        Motivo = "Rotina",
        DataHora = new DateTime(2026, 10, 23, 10, 00, 00),
      }
    );
  }
}

﻿using Microsoft.EntityFrameworkCore;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp.Model
{
    public partial class ExercicesMonstersContext : DbContext
    {
        private readonly string _databaseLink;

        public ExercicesMonstersContext(string databaseLink)
        {
            _databaseLink = databaseLink;
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Spell> Spells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (string.IsNullOrEmpty(_databaseLink))
                {
                    throw new InvalidOperationException("La chaîne de connexion à la base de données n'a pas été fournie.");
                }

                try
                {
                    optionsBuilder.UseSqlServer(_databaseLink);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Erreur lors de la configuration de la base de données : {ex.Message}", ex);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Login__3214EC27804DEAE8");

                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.PasswordHash).HasMaxLength(255);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Monster__3214EC27BB242AEB");

                entity.ToTable("Monster");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasMany(d => d.Spells).WithMany(p => p.Monsters)
                    .UsingEntity<Dictionary<string, object>>(
                        "MonsterSpell",
                        r => r.HasOne<Spell>().WithMany()
                            .HasForeignKey("SpellId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__MonsterSp__Spell__31EC6D26"),
                        l => l.HasOne<Monster>().WithMany()
                            .HasForeignKey("MonsterId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__MonsterSp__Monst__30F848ED"),
                        j =>
                        {
                            j.HasKey("MonsterId", "SpellId").HasName("PK__MonsterS__293EA4DF755E98D4");
                            j.ToTable("MonsterSpell");
                            j.IndexerProperty<int>("MonsterId").HasColumnName("MonsterID");
                            j.IndexerProperty<int>("SpellId").HasColumnName("SpellID");
                        });
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Player__3214EC273133B135");

                entity.ToTable("Player");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.LoginId).HasColumnName("LoginID");
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Login).WithMany(p => p.Players)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Player__LoginID__267ABA7A");

                entity.HasMany(d => d.Monsters).WithMany(p => p.Players)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlayerMonster",
                        r => r.HasOne<Monster>().WithMany()
                            .HasForeignKey("MonsterId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__PlayerMon__Monst__2E1BDC42"),
                        l => l.HasOne<Player>().WithMany()
                            .HasForeignKey("PlayerId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__PlayerMon__Playe__2D27B809"),
                        j =>
                        {
                            j.HasKey("PlayerId", "MonsterId").HasName("PK__PlayerMo__378F20A45278DED8");
                            j.ToTable("PlayerMonster");
                            j.IndexerProperty<int>("PlayerId").HasColumnName("PlayerID");
                            j.IndexerProperty<int>("MonsterId").HasColumnName("MonsterID");
                        });
            });

            modelBuilder.Entity<Spell>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Spell__3214EC27C6F0E7A3");

                entity.ToTable("Spell");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
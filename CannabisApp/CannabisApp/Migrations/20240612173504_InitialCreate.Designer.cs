﻿// <auto-generated />
using System;
using CannabisApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CannabisApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240612173504_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CannabisApp.historique_plantes", b =>
                {
                    b.Property<int>("id_historique")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_historique"), 1L, 1);

                    b.Property<string>("action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_plante")
                        .HasColumnType("int");

                    b.Property<int>("id_utilisateur")
                        .HasColumnType("int");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("id_historique");

                    b.HasIndex("id_plante");

                    b.HasIndex("id_utilisateur");

                    b.ToTable("historique_plantes");
                });

            modelBuilder.Entity("CannabisApp.inventaire", b =>
                {
                    b.Property<int>("id_inventaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_inventaire"), 1L, 1);

                    b.Property<int>("derniere_verification")
                        .HasColumnType("int");

                    b.Property<int>("id_plante")
                        .HasColumnType("int");

                    b.Property<int>("quantite")
                        .HasColumnType("int");

                    b.HasKey("id_inventaire");

                    b.HasIndex("id_plante");

                    b.ToTable("inventaire");
                });

            modelBuilder.Entity("CannabisApp.plantes", b =>
                {
                    b.Property<int>("id_plante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_plante"), 1L, 1);

                    b.Property<string>("code_qr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("cree_le")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("emplacement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("etat_sante")
                        .HasColumnType("int");

                    b.Property<int>("id_provenance")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nombre_plantes_actives")
                        .HasColumnType("int");

                    b.HasKey("id_plante");

                    b.HasIndex("id_provenance");

                    b.ToTable("plantes");
                });

            modelBuilder.Entity("CannabisApp.provenances", b =>
                {
                    b.Property<int>("id_provenance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_provenance"), 1L, 1);

                    b.Property<string>("pays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_provenance");

                    b.ToTable("provenances");
                });

            modelBuilder.Entity("CannabisApp.roles", b =>
                {
                    b.Property<int>("id_role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_role"), 1L, 1);

                    b.Property<string>("nom_role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_role");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("CannabisApp.utilisateur", b =>
                {
                    b.Property<int>("id_utilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_utilisateur"), 1L, 1);

                    b.Property<int>("id_role")
                        .HasColumnType("int");

                    b.Property<string>("mot_de_passe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom_utilisateur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_utilisateur");

                    b.HasIndex("id_role");

                    b.ToTable("utilisateurs");
                });

            modelBuilder.Entity("CannabisApp.historique_plantes", b =>
                {
                    b.HasOne("CannabisApp.plantes", null)
                        .WithMany()
                        .HasForeignKey("id_plante")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CannabisApp.utilisateur", null)
                        .WithMany()
                        .HasForeignKey("id_utilisateur")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CannabisApp.inventaire", b =>
                {
                    b.HasOne("CannabisApp.plantes", null)
                        .WithMany()
                        .HasForeignKey("id_plante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CannabisApp.plantes", b =>
                {
                    b.HasOne("CannabisApp.provenances", null)
                        .WithMany()
                        .HasForeignKey("id_provenance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CannabisApp.utilisateur", b =>
                {
                    b.HasOne("CannabisApp.roles", null)
                        .WithMany()
                        .HasForeignKey("id_role")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

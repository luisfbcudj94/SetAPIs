﻿// <auto-generated />
using System;
using API.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240325202117_fix-columnHttpMethod")]
    partial class fixcolumnHttpMethod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Domain.Models.API", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApiTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApiTypeId");

                    b.ToTable("APIs");
                });

            modelBuilder.Entity("API.Domain.Models.APIType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("APITypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("62ffbd2a-30f3-4e8e-bb8e-774a7d95e924"),
                            Name = "GRAPHQL"
                        },
                        new
                        {
                            Id = new Guid("8028a4d9-53cf-4a23-bb5c-949b0a2a5806"),
                            Name = "SOAP"
                        },
                        new
                        {
                            Id = new Guid("d09b4952-47c8-4c9d-a39a-d3d57643c02b"),
                            Name = "REST"
                        });
                });

            modelBuilder.Entity("API.Domain.Models.Body", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("API.Domain.Models.BodyTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BodyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("TagId");

                    b.ToTable("BodyTags");
                });

            modelBuilder.Entity("API.Domain.Models.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BodyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UrlId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApiId")
                        .IsUnique();

                    b.HasIndex("BodyId");

                    b.HasIndex("UrlId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("API.Domain.Models.HTTPMethods", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HTTPMethods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("587e4311-f39f-4c0e-b909-81f7f4571d7b"),
                            Name = "GET"
                        },
                        new
                        {
                            Id = new Guid("a05fd283-d09d-45b1-8f67-9832c4e21e0f"),
                            Name = "POST"
                        },
                        new
                        {
                            Id = new Guid("c1acbd7a-8d8d-4f5d-bb72-6d6b0f7939b1"),
                            Name = "PUT"
                        },
                        new
                        {
                            Id = new Guid("9b0f3a02-12a6-4b1f-bc48-1e631b79c2fd"),
                            Name = "PATCH"
                        },
                        new
                        {
                            Id = new Guid("f2fc5b6c-8ab7-49e0-ae56-733c889b45c6"),
                            Name = "DELETE"
                        });
                });

            modelBuilder.Entity("API.Domain.Models.Header", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConfigurationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Headers");
                });

            modelBuilder.Entity("API.Domain.Models.HeaderTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.HasIndex("TagId");

                    b.ToTable("HeaderTags");
                });

            modelBuilder.Entity("API.Domain.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("API.Domain.Models.URL", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HTTPMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HTTPMethodId");

                    b.ToTable("URLs");
                });

            modelBuilder.Entity("API.Domain.Models.URLTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UrlId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UrlId");

                    b.ToTable("URLTags");
                });

            modelBuilder.Entity("API.Domain.Models.API", b =>
                {
                    b.HasOne("API.Domain.Models.APIType", "APIType")
                        .WithMany()
                        .HasForeignKey("ApiTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("APIType");
                });

            modelBuilder.Entity("API.Domain.Models.BodyTag", b =>
                {
                    b.HasOne("API.Domain.Models.Body", null)
                        .WithMany("BodyTag")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("API.Domain.Models.Configuration", b =>
                {
                    b.HasOne("API.Domain.Models.API", null)
                        .WithOne("Configuration")
                        .HasForeignKey("API.Domain.Models.Configuration", "ApiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.Body", "Body")
                        .WithMany()
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.URL", "URL")
                        .WithMany()
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("URL");
                });

            modelBuilder.Entity("API.Domain.Models.Header", b =>
                {
                    b.HasOne("API.Domain.Models.Configuration", null)
                        .WithMany("Header")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Domain.Models.HeaderTag", b =>
                {
                    b.HasOne("API.Domain.Models.Header", null)
                        .WithMany("HeaderTag")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.Tag", "Tags")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("API.Domain.Models.URL", b =>
                {
                    b.HasOne("API.Domain.Models.HTTPMethods", "HttpMethod")
                        .WithMany()
                        .HasForeignKey("HTTPMethodId");

                    b.Navigation("HttpMethod");
                });

            modelBuilder.Entity("API.Domain.Models.URLTag", b =>
                {
                    b.HasOne("API.Domain.Models.Tag", "Tags")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Domain.Models.URL", null)
                        .WithMany("URLTag")
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("API.Domain.Models.API", b =>
                {
                    b.Navigation("Configuration")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Domain.Models.Body", b =>
                {
                    b.Navigation("BodyTag");
                });

            modelBuilder.Entity("API.Domain.Models.Configuration", b =>
                {
                    b.Navigation("Header");
                });

            modelBuilder.Entity("API.Domain.Models.Header", b =>
                {
                    b.Navigation("HeaderTag");
                });

            modelBuilder.Entity("API.Domain.Models.URL", b =>
                {
                    b.Navigation("URLTag");
                });
#pragma warning restore 612, 618
        }
    }
}

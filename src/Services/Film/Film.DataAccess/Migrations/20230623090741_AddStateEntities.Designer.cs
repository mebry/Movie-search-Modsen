﻿// <auto-generated />
using System;
using Film.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Film.DataAccess.Migrations
{
    [DbContext(typeof(FilmContext))]
    [Migration("20230623090741_AddStateEntities")]
    partial class AddStateEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Film.DataAccess.Entities.AgeRestriction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AgeRestrictions", t =>
                        {
                            t.HasCheckConstraint("Age", "Age > 0 AND Age <= 30");
                        });
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmCountry", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "CountryId");

                    b.ToTable("FilmCountries");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmGenre", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgeRestrictionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<int>("CountScores")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("PosterURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AgeRestrictionId");

                    b.HasIndex("AverageRating")
                        .HasFilter("[AverageRating] > 0");

                    b.HasIndex("CountScores")
                        .HasFilter("[CountScores] > 0");

                    b.HasIndex("ReleaseDate");

                    b.HasIndex("Title");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmTag", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("FilmTags");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.StaffPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Surname");

                    b.ToTable("StaffPersons");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.StaffPersonPosition", b =>
                {
                    b.Property<Guid>("FilmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StaffPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilmId", "StaffPersonId", "PositionId");

                    b.HasIndex("PositionId");

                    b.HasIndex("StaffPersonId");

                    b.ToTable("StaffPersonPositions");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.InboxState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Consumed")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReceiveCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Received")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasAlternateKey("MessageId", "ConsumerId");

                    b.HasIndex("Delivered");

                    b.ToTable("InboxState");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.Property<long>("SequenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SequenceNumber"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DestinationAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("EnqueueTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FaultAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Headers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InboxConsumerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InboxMessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OutboxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResponseAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourceAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("SequenceNumber");

                    b.HasIndex("EnqueueTime");

                    b.HasIndex("ExpirationTime");

                    b.HasIndex("OutboxId", "SequenceNumber")
                        .IsUnique()
                        .HasFilter("[OutboxId] IS NOT NULL");

                    b.HasIndex("InboxMessageId", "InboxConsumerId", "SequenceNumber")
                        .IsUnique()
                        .HasFilter("[InboxMessageId] IS NOT NULL AND [InboxConsumerId] IS NOT NULL");

                    b.ToTable("OutboxMessage");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxState", b =>
                {
                    b.Property<Guid>("OutboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("OutboxId");

                    b.HasIndex("Created");

                    b.ToTable("OutboxState");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmCountry", b =>
                {
                    b.HasOne("Film.DataAccess.Entities.FilmModel", "Film")
                        .WithMany("FilmCountries")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmGenre", b =>
                {
                    b.HasOne("Film.DataAccess.Entities.FilmModel", "Film")
                        .WithMany("FilmGenres")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film.DataAccess.Entities.Genre", "Genre")
                        .WithMany("FilmGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmModel", b =>
                {
                    b.HasOne("Film.DataAccess.Entities.AgeRestriction", "AgeRestriction")
                        .WithMany("Films")
                        .HasForeignKey("AgeRestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeRestriction");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmTag", b =>
                {
                    b.HasOne("Film.DataAccess.Entities.FilmModel", "Film")
                        .WithMany("FilmTags")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film.DataAccess.Entities.Tag", "Tag")
                        .WithMany("FilmTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.StaffPersonPosition", b =>
                {
                    b.HasOne("Film.DataAccess.Entities.FilmModel", "Film")
                        .WithMany("StaffPersonPositions")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film.DataAccess.Entities.Position", "Position")
                        .WithMany("StaffPersonPositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Film.DataAccess.Entities.StaffPerson", "StaffPerson")
                        .WithMany("StaffPersonPositions")
                        .HasForeignKey("StaffPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Position");

                    b.Navigation("StaffPerson");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.AgeRestriction", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.FilmModel", b =>
                {
                    b.Navigation("FilmCountries");

                    b.Navigation("FilmGenres");

                    b.Navigation("FilmTags");

                    b.Navigation("StaffPersonPositions");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.Genre", b =>
                {
                    b.Navigation("FilmGenres");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.Position", b =>
                {
                    b.Navigation("StaffPersonPositions");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.StaffPerson", b =>
                {
                    b.Navigation("StaffPersonPositions");
                });

            modelBuilder.Entity("Film.DataAccess.Entities.Tag", b =>
                {
                    b.Navigation("FilmTags");
                });
#pragma warning restore 612, 618
        }
    }
}
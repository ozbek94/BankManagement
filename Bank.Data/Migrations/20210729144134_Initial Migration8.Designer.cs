﻿// <auto-generated />
using System;
using Bank.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bank.Data.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20210729144134_Initial Migration8")]
    partial class InitialMigration8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Bank.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AccountNumber")
                        .HasColumnType("text");

                    b.Property<int>("Balance")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Bank.Domain.Entities.AccountTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<double>("Credit")
                        .HasColumnType("double precision");

                    b.Property<double>("Debit")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsCheckconfirmation")
                        .HasColumnType("boolean");

                    b.Property<int>("PartyId")
                        .HasColumnType("integer");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uuid");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionTypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AccountTransaction");
                });

            modelBuilder.Entity("Bank.Domain.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<int>("CityNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Bank.Domain.Entities.CommissionCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("ComissionAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CommissionCases");
                });

            modelBuilder.Entity("Bank.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NationalId")
                        .HasMaxLength(11)
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Bank.Domain.Entities.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<Guid>("AccountTransactionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("BankId")
                        .HasColumnType("integer");

                    b.Property<string>("BankName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CompletionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("IBAN")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PartyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("Bank.Domain.Entities.Gsm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("GsmNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Gsms");
                });

            modelBuilder.Entity("Bank.Domain.Entities.TransactionLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TransferTypeLimit")
                        .HasColumnType("integer");

                    b.Property<string>("TransferTypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransactionLimits");
                });

            modelBuilder.Entity("Bank.Domain.Entities.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("Bank.Domain.Entities.Account", b =>
                {
                    b.HasOne("Bank.Domain.Entities.Customer", null)
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.Domain.Entities.Adress", b =>
                {
                    b.HasOne("Bank.Domain.Entities.Customer", null)
                        .WithMany("Adresses")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Bank.Domain.Entities.Gsm", b =>
                {
                    b.HasOne("Bank.Domain.Entities.Customer", null)
                        .WithMany("Gsms")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bank.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Adresses");

                    b.Navigation("Gsms");
                });
#pragma warning restore 612, 618
        }
    }
}

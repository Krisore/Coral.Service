﻿// <auto-generated />
using System;
using Coral.Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coral.Service.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519065008_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Coral.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Accounts", "finance");
                });

            modelBuilder.Entity("Coral.Domain.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes", "utility");
                });

            modelBuilder.Entity("Coral.Domain.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18, 6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("Budgets", "finance");
                });

            modelBuilder.Entity("Coral.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", "utility");
                });

            modelBuilder.Entity("Coral.Domain.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18, 6)");

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses", "finance");
                });

            modelBuilder.Entity("Coral.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags", "utility");
                });

            modelBuilder.Entity("Coral.Domain.Account", b =>
                {
                    b.HasOne("Coral.Domain.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Coral.Domain.Balance", "Balance", b1 =>
                        {
                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18, 6)");

                            b1.Property<int>("Id")
                                .HasColumnType("int")
                                .HasColumnName("BalanceId");

                            b1.HasKey("AccountId");

                            b1.ToTable("Balances", "finance");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("AccountType");

                    b.Navigation("Balance")
                        .IsRequired();
                });

            modelBuilder.Entity("Coral.Domain.Budget", b =>
                {
                    b.HasOne("Coral.Domain.Tag", "BudgetTag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetTag");
                });

            modelBuilder.Entity("Coral.Domain.Expense", b =>
                {
                    b.HasOne("Coral.Domain.Account", "Account")
                        .WithMany("Expenses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coral.Domain.Budget", "Budget")
                        .WithMany("Expenses")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coral.Domain.Category", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Budget");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Coral.Domain.Account", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Coral.Domain.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Coral.Domain.Budget", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Coral.Domain.Category", b =>
                {
                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}

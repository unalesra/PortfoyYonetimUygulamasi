﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Contexts;

namespace PortfoyYonetimUygulamasi.Data.Migrations
{
    [DbContext(typeof(PortfoyYonetimUygulamasiContext))]
    [Migration("20211215192457_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoinWallet", b =>
                {
                    b.Property<int>("CoinsId")
                        .HasColumnType("int");

                    b.Property<int>("WalletsId")
                        .HasColumnType("int");

                    b.HasKey("CoinsId", "WalletsId");

                    b.HasIndex("WalletsId");

                    b.ToTable("CoinWallet");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoinName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PortfolioName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CoinId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<double>("TransactionPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CoinId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountOfCoin")
                        .HasColumnType("float");

                    b.Property<double>("AvarageBuyPrice")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<double>("TotalWealth")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("CoinWallet", b =>
                {
                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.Coin", null)
                        .WithMany()
                        .HasForeignKey("CoinsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.Wallet", null)
                        .WithMany()
                        .HasForeignKey("WalletsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Portfolio", b =>
                {
                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Transaction", b =>
                {
                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.Coin", "Coin")
                        .WithMany("Transactions")
                        .HasForeignKey("CoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.Portfolio", "Portfolio")
                        .WithMany("Transactions")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coin");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.TransactionType", b =>
                {
                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.Transaction", "Transaction")
                        .WithOne("TransactionType")
                        .HasForeignKey("PortfoyYonetimUygulamasi.Entity.Concrete.TransactionType", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Wallet", b =>
                {
                    b.HasOne("PortfoyYonetimUygulamasi.Entity.Concrete.Portfolio", "Portfolio")
                        .WithOne("Wallet")
                        .HasForeignKey("PortfoyYonetimUygulamasi.Entity.Concrete.Wallet", "PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Coin", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Portfolio", b =>
                {
                    b.Navigation("Transactions");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.Transaction", b =>
                {
                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("PortfoyYonetimUygulamasi.Entity.Concrete.User", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}

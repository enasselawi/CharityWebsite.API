using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CharityWebsite.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bankaccount> Bankaccounts { get; set; } = null!;
        public virtual DbSet<Charity> Charities { get; set; } = null!;
        public virtual DbSet<Charitycategory> Charitycategories { get; set; } = null!;
        public virtual DbSet<ContactMessage> ContactMessages { get; set; } = null!;
        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<DonationHistory> DonationHistories { get; set; } = null!;
        public virtual DbSet<Donationform> Donationforms { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Problemreport> Problemreports { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Userr> Userrs { get; set; } = null!;
        public virtual DbSet<Visacard> Visacards { get; set; } = null!;
        public virtual DbSet<Website> Websites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##Enas2001;PASSWORD=2001;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##ENAS2001")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Bankaccount>(entity =>
            {
                entity.HasKey(e => e.Bankid)
                    .HasName("SYS_C008601");

                entity.ToTable("BANKACCOUNT");

                entity.Property(e => e.Bankid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BANKID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Websiteid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITEID");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Bankaccounts)
                    .HasForeignKey(d => d.Charityid)
                    .HasConstraintName("FK_CHARITYBANK");

                entity.HasOne(d => d.Website)
                    .WithMany(p => p.Bankaccounts)
                    .HasForeignKey(d => d.Websiteid)
                    .HasConstraintName("FK_WEBBANK");
            });

            modelBuilder.Entity<Charity>(entity =>
            {
                entity.ToTable("CHARITY");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Charitycategoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYCATEGORYID");

                entity.Property(e => e.Charitydescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CHARITYDESCRIPTION");

                entity.Property(e => e.Charityname)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CHARITYNAME");

                entity.Property(e => e.Dateadded)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEADDED");

                entity.Property(e => e.Goals)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("GOALS");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Mission)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("MISSION");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Charitycategory)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.Charitycategoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CATEGORYCHARITY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERCHARITY");
            });

            modelBuilder.Entity<Charitycategory>(entity =>
            {
                entity.ToTable("CHARITYCATEGORY");

                entity.Property(e => e.Charitycategoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHARITYCATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<ContactMessage>(entity =>
            {
                entity.HasKey(e => e.Messageid)
                    .HasName("SYS_C008644");

                entity.ToTable("CONTACT_MESSAGES");

                entity.Property(e => e.Messageid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MESSAGEID");

                entity.Property(e => e.Datesubmitted)
                    .HasColumnType("DATE")
                    .HasColumnName("DATESUBMITTED")
                    .HasDefaultValueSql("SYSDATE\n");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Messagecontent)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGECONTENT");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.ToTable("DONATION");

                entity.Property(e => e.Donationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DONATIONID");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Donationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DONATIONDATE");

                entity.Property(e => e.Donationformid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DONATIONFORMID");

                entity.Property(e => e.Donationtype)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DONATIONTYPE");

                entity.Property(e => e.Transactionstatus)
                    .HasColumnType("DATE")
                    .HasColumnName("TRANSACTIONSTATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Donationform)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.Donationformid)
                    .HasConstraintName("FK_DONFORM");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERDON");
            });

            modelBuilder.Entity<DonationHistory>(entity =>
            {
                entity.HasKey(e => e.Donationid)
                    .HasName("SYS_C008636");

                entity.ToTable("DONATION_HISTORY");

                entity.Property(e => e.Donationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DONATIONID");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Donationamount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DONATIONAMOUNT");

                entity.Property(e => e.Donationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DONATIONDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Donationtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DONATIONTYPE")
                    .HasDefaultValueSql("'Money'");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.DonationHistories)
                    .HasForeignKey(d => d.Charityid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C008638");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DonationHistories)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C008637");
            });

            modelBuilder.Entity<Donationform>(entity =>
            {
                entity.ToTable("DONATIONFORM");

                entity.Property(e => e.Donationformid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DONATIONFORMID");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Objectname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OBJECTNAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICE");

                entity.Property(e => e.Invoiceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INVOICEID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Datesent)
                    .HasColumnType("DATE")
                    .HasColumnName("DATESENT");

                entity.Property(e => e.Emailsent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAILSENT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERINV");
            });

            modelBuilder.Entity<Problemreport>(entity =>
            {
                entity.ToTable("PROBLEMREPORT");

                entity.Property(e => e.Problemreportid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROBLEMREPORTID");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Datesubmitted)
                    .HasColumnType("DATE")
                    .HasColumnName("DATESUBMITTED");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Problemtype)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PROBLEMTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Problemreports)
                    .HasForeignKey(d => d.Charityid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PROBLEMREPCHARITY");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Problemreports)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERPROBLEMREP");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT");

                entity.Property(e => e.Reportid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REPORTID");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Reportcontent)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("REPORTCONTENT");

                entity.Property(e => e.Reporttype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPORTTYPE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERREP");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(e => e.Testimonalid)
                    .HasName("SYS_C008612");

                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonalid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONALID");

                entity.Property(e => e.Content)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Datecreated)
                    .HasColumnType("DATE")
                    .HasColumnName("DATECREATED");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERTEST");
            });

            modelBuilder.Entity<Userr>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C008590");

                entity.ToTable("USERR");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userrs)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("FK_ROLEUSER");
            });

            modelBuilder.Entity<Visacard>(entity =>
            {
                entity.ToTable("VISACARD");

                entity.Property(e => e.Visacardid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VISACARDID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cardnumber)
                    .HasPrecision(16)
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasPrecision(3)
                    .HasColumnName("CVV");

                entity.Property(e => e.Donationid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DONATIONID");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRYDATE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Donation)
                    .WithMany(p => p.Visacards)
                    .HasForeignKey(d => d.Donationid)
                    .HasConstraintName("FK_DONVISA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Visacards)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_USERVISA");
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.ToTable("WEBSITE");

                entity.Property(e => e.Websiteid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WEBSITEID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

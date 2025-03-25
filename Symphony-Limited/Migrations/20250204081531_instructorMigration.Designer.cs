﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Symphony_Limited.Models;

#nullable disable

namespace Symphony_Limited.Migrations
{
    [DbContext(typeof(myContext))]
    [Migration("20250204081531_instructorMigration")]
    partial class instructorMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Symphony_Limited.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_id"));

                    b.Property<string>("admin_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("tbl_admin");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Centres", b =>
                {
                    b.Property<int>("centre_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("centre_id"));

                    b.Property<string>("centre_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("centre_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("centre_id");

                    b.ToTable("tbl_centres");
                });

            modelBuilder.Entity("Symphony_Limited.Models.ContactUs", b =>
                {
                    b.Property<int>("contactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contactId"));

                    b.Property<string>("contactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("contactId");

                    b.ToTable("tbl_contactus");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Course_Enrollment", b =>
                {
                    b.Property<int>("enrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("enrollmentId"));

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<string>("enrollment_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fee_paid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("student_id")
                        .HasColumnType("int");

                    b.HasKey("enrollmentId");

                    b.HasIndex("course_id");

                    b.HasIndex("student_id");

                    b.ToTable("tbl_courseEnrollment");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Courses", b =>
                {
                    b.Property<int>("course_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("course_id"));

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("course_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_fee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_instructor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_lectures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("course_id");

                    b.ToTable("tbl_courses");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Entrance_Exam", b =>
                {
                    b.Property<int>("examId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("examId"));

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("examFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("examName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("examId");

                    b.ToTable("EntranceExams");
                });

            modelBuilder.Entity("Symphony_Limited.Models.FAQs", b =>
                {
                    b.Property<int>("faq_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("faq_id"));

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_posted")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("faq_id");

                    b.ToTable("tbl_faqs");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Instructor", b =>
                {
                    b.Property<int>("instructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("instructorId"));

                    b.Property<string>("instructorFaculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instructorImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("instructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("instructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EnrollmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Student_Exams", b =>
                {
                    b.Property<int>("studentExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentExamId"));

                    b.Property<string>("examResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("examScore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("exam_id")
                        .HasColumnType("int");

                    b.Property<int>("marksObtained")
                        .HasColumnType("int");

                    b.Property<int>("stu_id")
                        .HasColumnType("int");

                    b.HasKey("studentExamId");

                    b.HasIndex("exam_id");

                    b.ToTable("std_Exam");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Students", b =>
                {
                    b.Property<int>("student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("student_id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_of_birth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("student_id");

                    b.ToTable("tbl_students");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Course_Enrollment", b =>
                {
                    b.HasOne("Symphony_Limited.Models.Courses", "Course")
                        .WithMany("Course_Enrollments")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Symphony_Limited.Models.Students", "Student")
                        .WithMany("Course_Enrollments")
                        .HasForeignKey("student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Student_Exams", b =>
                {
                    b.HasOne("Symphony_Limited.Models.Entrance_Exam", "EntranceExam")
                        .WithMany()
                        .HasForeignKey("exam_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntranceExam");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Courses", b =>
                {
                    b.Navigation("Course_Enrollments");
                });

            modelBuilder.Entity("Symphony_Limited.Models.Students", b =>
                {
                    b.Navigation("Course_Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.DAC.Entites;

namespace SchoolSystem.DAC.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassChat> ClassChats { get; set; }

    public virtual DbSet<ClassChatImage> ClassChatImages { get; set; }

    public virtual DbSet<ClassTimeTable> ClassTimeTables { get; set; }

    public virtual DbSet<DegreeFile> DegreeFiles { get; set; }

    public virtual DbSet<DegreeType> DegreeTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<FollowUpNoteBook> FollowUpNoteBooks { get; set; }

    public virtual DbSet<HomeWork> HomeWorks { get; set; }

    public virtual DbSet<LaibaryBook> LaibaryBooks { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationRole> NotificationRoles { get; set; }

    public virtual DbSet<ParentSubervaisorChat> ParentSubervaisorChats { get; set; }

    public virtual DbSet<Reinforcementlesson> Reinforcementlessons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Solution> Solutions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

    public virtual DbSet<StudentDegree> StudentDegrees { get; set; }

    public virtual DbSet<StudentQeustion> StudentQeustions { get; set; }

    public virtual DbSet<StudentSuggestion> StudentSuggestions { get; set; }

    public virtual DbSet<StudentTimeTable> StudentTimeTables { get; set; }

    public virtual DbSet<SubervisorNotification> SubervisorNotifications { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectClass> SubjectClasses { get; set; }

    public virtual DbSet<TeacherAnswer> TeacherAnswers { get; set; }

    public virtual DbSet<TeacherAttendance> TeacherAttendances { get; set; }

    public virtual DbSet<TeacherEvaluation> TeacherEvaluations { get; set; }

    public virtual DbSet<TeacherNotification> TeacherNotifications { get; set; }

    public virtual DbSet<TeacherTable> TeacherTables { get; set; }

    public virtual DbSet<TeacherTimeTable> TeacherTimeTables { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VclassDegree> VclassDegrees { get; set; }

    public virtual DbSet<VclassSubjectDegree> VclassSubjectDegrees { get; set; }

    public virtual DbSet<VclassSubjectTermDegree> VclassSubjectTermDegrees { get; set; }

    public virtual DbSet<VclassTermDegree> VclassTermDegrees { get; set; }

    public virtual DbSet<VteacherEvalution> VteacherEvalutions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = LAPTOP-2AR5OF7M ; Initial Catalog = SchoolSystem; Integrated Security =SSPI ;TrustServerCertificate = True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C018487C56");

            entity.HasOne(d => d.ClassSopervisorNavigation).WithMany(p => p.Classes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__ClassSo__44FF419A");

            entity.HasOne(d => d.Level).WithMany(p => p.Classes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__LevelId__440B1D61");
        });

        modelBuilder.Entity<ClassChat>(entity =>
        {
            entity.HasKey(e => e.ClassChatId).HasName("PK__ClassCha__366737B734CF530D");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassChats).HasConstraintName("FK__ClassChat__Class__17F790F9");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassChats)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__ClassChat__Stude__18EBB532");
        });

        modelBuilder.Entity<ClassChatImage>(entity =>
        {
            entity.HasKey(e => e.ClassChatImageId).HasName("PK__ClassCha__C250115239388982");

            entity.HasOne(d => d.ClassChat).WithMany(p => p.ClassChatImages).HasConstraintName("FK__ClassChat__Class__1BC821DD");
        });

        modelBuilder.Entity<ClassTimeTable>(entity =>
        {
            entity.HasKey(e => e.ClassTimeTableId).HasName("PK__ClassTim__31633FB0C90DBD90");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassTimeTables).HasConstraintName("FK__ClassTime__Class__5441852A");
        });

        modelBuilder.Entity<DegreeFile>(entity =>
        {
            entity.HasKey(e => e.DegreeFileId).HasName("PK__DegreeFi__BE2044515D6AB19A");

            entity.HasOne(d => d.DegreeType).WithMany(p => p.DegreeFiles).HasConstraintName("FK__DegreeFil__Degre__68487DD7");

            entity.HasOne(d => d.Student).WithMany(p => p.DegreeFiles).HasConstraintName("FK__DegreeFil__Stude__693CA210");

            entity.HasOne(d => d.Term).WithMany(p => p.DegreeFiles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DegreeFil__TermI__6754599E");
        });

        modelBuilder.Entity<DegreeType>(entity =>
        {
            entity.HasKey(e => e.DegreeTypeId).HasName("PK__DegreeTy__DD0FA03F927C154C");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED659065D6");
        });

        modelBuilder.Entity<FollowUpNoteBook>(entity =>
        {
            entity.HasKey(e => e.FollowUpNoteBookId).HasName("PK__FollowUp__6482850911BFD65D");

            entity.HasOne(d => d.Class).WithMany(p => p.FollowUpNoteBooks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FollowUpN__Class__7C4F7684");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.FollowUpNoteBooks).HasConstraintName("FK__FollowUpN__Subje__7B5B524B");

            entity.HasOne(d => d.Term).WithMany(p => p.FollowUpNoteBooks).HasConstraintName("FK__FollowUpN__TermI__7D439ABD");
        });

        modelBuilder.Entity<HomeWork>(entity =>
        {
            entity.HasKey(e => e.HomeWorkId).HasName("PK__HomeWork__C49C70581BD491D5");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.HomeWorks).HasConstraintName("FK__HomeWorks__Subje__6C190EBB");

            entity.HasOne(d => d.Term).WithMany(p => p.HomeWorks).HasConstraintName("FK__HomeWorks__TermI__6D0D32F4");
        });

        modelBuilder.Entity<LaibaryBook>(entity =>
        {
            entity.HasKey(e => e.LaibaryBookId).HasName("PK__LaibaryB__FC3D9298803321D4");

            entity.HasOne(d => d.Section).WithMany(p => p.LaibaryBooks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LaibaryBo__Secti__151B244E");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Levels__09F03C26F70E87AE");

            entity.HasOne(d => d.Department).WithMany(p => p.Levels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Levels__Departme__412EB0B6");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E12DA626B1F");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasConstraintName("FK__Notificat__UserI__22751F6C");
        });

        modelBuilder.Entity<NotificationRole>(entity =>
        {
            entity.HasKey(e => e.NotificationRoleId).HasName("PK__Notifica__D523AA901872F295");

            entity.HasOne(d => d.Notification).WithMany(p => p.NotificationRoles).HasConstraintName("FK__Notificat__Notif__25518C17");

            entity.HasOne(d => d.Role).WithMany(p => p.NotificationRoles).HasConstraintName("FK__Notificat__RoleI__2645B050");
        });

        modelBuilder.Entity<ParentSubervaisorChat>(entity =>
        {
            entity.HasKey(e => e.ParentSubervaisorChatId).HasName("PK__ParentSu__5CE078C85B846B06");

            entity.HasOne(d => d.ReceverNavigation).WithMany(p => p.ParentSubervaisorChatReceverNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentSub__Recev__1F98B2C1");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.ParentSubervaisorChatSenderNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ParentSub__Sende__1EA48E88");
        });

        modelBuilder.Entity<Reinforcementlesson>(entity =>
        {
            entity.HasKey(e => e.ReinforcementlessonId).HasName("PK__Reinforc__B162A1F242F7F5AC");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.Reinforcementlessons).HasConstraintName("FK__Reinforce__Subje__03F0984C");

            entity.HasOne(d => d.Term).WithMany(p => p.Reinforcementlessons).HasConstraintName("FK__Reinforce__TermI__04E4BC85");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A0CD60E92");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF08727656AB18");
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.HasKey(e => e.SolutionId).HasName("PK__Solution__6B633AD037CE06C9");

            entity.HasOne(d => d.HomeWork).WithMany(p => p.Solutions).HasConstraintName("FK__Solutions__HomeW__6FE99F9F");

            entity.HasOne(d => d.Student).WithMany(p => p.Solutions).HasConstraintName("FK__Solutions__Stude__70DDC3D8");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B994C82E9E5");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__ClassI__5165187F");

            entity.HasOne(d => d.StedentParentNavigation).WithMany(p => p.StudentStedentParentNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Steden__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.StudentUsers).HasConstraintName("FK__Students__UserId__4F7CD00D");
        });

        modelBuilder.Entity<StudentAttendance>(entity =>
        {
            entity.HasKey(e => e.StudentAttendanceId).HasName("PK__StudentA__6342645BD3ECC6F3");

            entity.Property(e => e.StudentAttendanceValue).HasDefaultValue(true);

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAttendances).HasConstraintName("FK__StudentAt__Stude__08B54D69");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentAttendances).HasConstraintName("FK__StudentAt__TermI__09A971A2");
        });

        modelBuilder.Entity<StudentDegree>(entity =>
        {
            entity.HasKey(e => e.StudentDegreeId).HasName("PK__StudentD__0CC89BAD7A39B2D8");

            entity.HasOne(d => d.DegreeType).WithMany(p => p.StudentDegrees).HasConstraintName("FK__StudentDe__Degre__6477ECF3");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentDegrees).HasConstraintName("FK__StudentDe__Stude__628FA481");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.StudentDegrees).HasConstraintName("FK__StudentDe__Subje__619B8048");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentDegrees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentDe__TermI__6383C8BA");
        });

        modelBuilder.Entity<StudentQeustion>(entity =>
        {
            entity.HasKey(e => e.StudentQeustionId).HasName("PK__StudentQ__A171725E8EF704B1");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentQeustions).HasConstraintName("FK__StudentQe__Stude__74AE54BC");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.StudentQeustions).HasConstraintName("FK__StudentQe__Subje__73BA3083");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentQeustions).HasConstraintName("FK__StudentQe__TermI__75A278F5");
        });

        modelBuilder.Entity<StudentSuggestion>(entity =>
        {
            entity.HasKey(e => e.StudentSuggestionId).HasName("PK__StudentS__699998998D0AD5F3");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentSuggestions).HasConstraintName("FK__StudentSu__Class__01142BA1");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSuggestions).HasConstraintName("FK__StudentSu__Stude__00200768");
        });

        modelBuilder.Entity<StudentTimeTable>(entity =>
        {
            entity.HasKey(e => e.StudentTimeTableId).HasName("PK__StudentT__AA15A79782BE5C1F");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentTimeTables).HasConstraintName("FK__StudentTi__Class__571DF1D5");
        });

        modelBuilder.Entity<SubervisorNotification>(entity =>
        {
            entity.HasKey(e => e.SubervisorNotificationId).HasName("PK__Subervis__C7602C35081D72F4");

            entity.HasOne(d => d.Class).WithMany(p => p.SubervisorNotifications).HasConstraintName("FK__Suberviso__Class__2DE6D218");

            entity.HasOne(d => d.Notification).WithMany(p => p.SubervisorNotifications).HasConstraintName("FK__Suberviso__Notif__2CF2ADDF");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A879B1428B");

            entity.HasOne(d => d.Level).WithMany(p => p.Subjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subjects__LevelI__47DBAE45");
        });

        modelBuilder.Entity<SubjectClass>(entity =>
        {
            entity.HasKey(e => e.SubjectClassId).HasName("PK__SubjectC__56E2859A20F452E1");

            entity.HasOne(d => d.Class).WithMany(p => p.SubjectClasses).HasConstraintName("FK__SubjectCl__Class__4AB81AF0");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubjectCl__Subje__4BAC3F29");

            entity.HasOne(d => d.SubjectTeacherNavigation).WithMany(p => p.SubjectClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubjectCl__Subje__4CA06362");
        });

        modelBuilder.Entity<TeacherAnswer>(entity =>
        {
            entity.HasKey(e => e.TeacherAnswerId).HasName("PK__TeacherA__A3B38DF96FA7FE6C");

            entity.HasOne(d => d.StudentQeustion).WithMany(p => p.TeacherAnswers).HasConstraintName("FK__TeacherAn__Stude__787EE5A0");
        });

        modelBuilder.Entity<TeacherAttendance>(entity =>
        {
            entity.HasKey(e => e.TeacherAttendanceId).HasName("PK__TeacherA__678A4810386EC33B");

            entity.Property(e => e.TeacherAttendanceValue).HasDefaultValue(true);

            entity.HasOne(d => d.User).WithMany(p => p.TeacherAttendances).HasConstraintName("FK__TeacherAt__UserI__10566F31");
        });

        modelBuilder.Entity<TeacherEvaluation>(entity =>
        {
            entity.HasKey(e => e.TeacherEvaluationId).HasName("PK__TeacherE__0F0C6E47230CE529");

            entity.HasOne(d => d.User).WithMany(p => p.TeacherEvaluations).HasConstraintName("FK__TeacherEv__UserI__0C85DE4D");
        });

        modelBuilder.Entity<TeacherNotification>(entity =>
        {
            entity.HasKey(e => e.TeacherNotificationId).HasName("PK__TeacherN__2AF3B40138D4DF00");

            entity.HasOne(d => d.Notification).WithMany(p => p.TeacherNotifications).HasConstraintName("FK__TeacherNo__Notif__29221CFB");

            entity.HasOne(d => d.SubjectClass).WithMany(p => p.TeacherNotifications).HasConstraintName("FK__TeacherNo__Subje__2A164134");
        });

        modelBuilder.Entity<TeacherTable>(entity =>
        {
            entity.HasKey(e => e.TeacherTableId).HasName("PK__TeacherT__D207FF21E6733239");

            entity.HasOne(d => d.User).WithMany(p => p.TeacherTables).HasConstraintName("FK__TeacherTa__UserI__59FA5E80");
        });

        modelBuilder.Entity<TeacherTimeTable>(entity =>
        {
            entity.HasKey(e => e.TeacherTimeTableId).HasName("PK__TeacherT__466F62C43B0B66EB");

            entity.HasOne(d => d.User).WithMany(p => p.TeacherTimeTables).HasConstraintName("FK__TeacherTi__UserI__5CD6CB2B");
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.HasKey(e => e.TermId).HasName("PK__Terms__410A21A5ADECCCA3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C61B38BAD");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__3A81B327");
        });

        modelBuilder.Entity<VclassDegree>(entity =>
        {
            entity.ToView("VClassDegrees");
        });

        modelBuilder.Entity<VclassSubjectDegree>(entity =>
        {
            entity.ToView("VClassSubjectDegrees");
        });

        modelBuilder.Entity<VclassSubjectTermDegree>(entity =>
        {
            entity.ToView("VClassSubjectTermDegrees");
        });

        modelBuilder.Entity<VclassTermDegree>(entity =>
        {
            entity.ToView("VClassTermDegrees");
        });

        modelBuilder.Entity<VteacherEvalution>(entity =>
        {
            entity.ToView("VTeacherEvalutions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegreeTypes",
                columns: table => new
                {
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DegreeTy__DD0FA03F927C154C", x => x.DegreeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__B2079BED659065D6", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__8AFACE1A0CD60E92", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sections__80EF08727656AB18", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    TermId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Terms__410A21A5ADECCCA3", x => x.TermId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Levels__09F03C26F70E87AE", x => x.LevelId);
                    table.ForeignKey(
                        name: "FK__Levels__Departme__412EB0B6",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Usernumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Userpassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSupervisor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4C61B38BAD", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__Users__RoleId__3A81B327",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "LaibaryBooks",
                columns: table => new
                {
                    LaibaryBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sectionid = table.Column<int>(type: "int", nullable: false),
                    LaibaryBookName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LaibaryBookImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaibaryBookPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LaibaryB__FC3D9298803321D4", x => x.LaibaryBookId);
                    table.ForeignKey(
                        name: "FK__LaibaryBo__Secti__151B244E",
                        column: x => x.Sectionid,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectBook1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectBook2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectBook3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__AC1BA3A879B1428B", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK__Subjects__LevelI__47DBAE45",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    ClassSopervisor = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__CB1927C018487C56", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK__Classes__ClassSo__44FF419A",
                        column: x => x.ClassSopervisor,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__Classes__LevelId__440B1D61",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NotificationText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E12DA626B1F", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK__Notificat__UserI__22751F6C",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentSubervaisorChats",
                columns: table => new
                {
                    ParentSubervaisorChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<int>(type: "int", nullable: false),
                    Recever = table.Column<int>(type: "int", nullable: false),
                    ParentSubervaisorChatText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentSubervaisorChatImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentSubervaisorChatFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentSubervaisorChatDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ParentSu__5CE078C85B846B06", x => x.ParentSubervaisorChatId);
                    table.ForeignKey(
                        name: "FK__ParentSub__Recev__1F98B2C1",
                        column: x => x.Recever,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__ParentSub__Sende__1EA48E88",
                        column: x => x.Sender,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TeacherAttendances",
                columns: table => new
                {
                    TeacherAttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherAttendanceValue = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TeacherAttendanceDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherA__678A4810386EC33B", x => x.TeacherAttendanceId);
                    table.ForeignKey(
                        name: "FK__TeacherAt__UserI__10566F31",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherEvaluations",
                columns: table => new
                {
                    TeacherEvaluationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherEvaluationValueOne = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    TeacherEvaluationValueTow = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherE__0F0C6E47230CE529", x => x.TeacherEvaluationId);
                    table.ForeignKey(
                        name: "FK__TeacherEv__UserI__0C85DE4D",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTables",
                columns: table => new
                {
                    TeacherTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TheDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodOne = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodTow = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodThree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodFour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodFive = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodSix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodSeven = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodEight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherT__D207FF21E6733239", x => x.TeacherTableId);
                    table.ForeignKey(
                        name: "FK__TeacherTa__UserI__59FA5E80",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTimeTables",
                columns: table => new
                {
                    TeacherTimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeacherTimeTableImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherT__466F62C43B0B66EB", x => x.TeacherTimeTableId);
                    table.ForeignKey(
                        name: "FK__TeacherTi__UserI__5CD6CB2B",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassTimeTables",
                columns: table => new
                {
                    ClassTimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    TheDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodOne = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodTow = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodThree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodFour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodFive = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodSix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodSeven = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PeriodEight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClassTim__31633FB0C90DBD90", x => x.ClassTimeTableId);
                    table.ForeignKey(
                        name: "FK__ClassTime__Class__5441852A",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StedentParent = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__32C52B994C82E9E5", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK__Students__ClassI__5165187F",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK__Students__Steden__5070F446",
                        column: x => x.StedentParent,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__Students__UserId__4F7CD00D",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTimeTables",
                columns: table => new
                {
                    StudentTimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classid = table.Column<int>(type: "int", nullable: false),
                    StudentTimeTableImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentT__AA15A79782BE5C1F", x => x.StudentTimeTableId);
                    table.ForeignKey(
                        name: "FK__StudentTi__Class__571DF1D5",
                        column: x => x.Classid,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectClasses",
                columns: table => new
                {
                    SubjectClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectTeacher = table.Column<int>(type: "int", nullable: false),
                    SubjectClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubjectC__56E2859A20F452E1", x => x.SubjectClassId);
                    table.ForeignKey(
                        name: "FK__SubjectCl__Class__4AB81AF0",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__SubjectCl__Subje__4BAC3F29",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                    table.ForeignKey(
                        name: "FK__SubjectCl__Subje__4CA06362",
                        column: x => x.SubjectTeacher,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "NotificationRoles",
                columns: table => new
                {
                    NotificationRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__D523AA901872F295", x => x.NotificationRoleId);
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__25518C17",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Notificat__RoleI__2645B050",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubervisorNotifications",
                columns: table => new
                {
                    SubervisorNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subervis__C7602C35081D72F4", x => x.SubervisorNotificationId);
                    table.ForeignKey(
                        name: "FK__Suberviso__Class__2DE6D218",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Suberviso__Notif__2CF2ADDF",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassChats",
                columns: table => new
                {
                    ClassChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classid = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    ClassChatText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassChatFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassChatDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClassCha__366737B734CF530D", x => x.ClassChatId);
                    table.ForeignKey(
                        name: "FK__ClassChat__Class__17F790F9",
                        column: x => x.Classid,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ClassChat__Stude__18EBB532",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DegreeFiles",
                columns: table => new
                {
                    DegreeFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DegreeFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DegreeFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DegreeFi__BE2044515D6AB19A", x => x.DegreeFileId);
                    table.ForeignKey(
                        name: "FK__DegreeFil__Degre__68487DD7",
                        column: x => x.DegreeTypeId,
                        principalTable: "DegreeTypes",
                        principalColumn: "DegreeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DegreeFil__Stude__693CA210",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__DegreeFil__TermI__6754599E",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId");
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    StudentAttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    StudentAttendanceValue = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StudentAttendanceDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentA__6342645BD3ECC6F3", x => x.StudentAttendanceId);
                    table.ForeignKey(
                        name: "FK__StudentAt__Stude__08B54D69",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentAt__TermI__09A971A2",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSuggestions",
                columns: table => new
                {
                    StudentSuggestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StudentSuggestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentSuggestionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentSuggestionDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentS__699998998D0AD5F3", x => x.StudentSuggestionId);
                    table.ForeignKey(
                        name: "FK__StudentSu__Class__01142BA1",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentSu__Stude__00200768",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpNoteBooks",
                columns: table => new
                {
                    FollowUpNoteBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    FollowUpNoteBookText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowUpNoteBookDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FollowUp__6482850911BFD65D", x => x.FollowUpNoteBookId);
                    table.ForeignKey(
                        name: "FK__FollowUpN__Class__7C4F7684",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK__FollowUpN__Subje__7B5B524B",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FollowUpN__TermI__7D439ABD",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    HomeWorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    HomeWorkDegree = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HomeWorkTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HomeWorkdescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorkDeadline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HomeWorkDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HomeWork__C49C70581BD491D5", x => x.HomeWorkId);
                    table.ForeignKey(
                        name: "FK__HomeWorks__Subje__6C190EBB",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__HomeWorks__TermI__6D0D32F4",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reinforcementlessons",
                columns: table => new
                {
                    ReinforcementlessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    ReinforcementlessonTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reinforcementlessondescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReinforcementlessonFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reinforcementlessonlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReinforcementlessonDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reinforc__B162A1F242F7F5AC", x => x.ReinforcementlessonId);
                    table.ForeignKey(
                        name: "FK__Reinforce__Subje__03F0984C",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Reinforce__TermI__04E4BC85",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDegrees",
                columns: table => new
                {
                    StudentDegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    DegreeTypeId = table.Column<int>(type: "int", nullable: false),
                    StudentDegreeValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StudentDegreenote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentD__0CC89BAD7A39B2D8", x => x.StudentDegreeId);
                    table.ForeignKey(
                        name: "FK__StudentDe__Degre__6477ECF3",
                        column: x => x.DegreeTypeId,
                        principalTable: "DegreeTypes",
                        principalColumn: "DegreeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentDe__Stude__628FA481",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentDe__Subje__619B8048",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentDe__TermI__6383C8BA",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId");
                });

            migrationBuilder.CreateTable(
                name: "StudentQeustions",
                columns: table => new
                {
                    StudentQeustionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    StudentQeustionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentQeustionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentQeustionDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentQ__A171725E8EF704B1", x => x.StudentQeustionId);
                    table.ForeignKey(
                        name: "FK__StudentQe__Stude__74AE54BC",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentQe__Subje__73BA3083",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__StudentQe__TermI__75A278F5",
                        column: x => x.TermId,
                        principalTable: "Terms",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherNotifications",
                columns: table => new
                {
                    TeacherNotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    SubjectClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherN__2AF3B40138D4DF00", x => x.TeacherNotificationId);
                    table.ForeignKey(
                        name: "FK__TeacherNo__Notif__29221CFB",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__TeacherNo__Subje__2A164134",
                        column: x => x.SubjectClassId,
                        principalTable: "SubjectClasses",
                        principalColumn: "SubjectClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassChatImages",
                columns: table => new
                {
                    ClassChatImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassChatId = table.Column<int>(type: "int", nullable: false),
                    ClassChatImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClassCha__C250115239388982", x => x.ClassChatImageId);
                    table.ForeignKey(
                        name: "FK__ClassChat__Class__1BC821DD",
                        column: x => x.ClassChatId,
                        principalTable: "ClassChats",
                        principalColumn: "ClassChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeWorkId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SolutionImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SolutionDegree = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Solutionnote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solution__6B633AD037CE06C9", x => x.SolutionId);
                    table.ForeignKey(
                        name: "FK__Solutions__HomeW__6FE99F9F",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "HomeWorkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Solutions__Stude__70DDC3D8",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAnswers",
                columns: table => new
                {
                    TeacherAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentQeustionId = table.Column<int>(type: "int", nullable: false),
                    TeacherAnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAnswerImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAnswerDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TeacherA__A3B38DF96FA7FE6C", x => x.TeacherAnswerId);
                    table.ForeignKey(
                        name: "FK__TeacherAn__Stude__787EE5A0",
                        column: x => x.StudentQeustionId,
                        principalTable: "StudentQeustions",
                        principalColumn: "StudentQeustionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassChatImages_ClassChatId",
                table: "ClassChatImages",
                column: "ClassChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassChats_Classid",
                table: "ClassChats",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_ClassChats_StudentId",
                table: "ClassChats",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassSopervisor",
                table: "Classes",
                column: "ClassSopervisor");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LevelId",
                table: "Classes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTimeTables_ClassId",
                table: "ClassTimeTables",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFiles_DegreeTypeId",
                table: "DegreeFiles",
                column: "DegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFiles_StudentId",
                table: "DegreeFiles",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeFiles_TermId",
                table: "DegreeFiles",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpNoteBooks_ClassId",
                table: "FollowUpNoteBooks",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpNoteBooks_SubjectClassId",
                table: "FollowUpNoteBooks",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpNoteBooks_TermId",
                table: "FollowUpNoteBooks",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_SubjectClassId",
                table: "HomeWorks",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_TermId",
                table: "HomeWorks",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_LaibaryBooks_Sectionid",
                table: "LaibaryBooks",
                column: "Sectionid");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_DepartmentId",
                table: "Levels",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRoles_NotificationId",
                table: "NotificationRoles",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRoles_RoleId",
                table: "NotificationRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSubervaisorChats_Recever",
                table: "ParentSubervaisorChats",
                column: "Recever");

            migrationBuilder.CreateIndex(
                name: "IX_ParentSubervaisorChats_Sender",
                table: "ParentSubervaisorChats",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_Reinforcementlessons_SubjectClassId",
                table: "Reinforcementlessons",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Reinforcementlessons_TermId",
                table: "Reinforcementlessons",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_HomeWorkId",
                table: "Solutions",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_StudentId",
                table: "Solutions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_TermId",
                table: "StudentAttendances",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_DegreeTypeId",
                table: "StudentDegrees",
                column: "DegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_StudentId",
                table: "StudentDegrees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_SubjectClassId",
                table: "StudentDegrees",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDegrees_TermId",
                table: "StudentDegrees",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQeustions_StudentId",
                table: "StudentQeustions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQeustions_SubjectClassId",
                table: "StudentQeustions",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQeustions_TermId",
                table: "StudentQeustions",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StedentParent",
                table: "Students",
                column: "StedentParent");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSuggestions_ClassId",
                table: "StudentSuggestions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSuggestions_StudentId",
                table: "StudentSuggestions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTimeTables_Classid",
                table: "StudentTimeTables",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_SubervisorNotifications_ClassId",
                table: "SubervisorNotifications",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubervisorNotifications_NotificationId",
                table: "SubervisorNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_ClassId",
                table: "SubjectClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_SubjectId",
                table: "SubjectClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_SubjectTeacher",
                table: "SubjectClasses",
                column: "SubjectTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LevelId",
                table: "Subjects",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAnswers_StudentQeustionId",
                table: "TeacherAnswers",
                column: "StudentQeustionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAttendances_UserId",
                table: "TeacherAttendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEvaluations_UserId",
                table: "TeacherEvaluations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherNotifications_NotificationId",
                table: "TeacherNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherNotifications_SubjectClassId",
                table: "TeacherNotifications",
                column: "SubjectClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTables_UserId",
                table: "TeacherTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTimeTables_UserId",
                table: "TeacherTimeTables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassChatImages");

            migrationBuilder.DropTable(
                name: "ClassTimeTables");

            migrationBuilder.DropTable(
                name: "DegreeFiles");

            migrationBuilder.DropTable(
                name: "FollowUpNoteBooks");

            migrationBuilder.DropTable(
                name: "LaibaryBooks");

            migrationBuilder.DropTable(
                name: "NotificationRoles");

            migrationBuilder.DropTable(
                name: "ParentSubervaisorChats");

            migrationBuilder.DropTable(
                name: "Reinforcementlessons");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "StudentDegrees");

            migrationBuilder.DropTable(
                name: "StudentSuggestions");

            migrationBuilder.DropTable(
                name: "StudentTimeTables");

            migrationBuilder.DropTable(
                name: "SubervisorNotifications");

            migrationBuilder.DropTable(
                name: "TeacherAnswers");

            migrationBuilder.DropTable(
                name: "TeacherAttendances");

            migrationBuilder.DropTable(
                name: "TeacherEvaluations");

            migrationBuilder.DropTable(
                name: "TeacherNotifications");

            migrationBuilder.DropTable(
                name: "TeacherTables");

            migrationBuilder.DropTable(
                name: "TeacherTimeTables");

            migrationBuilder.DropTable(
                name: "ClassChats");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "DegreeTypes");

            migrationBuilder.DropTable(
                name: "StudentQeustions");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectClasses");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

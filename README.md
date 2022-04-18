Manual solution merge context model snapshot
In our solution architecture we have production , master and feature environments. each environment comes with the respective database. 

Case Study 
Initially we have a an entity IOTAssets with below properties


public class IOTAsset
  {
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public DateTime DateCreated { get; set; }   
  }
Our initial context model snapshot


[DbContext(typeof(DMPContext))]
    partial class DMPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
and initial migrations


public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IOTAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOTAssets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IOTAssets");
        }
    }
With this we have two databases

DataMigrationPrototype_production

DataMigrationPrototype_master 

In the above databases initial migration have been applied


Developer A
Property Field_A
Add a new branch Feature_A from master

Add a new database (DataMigrationPrototype_Feat_A) connection string 


"DMPDbConnectionString": "Server=(localdb)\\mssqllocaldb;Database=DataMigrationPrototype_Feat_A;Trusted_Connection=True;MultipleActiveResultSets=true",
Add property field_A to IOTAsset entity 


public class IOTAsset
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public string Field_A { get; set; }     }
Case One: Without running initial migration on Feat_A database

Add new migration feature_a. At this point context model snapshot is as below 


[DbContext(typeof(DMPContext))]
    partial class DMPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Field_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
and new migration feature_a


public partial class feature_a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field_A",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field_A",
                table: "IOTAssets");
        }
    }
Case Two: Run initial migrations on Feat_A database

Add new migration feature_a. At this point context model snapshot is as below


[DbContext(typeof(DMPContext))]
    partial class DMPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Field_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
 and new migration feature_a


public partial class feature_a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field_A",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field_A",
                table: "IOTAssets");
        }
    }
NOTE: RUNNING INITIAL MIGRATION MAKES NO DIFFERENCE TO CONTEXT MODEL SNAPSHOT

Property Description
Add property Description to IOTAsset entity


public class IOTAsset
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public string Field_A { get; set; }   
    public string Description { get; set; }
  }
Add new migration description. At this point context model snapshot is as below


[DbContext(typeof(DMPContext))]
    partial class DMPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
 and new migration description


public partial class description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IOTAssets");
        }
    }
Developer B
Add a new branch Feature_B from master

Add a new database (DataMigrationPrototype_Feat_B) connection string 


"DMPDbConnectionString": "Server=(localdb)\\mssqllocaldb;Database=DataMigrationPrototype_Feat_B;Trusted_Connection=True;MultipleActiveResultSets=true"
Add property Field_B to IOTAsset entity 


public class IOTAsset
  {
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public DateTime DateCreated { get; set; }
    public string Field_B { get; set; }   
  }
Add new migration feature_b. At this point context model snapshot is as below


[DbContext(typeof(DMPContext))]
    partial class DMPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Field_B")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
 and new migration feature_b


public partial class feature_b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Field_B",
                table: "IOTAssets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field_B",
                table: "IOTAssets");
        }
    }
Merging 
Developer A
Merge branch Feature_A into master. NOTE: NO CONFLICTS OCCUR

new context model snapshot


[DbContext(typeof(DMPContext))]
    partial class DMPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MigrationsConflicts.Models.IOTAsset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field_A")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOTAssets");
                });
#pragma warning restore 612, 618
        }
    }
apply migrations to master/production database. Run update-database 


we have both Field_A and Description added to IOTAsset table


NOTE: The database update has no conflicts

Developer B
Merge branch Feature_B into master. Below conflicts occur 


 

Model Snapshot. Resolve the conflict by accepting both incoming and current


IOTAsset Entity. Resolve the conflict by accepting both incoming and current


Apply migrations to master.


NOTE: there are no conflicts 

Conclusion
From EF 5 As long as developers  adheres to context model snapshot sanity as illustrated no migration corruption should occur 

Source
Handling EF Core migrations in a team 

Mikael Eliasson - Corrupted model snapshot in EF Core and broken migrations 

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rocket_Elevators_REST_API.Models
{
    public partial class RailsApp_developmentContext : DbContext
    {
        public RailsApp_developmentContext()
        {
        }

        public RailsApp_developmentContext(DbContextOptions<RailsApp_developmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Batteries> Batteries { get; set; }
        public virtual DbSet<BlazerAudits> BlazerAudits { get; set; }
        public virtual DbSet<BlazerChecks> BlazerChecks { get; set; }
        public virtual DbSet<BlazerDashboardQueries> BlazerDashboardQueries { get; set; }
        public virtual DbSet<BlazerDashboards> BlazerDashboards { get; set; }
        public virtual DbSet<BlazerQueries> BlazerQueries { get; set; }
        public virtual DbSet<BuildingDetails> BuildingDetails { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Elevators> Elevators { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Entity)
                    .HasColumnName("entity")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(15,8)");

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasColumnType("decimal(15,8)");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberAndStreet)
                    .HasColumnName("number_and_street")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postal_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SuiteAndApartment)
                    .HasColumnName("suite_and_apartment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfAddress)
                    .HasColumnName("type_of_address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("index_batteries_on_employee_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CertificateOfOperations)
                    .HasColumnName("certificate_of_operations")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DateOfCommissioning)
                    .HasColumnName("date_of_commissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfLastInspection)
                    .HasColumnName("date_of_last_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BlazerAudits>(entity =>
            {
                entity.ToTable("blazer_audits");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_audits_on_query_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_blazer_audits_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DataSource)
                    .HasColumnName("data_source")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Statement).HasColumnName("statement");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<BlazerChecks>(entity =>
            {
                entity.ToTable("blazer_checks");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_checks_on_creator_id");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_checks_on_query_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckType)
                    .HasColumnName("check_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Emails).HasColumnName("emails");

                entity.Property(e => e.LastRunAt).HasColumnName("last_run_at");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Schedule)
                    .HasColumnName("schedule")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SlackChannels).HasColumnName("slack_channels");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<BlazerDashboardQueries>(entity =>
            {
                entity.ToTable("blazer_dashboard_queries");

                entity.HasIndex(e => e.DashboardId)
                    .HasName("index_blazer_dashboard_queries_on_dashboard_id");

                entity.HasIndex(e => e.QueryId)
                    .HasName("index_blazer_dashboard_queries_on_query_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DashboardId).HasColumnName("dashboard_id");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<BlazerDashboards>(entity =>
            {
                entity.ToTable("blazer_dashboards");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_dashboards_on_creator_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<BlazerQueries>(entity =>
            {
                entity.ToTable("blazer_queries");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("index_blazer_queries_on_creator_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DataSource)
                    .HasColumnName("data_source")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Statement).HasColumnName("statement");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<BuildingDetails>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.InformationKey)
                    .HasColumnName("information_key")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_buildings_on_customer_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmailOfTheAdministratorOfTheBuilding)
                    .HasColumnName("email_of_the_administrator_of_the_building")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullNameOfTheBuildingAdministrator)
                    .HasColumnName("full_name_of_the_building_administrator")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullNameOfTheTechnicalContactForTheBuilding)
                    .HasColumnName("full_name_of_the_technical_contact_for_the_building")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumberOfTheBuildingAdministrator)
                    .HasColumnName("phone_number_of_the_building_administrator")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalContactEmailForTheBuilding)
                    .HasColumnName("technical_contact_email_for_the_building")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalContactPhoneForTheBuilding)
                    .HasColumnName("technical_contact_phone_for_the_building")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberOfFloorsServed).HasColumnName("number_of_floors_served");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_customers_on_address_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_customers_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CompanyContactPhone)
                    .HasColumnName("company_contact_phone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyDescription).HasColumnName("company_description");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CustomersCreationDate)
                    .HasColumnName("customers_creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.EmailOfCompanyContact)
                    .HasColumnName("email_of_company_contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullNameOfCompanyContact)
                    .HasColumnName("full_name_of_company_contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullNameOfServiceTechnicalAuthority)
                    .HasColumnName("full_name_of_service_technical_authority")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalAuthorityPhoneForService)
                    .HasColumnName("technical_authority_phone_for_service_")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalManagerEmailForService)
                    .HasColumnName("technical_manager_email_for_service")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CertificateOfInspection)
                    .HasColumnName("certificate_of_inspection")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DateOfCommissioning)
                    .HasColumnName("date_of_commissioning")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfLastInspection)
                    .HasColumnName("date_of_last_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_employees_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("blob");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DepartmentInChargeOfElevators)
                    .HasColumnName("department_in_charge_of_elevators")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullNameOfContact)
                    .HasColumnName("full_name_of_contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectDescription).HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasColumnName("project_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasColumnName("contact_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InstallationFee)
                    .HasColumnName("installation_fee")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumOfActivityHoursPerDay).HasColumnName("num_of_activity_hours_per_day");

                entity.Property(e => e.NumOfApartments).HasColumnName("num_of_apartments");

                entity.Property(e => e.NumOfBasements).HasColumnName("num_of_basements");

                entity.Property(e => e.NumOfDistinctBusinesses).HasColumnName("num_of_distinct_businesses");

                entity.Property(e => e.NumOfElevatorCages).HasColumnName("num_of_elevator_cages");

                entity.Property(e => e.NumOfFloors).HasColumnName("num_of_floors");

                entity.Property(e => e.NumOfOccupantsPerFloor).HasColumnName("num_of_occupants_per_Floor");

                entity.Property(e => e.NumOfParkingSpots).HasColumnName("num_of_parking_spots");

                entity.Property(e => e.ProductLine)
                    .HasColumnName("product_line")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequiredColumns).HasColumnName("required_columns");

                entity.Property(e => e.RequiredShafts).HasColumnName("required_shafts");

                entity.Property(e => e.SubTotal)
                    .HasColumnName("sub_total")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EmployeeRole)
                    .HasColumnName("employee_role")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RememberCreatedAt).HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt).HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SuperadminRole)
                    .HasColumnName("superadmin_role")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserRole)
                    .HasColumnName("user_role")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

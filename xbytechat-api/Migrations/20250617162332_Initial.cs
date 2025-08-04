using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace xbytechat.api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerformedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerformedByUserName = table.Column<string>(type: "text", nullable: true),
                    RoleAtTime = table.Column<string>(type: "text", nullable: true),
                    ActionType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IPAddress = table.Column<string>(type: "text", nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoReplyFlows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NodesJson = table.Column<string>(type: "text", nullable: false),
                    EdgesJson = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TriggerKeyword = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoReplyFlows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoReplyLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggerKeyword = table.Column<string>(type: "text", nullable: false),
                    TriggerType = table.Column<string>(type: "text", nullable: false),
                    ReplyContent = table.Column<string>(type: "text", nullable: false),
                    FlowName = table.Column<string>(type: "text", nullable: true),
                    MessageLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    TriggeredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoReplyLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    BusinessName = table.Column<string>(type: "text", nullable: false),
                    BusinessEmail = table.Column<string>(type: "text", nullable: false),
                    RepresentativeName = table.Column<string>(type: "text", nullable: true),
                    CreatedByPartnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CompanyPhone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Industry = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogClickLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    UserPhone = table.Column<string>(type: "text", nullable: true),
                    BotId = table.Column<string>(type: "text", nullable: true),
                    CategoryBrowsed = table.Column<string>(type: "text", nullable: true),
                    ProductBrowsed = table.Column<string>(type: "text", nullable: true),
                    CTAJourney = table.Column<string>(type: "text", nullable: true),
                    TemplateId = table.Column<string>(type: "text", nullable: false),
                    RefMessageId = table.Column<string>(type: "text", nullable: false),
                    ButtonText = table.Column<string>(type: "text", nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CampaignSendLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: true),
                    FollowUpSent = table.Column<bool>(type: "boolean", nullable: false),
                    LastInteractionType = table.Column<string>(type: "text", nullable: true),
                    MessageLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    PlanSnapshot = table.Column<string>(type: "text", nullable: true),
                    CtaId = table.Column<Guid>(type: "uuid", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogClickLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatSessionStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    Mode = table.Column<string>(type: "text", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSessionStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactReads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactReads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTADefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ButtonText = table.Column<string>(type: "text", nullable: false),
                    ButtonType = table.Column<string>(type: "text", nullable: false),
                    TargetUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTADefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTAFlowConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    FlowName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTAFlowConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FailedWebhookLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    SourceModule = table.Column<string>(type: "text", nullable: true),
                    FailureType = table.Column<string>(type: "text", nullable: true),
                    RawJson = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailedWebhookLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowExecutionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepName = table.Column<string>(type: "text", nullable: false),
                    FlowId = table.Column<Guid>(type: "uuid", nullable: true),
                    TrackingLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    TriggeredByButton = table.Column<string>(type: "text", nullable: true),
                    TemplateName = table.Column<string>(type: "text", nullable: true),
                    TemplateType = table.Column<string>(type: "text", nullable: true),
                    Success = table.Column<bool>(type: "boolean", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    RawResponse = table.Column<string>(type: "text", nullable: true),
                    ExecutedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowExecutionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    IsPinned = table.Column<bool>(type: "boolean", nullable: false),
                    IsInternal = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalClicks = table.Column<int>(type: "integer", nullable: false),
                    LastClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MostClickedCTA = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DueAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ReminderType = table.Column<string>(type: "text", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: true),
                    IsRecurring = table.Column<bool>(type: "boolean", nullable: false),
                    RecurrencePattern = table.Column<string>(type: "text", nullable: true),
                    SendWhatsappNotification = table.Column<bool>(type: "boolean", nullable: false),
                    LinkedCampaign = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastCTAType = table.Column<string>(type: "text", nullable: true),
                    LastClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FollowUpSent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsSystemDefined = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ColorHex = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IsSystemTag = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUsedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebhookSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AutoCleanupEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LastCleanupAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoReplyFlowEdges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlowId = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceNodeId = table.Column<string>(type: "text", nullable: false),
                    TargetNodeId = table.Column<string>(type: "text", nullable: false),
                    SourceHandle = table.Column<string>(type: "text", nullable: true),
                    TargetHandle = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoReplyFlowEdges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoReplyFlowEdges_AutoReplyFlows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "AutoReplyFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoReplyFlowNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlowId = table.Column<Guid>(type: "uuid", nullable: false),
                    NodeType = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    ConfigJson = table.Column<string>(type: "text", nullable: false),
                    Position_X = table.Column<double>(type: "double precision", nullable: false),
                    Position_Y = table.Column<double>(type: "double precision", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoReplyFlowNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoReplyFlowNodes_AutoReplyFlows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "AutoReplyFlows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoReplyRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggerKeyword = table.Column<string>(type: "text", nullable: false),
                    ReplyMessage = table.Column<string>(type: "text", nullable: false),
                    MediaUrl = table.Column<string>(type: "text", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FlowName = table.Column<string>(type: "text", nullable: true),
                    FlowId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoReplyRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoReplyRules_AutoReplyFlows_FlowId",
                        column: x => x.FlowId,
                        principalTable: "AutoReplyFlows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessPlanInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Plan = table.Column<int>(type: "integer", nullable: false),
                    TotalMonthlyQuota = table.Column<int>(type: "integer", nullable: false),
                    RemainingMessages = table.Column<int>(type: "integer", nullable: false),
                    QuotaResetDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WalletBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlanInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPlanInfos_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LeadSource = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Tags = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LastContactedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextFollowUpAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastCTAInteraction = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastCTAType = table.Column<string>(type: "text", nullable: true),
                    LastClickedProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsAutomationPaused = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedAgentId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhatsAppSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApiUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ApiToken = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    WhatsAppBusinessNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PhoneNumberId = table.Column<string>(type: "text", nullable: true),
                    WabaId = table.Column<string>(type: "text", nullable: true),
                    SenderDisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhatsAppSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhatsAppSettings_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    SourceCampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MessageTemplate = table.Column<string>(type: "text", nullable: false),
                    TemplateId = table.Column<string>(type: "text", nullable: true),
                    MessageBody = table.Column<string>(type: "text", nullable: true),
                    FollowUpTemplateId = table.Column<string>(type: "text", nullable: true),
                    CampaignType = table.Column<string>(type: "text", nullable: true),
                    CtaId = table.Column<Guid>(type: "uuid", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ImageCaption = table.Column<string>(type: "text", nullable: true),
                    TemplateParameters = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_CTADefinitions_CtaId",
                        column: x => x.CtaId,
                        principalTable: "CTADefinitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Campaigns_Campaigns_SourceCampaignId",
                        column: x => x.SourceCampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CTAFlowSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CTAFlowConfigId = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggerButtonText = table.Column<string>(type: "text", nullable: false),
                    TriggerButtonType = table.Column<string>(type: "text", nullable: false),
                    TemplateToSend = table.Column<string>(type: "text", nullable: false),
                    StepOrder = table.Column<int>(type: "integer", nullable: false),
                    RequiredTag = table.Column<string>(type: "text", nullable: true),
                    RequiredSource = table.Column<string>(type: "text", nullable: true),
                    PositionX = table.Column<float>(type: "real", nullable: true),
                    PositionY = table.Column<float>(type: "real", nullable: true),
                    TemplateType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTAFlowSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTAFlowSteps_CTAFlowConfigs_CTAFlowConfigId",
                        column: x => x.CTAFlowConfigId,
                        principalTable: "CTAFlowConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssignedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssignedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTags_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadTimelines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: true),
                    ReferenceId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsSystemGenerated = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CTAType = table.Column<string>(type: "text", nullable: true),
                    CTASourceType = table.Column<string>(type: "text", nullable: true),
                    CTASourceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadTimelines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadTimelines_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadTimelines_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignButtons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    IsFromTemplate = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignButtons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignButtons_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignFlowOverrides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ButtonText = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OverrideNextTemplate = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignFlowOverrides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignFlowOverrides_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRecipients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BotId = table.Column<string>(type: "text", nullable: true),
                    MessagePreview = table.Column<string>(type: "text", nullable: true),
                    ClickedCTA = table.Column<string>(type: "text", nullable: true),
                    CategoryBrowsed = table.Column<string>(type: "text", nullable: true),
                    ProductBrowsed = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAutoTagged = table.Column<bool>(type: "boolean", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignRecipients_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignRecipients_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignRecipients_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<string>(type: "text", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientNumber = table.Column<string>(type: "text", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: false),
                    MediaUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    RawResponse = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    CTAFlowConfigId = table.Column<Guid>(type: "uuid", nullable: true),
                    CTAFlowStepId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsIncoming = table.Column<bool>(type: "boolean", nullable: false),
                    RenderedBody = table.Column<string>(type: "text", nullable: true),
                    RefMessageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlowButtonLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ButtonText = table.Column<string>(type: "text", nullable: false),
                    NextStepId = table.Column<Guid>(type: "uuid", nullable: true),
                    ButtonType = table.Column<string>(type: "text", nullable: false),
                    ButtonSubType = table.Column<string>(type: "text", nullable: false),
                    ButtonValue = table.Column<string>(type: "text", nullable: false),
                    CTAFlowStepId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowButtonLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowButtonLinks_CTAFlowSteps_CTAFlowStepId",
                        column: x => x.CTAFlowStepId,
                        principalTable: "CTAFlowSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageStatusLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientNumber = table.Column<string>(type: "text", nullable: false),
                    CustomerProfileName = table.Column<string>(type: "text", nullable: true),
                    MessageId = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    MessageType = table.Column<string>(type: "text", nullable: false),
                    TemplateName = table.Column<string>(type: "text", nullable: true),
                    TemplateCategory = table.Column<string>(type: "text", nullable: true),
                    Channel = table.Column<string>(type: "text", nullable: false),
                    IsSessionOpen = table.Column<bool>(type: "boolean", nullable: false),
                    MetaTimestamp = table.Column<long>(type: "bigint", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    ErrorCode = table.Column<int>(type: "integer", nullable: true),
                    RawPayload = table.Column<string>(type: "text", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStatusLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageStatusLogs_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageStatusLogs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageStatusLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsGranted = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AssignedBy = table.Column<string>(type: "text", nullable: true),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignSendLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<string>(type: "text", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageBody = table.Column<string>(type: "text", nullable: false),
                    TemplateId = table.Column<string>(type: "text", nullable: true),
                    SendStatus = table.Column<string>(type: "text", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    DeviceInfo = table.Column<string>(type: "text", nullable: true),
                    MacAddress = table.Column<string>(type: "text", nullable: true),
                    SourceChannel = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    IsClicked = table.Column<bool>(type: "boolean", nullable: false),
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClickType = table.Column<string>(type: "text", nullable: true),
                    RetryCount = table.Column<int>(type: "integer", nullable: false),
                    LastRetryAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastRetryStatus = table.Column<string>(type: "text", nullable: true),
                    AllowRetry = table.Column<bool>(type: "boolean", nullable: false),
                    MessageLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignSendLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignSendLogs_CampaignRecipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "CampaignRecipients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignSendLogs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignSendLogs_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignSendLogs_MessageLogs_MessageLogId",
                        column: x => x.MessageLogId,
                        principalTable: "MessageLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignSendLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrackingLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    SourceType = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uuid", nullable: true),
                    CampaignSendLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    ButtonText = table.Column<string>(type: "text", nullable: true),
                    CTAType = table.Column<string>(type: "text", nullable: true),
                    MessageId = table.Column<string>(type: "text", nullable: true),
                    TemplateId = table.Column<string>(type: "text", nullable: true),
                    MessageLogId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClickedVia = table.Column<string>(type: "text", nullable: true),
                    Referrer = table.Column<string>(type: "text", nullable: true),
                    ClickedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IPAddress = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    Browser = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    FollowUpSent = table.Column<bool>(type: "boolean", nullable: false),
                    LastInteractionType = table.Column<string>(type: "text", nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThreadId = table.Column<Guid>(type: "uuid", nullable: true),
                    StepId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingLogs_CampaignSendLogs_CampaignSendLogId",
                        column: x => x.CampaignSendLogId,
                        principalTable: "CampaignSendLogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingLogs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingLogs_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrackingLogs_MessageLogs_MessageLogId",
                        column: x => x.MessageLogId,
                        principalTable: "MessageLogs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "Group", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000000"), "dashboard.view", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1701), "Permission for dashboard.view", null, true, "dashboard.view" },
                    { new Guid("30000000-0000-0000-0000-000000000001"), "campaign.view", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1712), "Permission for campaign.view", null, true, "campaign.view" },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "campaign.create", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1716), "Permission for campaign.create", null, true, "campaign.create" },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "campaign.delete", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1719), "Permission for campaign.delete", null, true, "campaign.delete" },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "product.view", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1722), "Permission for product.view", null, true, "product.view" },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "product.create", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1727), "Permission for product.create", null, true, "product.create" },
                    { new Guid("30000000-0000-0000-0000-000000000006"), "product.delete", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1730), "Permission for product.delete", null, true, "product.delete" },
                    { new Guid("30000000-0000-0000-0000-000000000007"), "contacts.view", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1734), "Permission for contacts.view", null, true, "contacts.view" },
                    { new Guid("30000000-0000-0000-0000-000000000008"), "tags.edit", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1737), "Permission for tags.edit", null, true, "tags.edit" },
                    { new Guid("30000000-0000-0000-0000-000000000009"), "admin.business.approve", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1753), "Permission for admin.business.approve", null, true, "admin.business.approve" },
                    { new Guid("30000000-0000-0000-0000-000000000010"), "admin.logs.view", new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(1757), "Permission for admin.logs.view", null, true, "admin.logs.view" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "IsSystemDefined", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(852), "Super Admin", true, false, "admin" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(856), "Business Partner", true, false, "partner" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(858), "Reseller Partner", true, false, "reseller" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(860), "Business Owner", true, false, "business" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(862), "Staff", true, false, "staff" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "AssignedAt", "AssignedBy", "IsActive", "IsRevoked", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("079e80c6-323c-4a08-94a2-51bd604f4929"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2209), null, true, false, new Guid("30000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("37eabfd6-e9f8-498f-8532-d7dd7a3b80d7"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2225), null, true, false, new Guid("30000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3b9748e5-b4e1-4d9d-a962-71caa9954a8b"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2202), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3c4ce25c-0e01-417e-9449-eb52371f8166"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2257), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("47f15563-8f8a-4072-8654-c8b497de1ee6"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2248), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("55ec2d92-e5c7-4bf0-9fe9-3e2125e972b6"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2217), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6a15f715-fffc-4731-aedc-c905efaa8f37"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2213), null, true, false, new Guid("30000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7dbca6d5-8cb2-44ef-a4b8-4c74bbe632bd"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2186), null, true, false, new Guid("30000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("818c1856-92a1-4791-bf0e-3f4b9d19a694"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2253), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("925fabe1-5550-4418-9b2b-2e841f8fd598"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2192), null, true, false, new Guid("30000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b4438d9f-0f6c-4d90-8876-f8e5f44277ce"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2271), null, true, false, new Guid("30000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("c37fb295-55f6-4864-bce6-15fef6a141b4"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2281), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("e1f27aa9-0113-4c6c-92ee-dad1416bfc20"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2221), null, true, false, new Guid("30000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("e97935dc-a48a-4b8f-9cf6-985a2838e269"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2285), null, true, false, new Guid("30000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("eebb40df-29d7-48cb-991c-97bc78fde2fa"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2234), null, true, false, new Guid("30000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("f085246d-dd95-4ef7-9c6b-03079155e299"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2156), null, true, false, new Guid("30000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fae4e29c-e7a3-41e7-a591-e54220d55e51"), new DateTime(2025, 6, 17, 16, 23, 31, 798, DateTimeKind.Utc).AddTicks(2167), null, true, false, new Guid("30000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoReplyFlowEdges_FlowId",
                table: "AutoReplyFlowEdges",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoReplyFlowNodes_FlowId",
                table: "AutoReplyFlowNodes",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoReplyRules_FlowId",
                table: "AutoReplyRules",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlanInfos_BusinessId",
                table: "BusinessPlanInfos",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignButtons_CampaignId",
                table: "CampaignButtons",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignFlowOverrides_CampaignId",
                table: "CampaignFlowOverrides",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRecipients_BusinessId",
                table: "CampaignRecipients",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRecipients_CampaignId",
                table: "CampaignRecipients",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRecipients_ContactId",
                table: "CampaignRecipients",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_BusinessId",
                table: "Campaigns",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_CtaId",
                table: "Campaigns",
                column: "CtaId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_SourceCampaignId",
                table: "Campaigns",
                column: "SourceCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_CampaignId",
                table: "CampaignSendLogs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_ContactId",
                table: "CampaignSendLogs",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_MessageLogId",
                table: "CampaignSendLogs",
                column: "MessageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_RecipientId",
                table: "CampaignSendLogs",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignSendLogs_UserId",
                table: "CampaignSendLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactReads_ContactId_UserId",
                table: "ContactReads",
                columns: new[] { "ContactId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessId",
                table: "Contacts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTags_ContactId",
                table: "ContactTags",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTags_TagId",
                table: "ContactTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_CTAFlowSteps_CTAFlowConfigId",
                table: "CTAFlowSteps",
                column: "CTAFlowConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowButtonLinks_CTAFlowStepId",
                table: "FlowButtonLinks",
                column: "CTAFlowStepId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadTimelines_BusinessId",
                table: "LeadTimelines",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadTimelines_ContactId",
                table: "LeadTimelines",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_BusinessId",
                table: "MessageLogs",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_CampaignId",
                table: "MessageLogs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_ContactId",
                table: "MessageLogs",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageStatusLogs_BusinessId",
                table: "MessageStatusLogs",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageStatusLogs_CampaignId",
                table: "MessageStatusLogs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageStatusLogs_UserId",
                table: "MessageStatusLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingLogs_CampaignId",
                table: "TrackingLogs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingLogs_CampaignSendLogId",
                table: "TrackingLogs",
                column: "CampaignSendLogId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingLogs_ContactId",
                table: "TrackingLogs",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingLogs_MessageLogId",
                table: "TrackingLogs",
                column: "MessageLogId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessId",
                table: "Users",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WhatsAppSettings_BusinessId",
                table: "WhatsAppSettings",
                column: "BusinessId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "AutoReplyFlowEdges");

            migrationBuilder.DropTable(
                name: "AutoReplyFlowNodes");

            migrationBuilder.DropTable(
                name: "AutoReplyLogs");

            migrationBuilder.DropTable(
                name: "AutoReplyRules");

            migrationBuilder.DropTable(
                name: "BusinessPlanInfos");

            migrationBuilder.DropTable(
                name: "CampaignButtons");

            migrationBuilder.DropTable(
                name: "CampaignFlowOverrides");

            migrationBuilder.DropTable(
                name: "CatalogClickLogs");

            migrationBuilder.DropTable(
                name: "ChatSessionStates");

            migrationBuilder.DropTable(
                name: "ContactReads");

            migrationBuilder.DropTable(
                name: "ContactTags");

            migrationBuilder.DropTable(
                name: "FailedWebhookLogs");

            migrationBuilder.DropTable(
                name: "FlowButtonLinks");

            migrationBuilder.DropTable(
                name: "FlowExecutionLogs");

            migrationBuilder.DropTable(
                name: "LeadTimelines");

            migrationBuilder.DropTable(
                name: "MessageStatusLogs");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "TrackingLogs");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "WebhookSettings");

            migrationBuilder.DropTable(
                name: "WhatsAppSettings");

            migrationBuilder.DropTable(
                name: "AutoReplyFlows");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "CTAFlowSteps");

            migrationBuilder.DropTable(
                name: "CampaignSendLogs");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "CTAFlowConfigs");

            migrationBuilder.DropTable(
                name: "CampaignRecipients");

            migrationBuilder.DropTable(
                name: "MessageLogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CTADefinitions");

            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}

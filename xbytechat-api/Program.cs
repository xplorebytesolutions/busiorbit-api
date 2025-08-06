using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Exceptions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using xbytechat.api;
using xbytechat.api.AuthModule.Services;
using xbytechat.api.CRM.Interfaces;
using xbytechat.api.CRM.Services;
using xbytechat.api.Features.AccessControl.Services;
using xbytechat.api.Features.AuditTrail.Services;
using xbytechat.api.Features.CampaignModule.Services;
using xbytechat.api.Features.CampaignTracking.Services;
using xbytechat.api.Features.Catalog.Services;
using xbytechat.api.Features.MessageManagement.Services;
using xbytechat.api.Features.MessagesEngine.PayloadBuilders;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Features.PlanManagement.Services;
using xbytechat.api.Features.TemplateModule.Services;
using xbytechat.api.Features.Webhooks.Services;
using xbytechat.api.Features.Webhooks.Services.Processors;
using xbytechat.api.Features.Webhooks.Services.Resolvers;
using xbytechat.api.Features.xbTimeline.Services;
using xbytechat.api.Features.xbTimelines.Services;
using xbytechat.api.Helpers;
using xbytechat.api.Middlewares;
using xbytechat.api.PayloadBuilders;
using xbytechat.api.Repositories.Implementations;
using xbytechat.api.Repositories.Interfaces;
using xbytechat.api.Services;
using xbytechat.api.Services.Messages.Implementations;
using xbytechat.api.Services.Messages.Interfaces;
using xbytechat_api.WhatsAppSettings.Services;
using xbytechat_api.WhatsAppSettings.Validators;
using EnginePayloadBuilders = xbytechat.api.Features.MessagesEngine.PayloadBuilders;
using xbytechat.api.Features.CTAManagement.Services;
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Features.Webhooks.BackgroundWorkers;
using xbytechat.api.Features.CTAFlowBuilder.Services;
using xbytechat.api.Features.FlowAnalytics.Services;
using xbytechat.api.Features.Inbox.Repositories;
using xbytechat.api.Features.Inbox.Services;
using xbytechat.api.Features.Inbox.Hubs;
using Microsoft.AspNetCore.SignalR;
using xbytechat.api.SignalR;
using xbytechat.api.Features.AutoReplyBuilder.Repositories;
using xbytechat.api.Features.AutoReplyBuilder.Services;
using xbytechat.api.Features.AutoReplyBuilder.Flows.Repositories;
using xbytechat.api.Features.AutoReplyBuilder.Flows.Services;
using xbytechat.api.Features.BusinessModule.Services;
using xbytechat.api.Features.FeatureAccessModule.Services;
using xbytechat.api.Features.ReportingModule.Services;
using xbytechat.api.Features.Automation.Repositories;
using xbytechat.api.Features.Automation.Services;


var builder = WebApplication.CreateBuilder(args);

#region 🔷 Serilog Configuration
Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionDetails()
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();
#endregion

//#region 🔷 Database Setup (PostgreSQL)
//var connStr = builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
//Console.WriteLine($"[DEBUG] Using Connection String: {connStr}");
//#endregion
#region Database Setup (PostgreSQL)
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");  // Get actual string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connStr).EnableSensitiveDataLogging()
);
Console.WriteLine($"[DEBUG] Using Connection String: {connStr}"); // This prints the REAL connection string
#endregion

#region 🔷 Generic Repository Pattern
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
#endregion

#region 🔷 Core Modules (Business/Auth)
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
#endregion

#region 🔷 Messaging Services & WhatsApp
builder.Services.AddScoped<IMessageEngineService, MessageEngineService>(); // New

builder.Services.AddHttpClient<IMessageService, MessageService>();
builder.Services.AddScoped<WhatsAppService>();
builder.Services.AddScoped<IMessageStatusService, MessageStatusService>();
builder.Services.AddScoped<ITemplateMessageSender, TemplateMessageSender>();
#endregion

#region 🔷 Payload Builders
builder.Services.AddScoped<xbytechat.api.PayloadBuilders.IWhatsAppPayloadBuilder, xbytechat.api.PayloadBuilders.TextMessagePayloadBuilder>();
builder.Services.AddScoped<xbytechat.api.PayloadBuilders.IWhatsAppPayloadBuilder, xbytechat.api.PayloadBuilders.ImageMessagePayloadBuilder>();
builder.Services.AddScoped<xbytechat.api.PayloadBuilders.IWhatsAppPayloadBuilder, xbytechat.api.PayloadBuilders.TemplateMessagePayloadBuilder>();
#endregion

#region 🔷 Catalog & CRM Modules
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICatalogTrackingService, CatalogTrackingService>();
builder.Services.AddScoped<ICatalogDashboardService, CatalogDashboardService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ITimelineService, TimelineService>();

#endregion

#region 🔷 Campaign Management
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<ICampaignSendLogService, CampaignSendLogService>();
builder.Services.AddScoped<ICampaignSendLogEnricher, CampaignSendLogEnricher>();
builder.Services.AddScoped<ICampaignAnalyticsService, CampaignAnalyticsService>();

builder.Services.AddScoped<ICampaignRetryService, CampaignRetryService>();
builder.Services.AddHttpClient<IWhatsAppTemplateService, WhatsAppTemplateService>();
builder.Services.AddScoped<ICampaignAnalyticsService, CampaignAnalyticsService>();
builder.Services.AddScoped<ICampaignRecipientService, CampaignRecipientService>();

#endregion

#region 🔷 Webhook Management
builder.Services.AddScoped<IWhatsAppWebhookService, WhatsAppWebhookService>();
builder.Services.AddScoped<IWhatsAppWebhookDispatcher, WhatsAppWebhookDispatcher>();
builder.Services.AddScoped<IStatusWebhookProcessor, StatusWebhookProcessor>();
builder.Services.AddScoped<ITemplateWebhookProcessor, TemplateWebhookProcessor>();
builder.Services.AddScoped<IMessageIdResolver, MessageIdResolver>();
builder.Services.AddScoped<IClickWebhookProcessor, ClickWebhookProcessor>();
builder.Services.AddScoped<ILeadTimelineService, LeadTimelineService>();
builder.Services.AddScoped<IFailedWebhookLogService, FailedWebhookLogService>();
builder.Services.AddSingleton<IWebhookQueueService, WebhookQueueService>();
builder.Services.AddHostedService<WebhookQueueWorker>();
builder.Services.AddHostedService<FailedWebhookLogCleanupService>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
builder.Services.AddHostedService<WebhookAutoCleanupWorker>();

#endregion

#region 🔷 Access Control & Permission
builder.Services.AddScoped<IAccessControlService, AccessControlService>();
builder.Services.AddScoped<IFeatureAccessEvaluator, FeatureAccessEvaluator>();
builder.Services.AddScoped<IFeatureAccessService, FeatureAccessService>();
#endregion

#region 🔷 Tracking 
builder.Services.AddScoped<ITrackingService, TrackingService>();
builder.Services.AddScoped<IMessageAnalyticsService, MessageAnalyticsService>();

#endregion
#region 🔷 Flow Builder 
builder.Services.AddScoped<ICTAFlowService, CTAFlowService>();

#endregion
#region 🔷 Audit Trail Logging
builder.Services.AddHttpContextAccessor(); // For Audit + Cookies
builder.Services.AddScoped<IAuditLogService, AuditLogService>();


#endregion
#region 🔷 WhatsApp settings
builder.Services.AddScoped<IWhatsAppSettingsService, WhatsAppSettingsService>();
builder.Services.AddValidatorsFromAssemblyContaining<SaveWhatsAppSettingValidator>();
builder.Services.AddHttpClient<IMessageEngineService, MessageEngineService>();
builder.Services.AddScoped<IWhatsAppTemplateFetcherService, WhatsAppTemplateFetcherService>();

// ✅ Force DI to use correct class from MessagesEngine.PayloadBuilders
builder.Services.AddScoped<EnginePayloadBuilders.TextMessagePayloadBuilder>();
builder.Services.AddScoped<EnginePayloadBuilders.ImageMessagePayloadBuilder>();
builder.Services.AddScoped<EnginePayloadBuilders.TemplateMessagePayloadBuilder>();
builder.Services.AddScoped<EnginePayloadBuilders.CtaMessagePayloadBuilder>();
builder.Services.AddScoped<IPlanManager, PlanManager>();
builder.Services.AddScoped<ICTAManagementService, CTAManagementService>();


#endregion
#region 🔷 Inbox 
builder.Services.AddScoped<IFlowAnalyticsService, FlowAnalyticsService>();
builder.Services.AddScoped<IInboxService, InboxService>();
builder.Services.AddScoped<IInboundMessageProcessor, InboundMessageProcessor>();
builder.Services.AddScoped<IInboxRepository, InboxRepository>();
#endregion 

// AutoReplyBuilder Module
builder.Services.AddScoped<IAutoReplyRepository, AutoReplyRepository>();
builder.Services.AddScoped<IAutoReplyService, AutoReplyService>();
builder.Services.AddScoped<IAutoReplyFlowRepository, AutoReplyFlowRepository>();
builder.Services.AddScoped<IAutoReplyFlowService, AutoReplyFlowService>();
builder.Services.AddScoped<IAutoReplyRuntimeService, AutoReplyRuntimeService>();
builder.Services.AddScoped<IChatSessionStateService, ChatSessionStateService>();
builder.Services.AddScoped<IAgentAssignmentService, AgentAssignmentService>();

// 🧠 Automation Module - Dependency Injection
builder.Services.AddScoped<IAutomationFlowRepository, AutomationFlowRepository>();
builder.Services.AddScoped<IAutomationRunner, AutomationRunner>();
builder.Services.AddScoped<IAutomationService, AutomationService>();


#region 🔐 JWT Authentication (Token + Cookie Based)
#region 🔐 JWT Authentication (Secure Cookie + Expiry Handling)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
            ClockSkew = TimeSpan.Zero // No token grace period
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["xbyte_token"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                if (context.Exception is SecurityTokenExpiredException)
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync("{\"success\":false,\"message\":\"❌ Token expired. Please login again.\"}");
                }
                return Task.CompletedTask;
            }
        };
    });



builder.Services.AddAuthorization();
#endregion
#endregion
#region 🌐 CORS Setup (Secure Cookie-Compatible)

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend", policy =>
//    {
//        policy.WithOrigins("busiorbit-ui-c0dbc0crazd6bae4.centralindia-01.azurewebsites.net") // ✅ React dev URL
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials(); // ✅ Needed for httpOnly cookie
//    });
//});
#endregion

#region ✅ MVC + Swagger + Middleware
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(

//    );
try
{
    builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "xByteChat API",
        Version = "v1",
        Description = "API documentation for xByteChat project"
    });

    // Optional: include XML comments if enabled
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});
}
catch (Exception ex)
{
    Console.WriteLine("⚠️ Swagger registration failed: " + ex.Message);
}
#endregion
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#region ✅ For output in visual studio code
builder.Logging.ClearProviders();         // Clear default log providers
builder.Logging.AddConsole();             // Add console logging

#region SignalR
builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, NameUserIdProvider>();


#endregion
var app = builder.Build();

#region 🌐 Middleware Pipeline Setup
AuditLoggingHelper.Configure(app.Services);

app.UseMiddleware<GlobalExceptionMiddleware>();
/*/*app.UseMiddleware<JwtErrorHandlingMiddleware>();*/// ✅ Handle JWT Expired errors
#endregion
if (app.Environment.IsDevelopment())
{
   
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
// ✅ Secure CORS policy applied BEFORE auth
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<InboxHub>("/hubs/inbox");
app.Run();
#endregion






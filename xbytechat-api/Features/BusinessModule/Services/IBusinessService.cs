﻿using System.Runtime.CompilerServices;
using xbytechat.api.Features.BusinessModule.DTOs;
using xbytechat.api.Features.BusinessModule.Models;
using xbytechat.api.Helpers;
using xbytechat.api.Models;
namespace xbytechat.api.Features.BusinessModule.Services
{

    public interface IBusinessService
    {
        IQueryable<Business> Query();
        //  This is move to AuthController 
        Task<ResponseResult> SignupBusinessAsync(SignupBusinessDto dto); /// Signup + create admin user

        //  Task<List<PendingBusinessDto>> GetPendingBusinessesAsync();      // Admin: list of unapproved businesses
        Task<ResponseResult> ApproveBusinessAsync(Guid businessId);      // Admin action
        Task<ResponseResult> RejectBusinessAsync(Guid businessId);       // Admin action
        Task<ResponseResult> HoldBusinessAsync(Guid businessId);         // Admin action
        Task<ResponseResult> CompleteProfileAsync(Guid businessId, ProfileCompletionDto dto); // Post-login completion
        Task<Business?> GetBusinessByEmailAsync(string email);
        Task<Business?> GetByIdAsync(Guid businessId);
        Task<ResponseResult> UpdateBusinessAsync(Business business);
        Task<List<PendingBusinessDto>> GetPendingBusinessesAsync(string role, string userId);
        Task<List<Business>> GetApprovedBusinessesAsync();
    }

}

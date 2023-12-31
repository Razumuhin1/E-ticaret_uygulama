﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplicationProjeUI.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<IdentityUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kullanıcı kimliği yüklenemiyor '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"Şu anda etkin olmadığından kullanıcı için iki faktörlü kimlik doğrulama devre dışı bırakılamıyor.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Kullanıcı kimliği yüklenemiyor '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"İki faktörlü kimlik doğrulama devre dışı bırakılırken beklenmeyen bir hata oluştu.");
            }

            _logger.LogInformation("'{UserId}' kimliğine sahip kullanıcı iki faktörlü kimlik doğrulamayı devre dışı bıraktı.", _userManager.GetUserId(User));
            StatusMessage = "İki faktörlü kimlik doğrulama devre dışı bırakıldı. Bir kimlik doğrulama uygulaması kurduğunuzda iki faktörlü kimlik doğrulamayı yeniden etkinleştirebilirsiniz";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}

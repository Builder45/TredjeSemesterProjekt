// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeboerWeb.MVC.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPersonService _personService;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IPersonService personService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _personService = personService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Loginnavn { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }


        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Telefonnummer")]
            public string Telefonnr { get; set; }

            [Display(Name ="Fornavn")]
            public string Fornavn { get; set; }

            [Display(Name = "Efternavn")]
            public string Efternavn { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userId = await _userManager.GetUserIdAsync(user);

            var person = await _personService.GetPersonByUserAsync(Guid.Parse(userId));

            var userName = await _userManager.GetUserNameAsync(user);
            var telefonNr = person.Telefonnr;


            Loginnavn = userName;

            Input = new InputModel
            {
                Fornavn = person.Fornavn,
                Efternavn = person.Efternavn,
                Telefonnr = Convert.ToString(telefonNr)
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);
            var person = await _personService.GetPersonByUserAsync(Guid.Parse(userId));

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = Convert.ToString(person.Telefonnr);
            var fornavn = person.Fornavn;
            var efternavn = person.Efternavn;
            var telefonNr = person.Telefonnr;

            if (Input.Telefonnr != phoneNumber || Input.Fornavn != fornavn || Input.Efternavn != efternavn )
            {

                PersonDTO newPerson = new PersonDTO { Id = person.Id, Fornavn = Input.Fornavn, Efternavn = Input.Efternavn, Telefonnr = Convert.ToInt32(Input.Telefonnr), BrugerId = person.BrugerId };

                await _personService.UpdatePersonAsync(newPerson); 

                //if (!setPhoneResult.Succeeded)
                //{
                //    StatusMessage = "Unexpected error when trying to set phone number.";
                //    return RedirectToPage();
                //}
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

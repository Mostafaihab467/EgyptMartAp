using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace EgyptMart.Services.ProductsAPI.Validations
{
    public class AuthUserValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var httpContextAccessor = validationContext.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
            if (httpContextAccessor == null)
            {
                return new ValidationResult("Unable to access HTTP context.");
            }

            var user = httpContextAccessor.HttpContext?.User;
            var jwtUserId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (jwtUserId == null)
            {
                return new ValidationResult("User ID claim not found in JWT.");
            }

            if (value == null || value.ToString() != jwtUserId)
            {
                return new ValidationResult("User ID does not match the authenticated user.");
            }

            return ValidationResult.Success;
        }
    }
}

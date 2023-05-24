using System.ComponentModel.DataAnnotations;

namespace TesteComercio.Common
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "Sucesso")]
        Success = 0,

        [Display(Name = "Server Error")]
        ServerError = 1,

        [Display(Name = "BadRequest")]
        BadRequest = 2,

        [Display(Name = "NotFound")]
        NotFound = 3,

        [Display(Name = "ListEmpty")]
        ListEmpty = 4,

        [Display(Name = "LogicError")]
        LogicError = 5,

        [Display(Name = "UnAuthorized")]
        UnAuthorized = 6
    }
}

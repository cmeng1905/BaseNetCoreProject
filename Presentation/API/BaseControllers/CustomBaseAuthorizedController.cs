using Microsoft.AspNetCore.Authorization;

namespace API.BaseControllers
{
    [Authorize]
    public class CustomBaseAuthorizedController : CustomBaseController
    {
    }
}

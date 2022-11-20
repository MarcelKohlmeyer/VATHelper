using Microsoft.AspNetCore.Mvc;

namespace VATHelper.Base;

public class VatHelperControllerBase : ControllerBase
{
    public IActionResult GenerateSuccessResponse(object result)
    {
        return new OkObjectResult(result);
    }
}
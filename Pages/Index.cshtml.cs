using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotnet6razor.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IOperationTransient _transientOperation;
    private readonly IOperationSingleton _singletonOperation;
    private readonly IOperationScoped _scopedOperation;
    private readonly Service1 _service;
    private readonly Service2 _service2;
    public IndexModel(ILogger<IndexModel> logger,
                       IOperationTransient transientOperation,
                       IOperationScoped scopedOperation,
                       IOperationSingleton singletonOperation, Service1 service1, Service2 service2)
    {
        _logger = logger;
        _transientOperation = transientOperation;
        _scopedOperation = scopedOperation;
        _singletonOperation = singletonOperation;
        _service = service1;
        _service2 = service2;
    }


    public void OnGet()
    {
        _logger.LogInformation("Transient: " + _transientOperation.OperationId);
        _logger.LogInformation("Scoped: " + _scopedOperation.OperationId);
        _logger.LogInformation("Singleton: " + _singletonOperation.OperationId);
        _service.Write("_service.Write");
        _service2.Write("_service2.Write");
    }


}

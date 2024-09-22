using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using SOAP.Model;
namespace SOAP.Controllers;

[ApiController]
[Route("[controller]")]

public abstract class SOAPControllerBase : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IWebHostEnvironment _env;

    protected SOAPVersion SOAPVersion { get; init; }

    protected SOAPControllerBase(ILogger logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;

        SOAPControllerAttribute? soapversionAttribute = Attribute.GetCustomAttribute(GetType(), typeof(SOAPControllerAttribute)) as SOAPControllerAttribute;
        if (soapversionAttribute is null)
        {
            throw new Exception("class deriving from SOAPControllerBase is missing the SOAPController attribute");
        }
        else
        {
            SOAPVersion = soapversionAttribute.SOAPVersion;
        }
    }

    public virtual SOAPResponseEnvelope CreateSOAPResponseEnvelope() => SOAPVersion == SOAPVersion.v1_1 ? new SOAP1_1ResponseEnvelope() : new SOAP1_2ResponseEnvelope();

    #region WSDL Handling
    [HttpGet]
    public IActionResult Get(string? wsdl, string? xsd)
    {
        var controllername = ControllerContext.RouteData.Values["controller"]?.ToString();
        if (wsdl is not null)
        {
            return ProcessWsdlFile($"~/wsdl/{(controllername is null ? "" : controllername + "/")}{(wsdl == string.Empty ? "" : wsdl)}");
        }
        if (xsd is not null)
        {
            if (xsd == string.Empty)
            {
                return BadRequest("xsd parameter cannot be empty");
            }
            else
            {
                return ProcessWsdlFile($"~/wsdl/{(controllername is null ? "" : controllername + "/")}{xsd}.xml");
            }
        }
        return BadRequest("invalid request");
    }

    protected ActionResult ProcessWsdlFile(string path)
    {
        var _baseURL = $"{Request.Scheme}://{Request.Host}{Request.Path}";
        // Convert virtual path to physical
        if (path.StartsWith("~"))
        {
            path = path.Replace("~", _env.ContentRootPath);
        }
        String content;
        try
        {
            content = System.IO.File.ReadAllText(path, Encoding.UTF8);
        }
        catch (DirectoryNotFoundException)
        {
            // TODO should be a SOAPFault
            return new ObjectResult("wsdl directory not found") { StatusCode = StatusCodes.Status500InternalServerError };
        }
        catch (FileNotFoundException)
        {
            return new ObjectResult("wsdl file not found") { StatusCode = StatusCodes.Status500InternalServerError };
        }
        // Replace placeholder with actual values
        content = content.Replace("{SERVICEURL}", _baseURL);
        return File(Encoding.UTF8.GetBytes(content), "text/xml;charset=UTF-8");


    }
    #endregion
}
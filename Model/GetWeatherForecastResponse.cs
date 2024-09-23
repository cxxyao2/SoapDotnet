using System.Xml.Serialization;
using DotnetSoapStart;
using SOAP.Model;

// [XmlType(Namespace = "")]
public class GetWeatherForecastResponse
{
    // [XmlNamespaceDeclarations]
    // public XmlSerializerNamespaces? ns = new XmlSerializerNamespaces();

    // public GetWeatherForecastResponse()
    // {
    //     ns.Add(SOAPResponseBody.DefaultNamespacePrefix, SOAPResponseBody.DefaultNamespace);
    // }
    public WeatherForecast[]? WeatherForecasts { get; set; }
}
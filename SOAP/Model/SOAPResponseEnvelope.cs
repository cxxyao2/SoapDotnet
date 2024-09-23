using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
namespace SOAP.Model;

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_1Namespace)]
public partial class SOAP1_1ResponseEnvelope : SOAPResponseEnvelope
{
    public SOAP1_1ResponseEnvelope()
    {
        ns.Add(SOAPConstants.DefaultSOAPEnvelopeNamespacePrefix, SOAPConstants.SOAP1_1Namespace);
    }
}

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_2Namespace)]
public partial class SOAP1_2ResponseEnvelope : SOAPResponseEnvelope
{
    public SOAP1_2ResponseEnvelope()
    {
        ns.Add(SOAPConstants.DefaultSOAPEnvelopeNamespacePrefix, SOAPConstants.SOAP1_2Namespace);
    }
}


public abstract partial class SOAPResponseEnvelope
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    protected SOAPResponseBody? _body;

    [NotNull]
    public SOAPResponseBody? Body
    {
        get
        {
            if (_body is null)
            {
                _body = new SOAPResponseBody();
            }
            return _body;
        }
        set { _body = value; }
    }
}

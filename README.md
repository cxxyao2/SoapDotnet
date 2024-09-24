# SOAP in .NET

## SOAP

- HTTP
- XML

## SOAP MESSAGE

- Envelope
- Body
- Header
- Fault

## vs code extensions:

- httpYAC : REST client
- XML Tools: XML Formatting, XQuery, XPath Tools etc.

## vs code setting

- settings.json

```
{
    "editor.formatOnSave": true
}
```

## Commands

- Dotnet new webapi
- dotnet add package serilog.aspnetcore
- vscode (windows) : ctrl+p = => input bar: shift+ >.net ==> select "generate assets for build"

## Test tools

- SoapUI

- postman
  ![request-response-in-postman](/Screenshots/request-response.png)
- vs code extension: httpYAC

## SOAP Knowledge

- In the SOAP (Simple Object Access Protocol) protocol, an **envelope** is the outermost element that defines the overall structure of a SOAP message. It acts as a container for the message and ensures that both the message content and any processing instructions are properly formatted.

The SOAP envelope is divided into two main parts:

1. **Header (optional)**: Contains metadata and additional information, such as security tokens, authentication, or transaction context. This section is optional and can be used to convey data that is not part of the core message but is still relevant to the processing of the message.

2. **Body (mandatory)**: Contains the actual message or data being exchanged, such as a request or response in a web service interaction. The body is the essential part that holds the application-specific content or SOAP fault information if an error occurs.

Here’s an example of a basic SOAP envelope structure:

```xml
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Header>
    <!-- Optional metadata -->
  </soap:Header>
  <soap:Body>
    <!-- The main content or request/response data -->
  </soap:Body>
</soap:Envelope>
```

In essence, the envelope ensures that SOAP messages are standardized and interpretable across different systems in a web services environment.

- xml namespace: avoid name conflict.
  when a namespace is defined for an element, all child elements with the same prefix are associated with the same namespace
  <root>

<h:table xmlns:h="http://www.w3.org/TR/htmll4/">
<h:tr>
<h:td>Apples</h:td>
<h:td>Bananas</h:td>
</h:table>

<f:table xmlns:f="http://www.w3.org/TR/fur">
<f:tr>
<f:td>Apples</f:td>
<f:td>Bananas</f:td>
</f:table>

</root>

- Namespaces can also be declared in the XML root elements
- XPath is a major element in the XSLT standard.

XPath can be used to navigate through elements and attributes in an XML document.

```
Path Expression	Result
/bookstore/book[1]	Selects the first book element that is the child of the bookstore element
/bookstore/book[last()]	Selects the last book element that is the child of the bookstore element
/bookstore/book[last()-1]	Selects the last but one book element that is the child of the bookstore element
```

```
<root xmlns:h="http://www.w3.org/TR/html4/" xmlns:f="https://www.w3.com/fur">...</root>
```

## Project notes

### Sep.20. 2024

- typo: envolope ==> envelope

XML Schema:
Objective:
replace DTD. + define the strcutre of XML file
e.g
```
<xs:element name="note">

<xs:complexType>
<xs:sequence>
<xs:element name="to" type="xs:string"/>
<xs:element name="from" type="xs:string"/>
<xs:element name="heading" type="xs:string"/>
<xs:element name="body" type="xs:string"/>
</xs:sequence>
</xs:complexType>

</xs:element>
```

compared to DTD
```
PCDATA: parsed string, e.g.
<message>This text is also parsed</message>

CDATA:
CDATA  begins with "<![CDATA[, ends with "]]>". 
e.g. "<" ,"&" should not be parsed by XMLParser. put them in CDATA.

<?xml version="1.0"?>
<!DOCTYPE note [
<!ELEMENT note (to,from,heading,body)>
<!ELEMENT to (#PCDATA)>
<!ELEMENT from (#PCDATA)>
<!ELEMENT heading (#PCDATA)>
<!ELEMENT body (#PCDATA)>
]>
<note>
<to>Tove</to>
<from>Jani</from>
<heading>Reminder</heading>
<body>Don't forget me this weekend</body>
```

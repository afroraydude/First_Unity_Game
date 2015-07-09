<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="game">
    <xs:complexType>
      <xs:sequence>
        <xs:element name="info">
          <xs:complexType>
            <xs:sequence>
              <xs:element type="xs:string" name="name"/>
              <xs:element type="xs:anyURI" name="url"/>
              <xs:element type="xs:string" name="version"/>
              <xs:element type="xs:string" name="isOnline"/>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element name="level" maxOccurs="unbounded" minOccurs="0">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="time">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element type="xs:byte" name="a"/>
                    <xs:element type="xs:byte" name="b"/>
                    <xs:element type="xs:byte" name="c"/>
                    <xs:element type="xs:byte" name="d"/>
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
              <xs:element name="death">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element type="xs:byte" name="a"/>
                    <xs:element type="xs:byte" name="b"/>
                    <xs:element type="xs:byte" name="c"/>
                    <xs:element type="xs:byte" name="d"/>
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
            <xs:attribute type="xs:byte" name="id" use="optional"/>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>

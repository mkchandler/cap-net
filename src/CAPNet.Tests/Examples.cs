namespace CAPNet.Tests
{
    static internal class Examples
    {
        public const string Thunderstorm12Xml = @"<?xml version = ""1.0"" encoding = ""UTF-8""?>
<alert xmlns = ""urn:oasis:names:tc:emergency:cap:1.2"">
  <identifier>KSTO1055887203</identifier> 
  <sender>KSTO@NWS.NOAA.GOV</sender> 
  <sent>2003-06-17T14:57:00-07:00</sent>
  <status>Actual</status> 
  <msgType>Alert</msgType>
  <scope>Public</scope> 
  <info>
    <category>Met</category>   
    <event>SEVERE THUNDERSTORM</event>
    <responseType>Shelter</responseType> 
    <urgency>Immediate</urgency>   
    <severity>Severe</severity>   
    <certainty>Observed</certainty>
    <eventCode>
      <valueName>SAME</valueName>
      <value>SVR</value>
    </eventCode>
    <expires>2003-06-17T16:00:00-07:00</expires>  
    <senderName>NATIONAL WEATHER SERVICE SACRAMENTO CA</senderName>
    <headline>SEVERE THUNDERSTORM WARNING</headline>
    <description> AT 254 PM PDT...NATIONAL WEATHER SERVICE DOPPLER RADAR INDICATED A SEVERE THUNDERSTORM OVER SOUTH CENTRAL ALPINE COUNTY...OR ABOUT 18 MILES SOUTHEAST OF KIRKWOOD...MOVING SOUTHWEST AT 5 MPH. HAIL...INTENSE RAIN AND STRONG DAMAGING WINDS ARE LIKELY WITH THIS STORM.</description>
    <instruction>TAKE COVER IN A SUBSTANTIAL SHELTER UNTIL THE STORM PASSES.</instruction>
    <contact>BARUFFALDI/JUSKIE</contact>
    <area>       
      <areaDesc>EXTREME NORTH CENTRAL TUOLUMNE COUNTY IN CALIFORNIA, EXTREME NORTHEASTERN CALAVERAS COUNTY IN CALIFORNIA, SOUTHWESTERN ALPINE COUNTY IN CALIFORNIA</areaDesc>
      <polygon>38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14</polygon>
      <geocode>
        <valueName>SAME</valueName>
        <value>006109</value>
      </geocode>
      <geocode>
        <valueName>SAME</valueName>
        <value>006009</value>
      </geocode>
      <geocode>
        <valueName>SAME</valueName>
        <value>006003</value>
      </geocode>
    </area>
  </info>
</alert>";

        public const string Thunderstorm12AllDatesXml = @"<?xml version = ""1.0"" encoding = ""UTF-8""?>
<alert xmlns = ""urn:oasis:names:tc:emergency:cap:1.2"">
  <identifier>KSTO1055887203</identifier> 
  <sender>KSTO@NWS.NOAA.GOV</sender> 
  <sent>2003-06-17T14:57:00-07:00</sent>
  <status>Actual</status> 
  <msgType>Alert</msgType>
  <scope>Public</scope> 
  <info>
    <category>Met</category>   
    <event>SEVERE THUNDERSTORM</event>
    <responseType>Shelter</responseType> 
    <urgency>Immediate</urgency>   
    <severity>Severe</severity>   
    <certainty>Observed</certainty>
    <eventCode>
      <valueName>SAME</valueName>
      <value>SVR</value>
    </eventCode>
    <effective>2003-06-17T15:00:00-07:00</effective>
    <onset>2003-06-17T15:30:00-07:00</onset>
    <expires>2003-06-17T16:00:00-07:00</expires>
    <senderName>NATIONAL WEATHER SERVICE SACRAMENTO CA</senderName>
    <headline>SEVERE THUNDERSTORM WARNING</headline>
    <description> AT 254 PM PDT...NATIONAL WEATHER SERVICE DOPPLER RADAR INDICATED A SEVERE THUNDERSTORM OVER SOUTH CENTRAL ALPINE COUNTY...OR ABOUT 18 MILES SOUTHEAST OF KIRKWOOD...MOVING SOUTHWEST AT 5 MPH. HAIL...INTENSE RAIN AND STRONG DAMAGING WINDS ARE LIKELY WITH THIS STORM.</description>
    <instruction>TAKE COVER IN A SUBSTANTIAL SHELTER UNTIL THE STORM PASSES.</instruction>
    <contact>BARUFFALDI/JUSKIE</contact>
    <area>       
      <areaDesc>EXTREME NORTH CENTRAL TUOLUMNE COUNTY IN CALIFORNIA, EXTREME NORTHEASTERN CALAVERAS COUNTY IN CALIFORNIA, SOUTHWESTERN ALPINE COUNTY IN CALIFORNIA</areaDesc>
      <polygon>38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14</polygon>
      <geocode>
        <valueName>SAME</valueName>
        <value>006109</value>
      </geocode>
      <geocode>
        <valueName>SAME</valueName>
        <value>006009</value>
      </geocode>
      <geocode>
        <valueName>SAME</valueName>
        <value>006003</value>
      </geocode>
    </area>
  </info>
</alert>";

        public const string ThunderstormUpdate12Xml = @"<?xml version = ""1.0"" encoding = ""UTF-8""?>
<alert xmlns = ""urn:oasis:names:tc:emergency:cap:1.2"">
  <identifier>KSTO1055887203</identifier> 
  <sender>KSTO@NWS.NOAA.GOV</sender> 
  <sent>2003-06-17T14:57:00-07:00</sent>
  <status>Actual</status>
  <msgType>Update</msgType>
  <scope>Restricted</scope>
  <restriction>Only people with glasses should receive this update.</restriction>
  <info>
    <category>Met</category>
    <event>SEVERE THUNDERSTORM</event>
    <responseType>Shelter</responseType>
    <urgency>Immediate</urgency>
    <severity>Severe</severity>
    <certainty>Observed</certainty>
    <eventCode>
      <valueName>SAME</valueName>
      <value>SVR</value>
    </eventCode>
    <expires>2003-06-17T16:00:00-07:00</expires>  
    <senderName>NATIONAL WEATHER SERVICE SACRAMENTO CA</senderName>
    <headline>SEVERE THUNDERSTORM WARNING</headline>
    <description>UPDATED DESCRIPTION.</description>
    <instruction>TAKE COVER IN A SUBSTANTIAL SHELTER UNTIL THE STORM PASSES.</instruction>
    <contact>BARUFFALDI/JUSKIE</contact>
    <area>       
      <areaDesc>EXTREME NORTH CENTRAL TUOLUMNE COUNTY IN CALIFORNIA, EXTREME NORTHEASTERN CALAVERAS COUNTY IN CALIFORNIA, SOUTHWESTERN ALPINE COUNTY IN CALIFORNIA</areaDesc>
      <polygon>38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14</polygon>
      <geocode>
        <valueName>SAME</valueName>
        <value>006109</value>
      </geocode>
      <geocode>
        <valueName>SAME</valueName>
        <value>006009</value>
      </geocode>
      <geocode>
        <valueName>SAME</valueName>
        <value>006003</value>
      </geocode>
    </area>
  </info>
</alert>";

        public const string OrangeAlertXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<alert xmlns=""urn:oasis:names:tc:emergency:cap:1.2"">
  <identifier>43b080713727</identifier>
  <sender>hsas@dhs.gov</sender>
  <sent>2003-04-02T14:39:01-05:00</sent>
  <status>Actual</status>
  <msgType>Alert</msgType>
  <scope>Public</scope>
  <source>source</source>
  <restriction>restriction</restriction>
  <addresses>addresses</addresses>
  <code>code</code>
  <note>note</note>
  <references>references</references>
  <incidents>incidents</incidents>
  <info>
    <category>Security</category>
    <event>Homeland Security Advisory System Update</event>
    <responsetype>Shelter</responsetype>
    <urgency>Immediate</urgency>
    <severity>Severe</severity>
    <certainty>Likely</certainty>
    <audience>audience</audience>
    <eventCode>
      <valueName>valN</valueName>
      <value>val</value>
    </eventCode>
    <effective>2003-04-02T14:39:01-05:00</effective>
    <onset>2003-04-02T14:39:01-05:00</onset>
    <expires>2003-04-02T14:39:01-05:00</expires>
    <senderName>U.S. Government, Department of Homeland Security</senderName>
    <headline>Homeland Security Sets Code ORANGE</headline>
    <description>The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.</description>
    <instruction>A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.</instruction>
    <web>http://www.dhs.gov/dhspublic/display?theme=29</web>
    <contact>contact</contact>
    <parameter>
      <valueName>HSAS</valueName>
      <value>ORANGE</value>
    </parameter>
    <resource>
      <resourceDesc>Image file (GIF)</resourceDesc>
      <mimeType>image/gif</mimeType>
      <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
    </resource>
    <area>
      <areaDesc>U.S. nationwide and interests worldwide</areaDesc>
    </area>
  </info>
</alert>";

        public const string VeryLikelyOrangeAlertXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<alert xmlns=""urn:oasis:names:tc:emergency:cap:1.2"">
  <identifier>43b080713727</identifier>
  <sender>hsas@dhs.gov</sender>
  <sent>2003-04-02T14:39:01-05:00</sent>
  <status>Actual</status>
  <msgType>Alert</msgType>
  <scope>Public</scope>
  <info>
    <category>Security</category>
    <event>Homeland Security Advisory System Update</event>
    <urgency>Immediate</urgency>
    <severity>Severe</severity>
    <certainty>Very Likely</certainty>
    <senderName>U.S. Government, Department of Homeland Security</senderName>
    <headline>Homeland Security Sets Code ORANGE</headline>
    <description>The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.</description>
    <instruction>A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.</instruction>
    <web>http://www.dhs.gov/dhspublic/display?theme=29</web>
    <parameter>
      <valueName>HSAS</valueName>
      <value>ORANGE</value>
    </parameter>
    <resource>
      <resourceDesc>Image file (GIF)</resourceDesc>
      <mimeType>image/gif</mimeType>
      <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
    </resource>
    <area>
      <areaDesc>U.S. nationwide and interests worldwide</areaDesc>
    </area>
  </info>
</alert>";
    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="assign5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


a {
  color: #428bca;
  text-decoration: none;
}

  a {
    text-decoration: underline;
  }
  
* {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}

  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    box-shadow: none !important;
  }
  
b {
  font-weight: bold;
}

        .auto-style1 {
            height: 146px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
       
            &nbsp;&nbsp;&nbsp;&nbsp;<br />
            <h1>Assignment 5</h1><h2>PUBLIC PAGE</h2>
        
        <h3>
            MEMBERS</h3>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="MEMBER LOGIN" OnClick="Button4_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button5" runat="server" Text="MEMBER REGISTER" OnClick="Button5_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="MEMBER PAGE" />
           
        </p>
        <h3>
            &nbsp;STAFF</h3>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="STAFF LOGIN" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="STAFF PAGE" OnClick="Button3_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="SIGN OUT" />
        </p>
            <p>
                &nbsp;</p>
        </center>
        <div>
            <br/>
<h2 ALIGN="CENTER"> Testing Instructions and Components Implemented </h2> 
<TABLE BORDER="5" WIDTH="80%"   CELLPADDING="4" CELLSPACING="3" ALIGN="Center">
   <TR>
      <TH COLSPAN="2" ALIGN="Left">
         <BR>Test Assignment 5 components at: <a href="http://webstrar11.fulton.asu.edu/page9/Default.aspx"> http://webstrar11.fulton.asu.edu/page9/Default.aspx </a>
      </TH>
   </TR>
   <TR>
      <TH COLSPAN="2" ALIGN="Left">
         <BR>This project is developed by: Sunaina B 
      </TH>
   </TR>
   <TR>
      <TH>Component Layers</TH>
      <TH>INSTRUCTIONS.</TH>
	  
   </TR>
   <TR>
      <TD>Public Page</TD>
      
	  <TD><ul>
	  <li>Click <a href="http://webstrar11.fulton.asu.edu/page9/Default.aspx"> http://webstrar11.fulton.asu.edu/page9/Default.aspx </a>.</li>
	  <li>The Web application enables the user to make the right decisions to an efficient commuting system based on weather conditions, mode of transport, news, time and distance of travel. It aslo gives additional information on the news reports and a google map view for the given location. </li>
	  </ul></TD>
	 
   </TR>
   <TR>
      <TD class="auto-style1">Member Page</TD>
      
	  <TD class="auto-style1"><ul>
	  <li>MEMBER LOGIN: Enter Credentials Username: <b>member1</b> Password: <b>member1</b>.</li>
	  <li>MEMBER REGISTER: Self Subscribe member here with Image verifier service. </li>
          <li>Reload the image to subscribe successfully.</li>
	  <li>If logged in you can access Member page to get the distance, time and map, </li>
          <li>Also can redirecte back to Public page.</li>	  
	  <li>Credentials Username: member1 Password: member1. Can also sign out in Public page.</li>
	  </ul></TD>
	 
   </TR>
   <TR>
      <TD>Staff Pages</TD>
      
	  <TD><ul>
	  <li>STAFF LOGIN: Can login as an Admin or staff. It is only to sign in redirecting to Default.aspx</li>
	  <li>Login Credentials as ADMIN Username: <b>admin</b> Password: <b>admin</b>.</li>
	  <li>Login Credentials as STAFF Username: <b>staff</b> Password: <b>staff</b>.</li>
	  <li>This navigates to a Welcome staff.... page with 2 buttons.</li>
	  <li>ADMIN button checks credentials of user role as admin and navigates to NewsFocus service accessible only to Admin</li>
	  <li>STAFF button checks credential of user role as staff and navigates to WeatherForecast service accessible to Staff</li>
	  <li>Else in both cases redirects to staffLogon page</li>
	  <li>Also, there is a button to Public Page in every page</li>
	  </ul></TD>
	 
   </TR>
   <TR>
      <TD>DLL Class Library Module</TD>
      
	  <TD><ul>
	  <li>DLL class Library Modules use DLL for Encryption, Decryption. Used EncryptDecrypt. dll class to Encrypt in Register.aspx.cs for registering members and EncryptDecrypt.dll for Decription in StaffLogon.aspx.cs and Logon.aspx.cs.</li>
	  <li>On entering credentials to register the users.xml file Password tag is encrypted.</li>
	  <li>Similarly Member Login and Staff Login uses DLL class for Decryption </li>
	  </ul></TD>
	 
   </TR>
   <TR>
      <TD>Remote Services</TD>
      
	  <TD><ul>
	  <li>Public Service Repository: <ul><li>Get Distance and Time by inputs: start and end locations.</li>
	  <li>Image Verifier Service</li></ul></li>
	  <li>Self Developed Service: Display the marker for a given location on Map.</li>
	  <li>Self Developed Service: News Focus service. </li>
      <li>Self Developed Service: Weather Forecast service. </li>	  
	  </ul></TD>
	 
   </TR>
   <TR>
      <TD>Data Management </TD>
      
	  <TD><ul>
	  <li>Member.xml : Permanent state for storing the usernames, passwords, mailId on self subscription.</li>
	  <li>Staff.xml: Permanent state for storing the user names, passwords and roles for authentication and authorization of staff </li>
	  <li>Cookie: Implemented to store user profile information. So an attempt to login will display the credentials of the person already logged in.</li>  
	  <li>Session: Session state for storing temporary states in image verification.</li>
	  <li>Session: Display map for a given location by sharing information among different sessions. The API key may expire if too many attemps are made.</li> 
	  </ul></TD>
   </TR>
   

</TABLE>

<H2 ALIGN="CENTER"> Self Developed Services</H2>
<TABLE BORDER="5" WIDTH="80%"   CELLPADDING="4" CELLSPACING="3" ALIGN="Center">
 <TR>
      <TH COLSPAN="5" ALIGN="Left">
         <BR>This page is developed at: <a href="http://webstrar11.fulton.asu.edu/index.html"> http://webstrar11.fulton.asu.edu/index.html </a>
      </TH>
   </TR>
   <TR>
      <TH COLSPAN="5" ALIGN="Left">
         <BR>This project is developed by: Sunaina B 
      </TH>
   </TR>
   <TR>
      <TH>Provider Name</TH>
      <TH>Service Input and Output.</TH>
	  <TH>Try IT</TH>
	  <TH>Service Description</TH>
	  <TH>Planned Resource need to implement Service</TH>
   </TR>
   <TR>
      <TD>Sunaina B</TD>
      <TD>(Required) Weather Service
			Input: string zipcode
			Output: Array of strings forecasting weather.
	  </TD>
	  <TD><a href="http://webstrar11.fulton.asu.edu/page5/Default.aspx/"> TryIt</a></TD>
      <TD>For given zipcode provide 5 day weather information. </TD>
	  <TD>Retrieve information using National Weather service http://graphical.weather.gov/xml/SOAP_server/ndfdXMLserver.php?wsdl to retrieve weather information based on the zip code </TD>
   </TR>
   <TR>
	  <TD>Sunaina B</</TD>
      <TD>News Focus 
            Input : Array of string topics
			Output: Array of URLs related to input topics.
	  </TD>
      <TD><a href="http://webstrar11.fulton.asu.edu/page5/Default.aspx"> TryIt</a></TD>
	  <TD>Provide news articles for the input from the user: topic, events, keywords</TD>
      <TD>Retrieve news articles information from service provided at: https://api.nytimes.com/</TD>
   </TR>
   <TR>
      <TD>Sunaina B</</TD>
      <TD>Events Ticket Details
			Input: string keyword
			Output: List of events detail.
	  </TD>
      <TD><a href="http://webstrar11.fulton.asu.edu/page3/Default.aspx"> TryIt</a></TD>
	  <TD>Get information on events through ticket details on venue, date, price in a given state in US.</TD>
      <TD>Use TicketMaster Discover API to search for events, get ticket details for events at https://app.ticketmaster.com/discovery/v2</TD>
   </TR>
   <TR>
      <TD>Sunaina B</</TD>
      <TD>Location display on Map
			Input: string address
			Output: string markup.
	  </TD>
      <TD><a href="http://webstrar11.fulton.asu.edu/page4/WebForm1.aspx"> TryIt</a></TD>
	  <TD>Service displays the marker on map for the given location. It also gives the satellite view of the location.</TD>
      <TD>Use api from Google developer at: https://developers.google.com/maps/
</TD>
   </TR>
</TABLE>
<br/> <br/>
<H2 ALIGN="CENTER"> Public Service using Google API</H2>
<TABLE BORDER="5" WIDTH="80%"   CELLPADDING="4" CELLSPACING="3" ALIGN="Center">
   <TR>
      <TH COLSPAN="6" ALIGN="Left">
         <BR>This project is developed by: Sunaina B 
      </TH>
   </TR>
   <TR>
      <TH>API Provider</TH>
      <TH>Service parameters.</TH>
	  <TH>Try It</TH>
	  <TH>Service Description</TH>
	  <TH>Instructions</TH>
	  <TH>Planned Resource need to implement Service</TH>
   </TR>
   <TR>
      <TD>Google</TD>
      <TD><p>The public service implemented here retrieves distance and duration on entering start and end locations for a given mode of transport.</p>
			Input: string startLocation, string endLocation
			Output: string distance, string time
	  </TD>
	  <TD><a href="http://webstrar11.fulton.asu.edu/page9/MemberPage/DistanceTime.aspx"> TryIt</a></TD>
      <TD>For given a given start and end location display Distance and Time to reach destination. </TD>
	  <TD>
	  <p>Naivgate using Try It link.</p>
	  <p>Click MEMBER LOGON.</p>
	  <p>Test credentials Username : member1 and Password: member1. </p>
	  </TD>
	  <TD>Google API: https://developers.google.com/maps/ </TD>
   </TR>

</table>
    </form>
</body>
</html>

// ******************************************************************************************************************
//  Simple Web Service Example
//  Copyright(C) 2018  James LoForti
//  Contact Info: jamesloforti@gmail.com
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
//									     ____.           .____             _____  _______   
//									    |    |           |    |    ____   /  |  | \   _  \  
//									    |    |   ______  |    |   /  _ \ /   |  |_/  /_\  \ 
//									/\__|    |  /_____/  |    |__(  <_> )    ^   /\  \_/   \
//									\________|           |_______ \____/\____   |  \_____  /
//									                             \/          |__|        \/ 
//
// ******************************************************************************************************************
//
using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WelcomeRESTXMLClient
{
    public partial class WelcomeRESTXML : Form
    {
        //Object to invoke the WelcomeRESTXMLSerice
        private HttpClient client = new HttpClient();

        //XML Message's namespace
        private XNamespace xmlNamespace = XNamespace.Get("http://schemas.microsoft.com/2003/10/Serialization/");

        public WelcomeRESTXML()
        {
            InitializeComponent();
        } // end constructor

        //Get user input, pass it to the web service, and process response
        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            //Send request to WelcomeRESTXMLService - NOTE: POST NUMBER IN URI MAY HAVE CHANGED!!
            string result = await client.GetStringAsync(new Uri("http://localhost:1893/WelcomeRESTXMLService.svc/welcome/"
                + NameTxtBox.Text));

            //Parse the returned XML
            XDocument xmlResponse = XDocument.Parse(result);

            //Get the <string> elements value
            MessageBox.Show(xmlResponse.Element(xmlNamespace + "string").Value, "Welcome");
        } // end method SubmitBtn_Click
    } // end class WelcomeRESTXML
} // end namespace WelcomeRESTXMLClient

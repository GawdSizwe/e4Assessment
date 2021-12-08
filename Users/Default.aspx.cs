using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Users.Model;

namespace Users
{
    public partial class _Default : Page
    {
        const string xmlFile = @"C:\Users\Sizwe.M\source\repos\Users\users.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetUsers();
        }

        [WebMethod]
        static void GetUsers(Model.Users user)
        {
            var xdoc = XDocument.Load(xmlFile);
            var users = xdoc.Root.Descendants("USER"); 
        }
        static void AddUser(Model.Users user)
        {
            //var user = new Model.Users(1, "Sizwe", "Mazibuko", "0745135075");
            var xdoc = XDocument.Load(xmlFile);
            var xelement = new XElement("USER", new XAttribute("id", user.ID), new XElement("NAME", user.Names), new XElement("SURNAME", user.Surname), new XElement("CELLNO", user.CellNo));
            xdoc.Root.Add(xelement);

            xdoc.Save(xmlFile);
        }

        static void DeleteUser (Model.Users user)
        {
            var xdoc = XDocument.Load(xmlFile);
            var tgt = xdoc.Root.Descendants("USER").FirstOrDefault(x => x.Attribute("id").Value == user.ID.ToString());
            tgt.Remove();

            xdoc.Save(xmlFile);
        }

        static void UpdateUser(Model.Users user)
        {
            var xdoc = XDocument.Load(xmlFile);
            var tgtUser = xdoc.Root.Descendants("USER").FirstOrDefault(x => x.Attribute("id").Value == user.ID.ToString());
            tgtUser.Element("NAME").Value = user.Names;
            tgtUser.Element("SURNAME").Value = user.Surname;
            tgtUser.Element("CELLNO").Value = user.CellNo;

            xdoc.Save(xmlFile);

        }
    }
}
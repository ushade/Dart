using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF
{
    class EmailVerify
    {
        //public void readOutlookTest()
        //{
        //    Microsoft.Office.Interop.Outlook.Application app = null;
        //    Microsoft.Office.Interop.Outlook._NameSpace ns = null;
        //    Microsoft.Office.Interop.Outlook.MailItem item = null;
        //    Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
        //    Microsoft.Office.Interop.Outlook.MAPIFolder subFolder = null;
        //    Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
        //    app = application;
        //    ns = application.Session;

        //    try
        //    {
        //        ns.Logon(null, null, false, false);
        //        inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
        //        subFolder = inboxFolder.Folders["folder name that you want to look in"];
        //        Console.WriteLine("Folder Name: {0}, EntryId: {1}", subFolder.Name, subFolder.EntryID);
        //        Console.WriteLine("Num Items: {0}", subFolder.Items.Count.ToString());
        //        for (int i = 1; i <= subFolder.Items.Count; i++)
        //        {
        //            if (subFolder.Items[i] is ReportItem)
        //            {
        //                try
        //                {
        //                    Console.WriteLine("Item: {0} is a Report Item.  I don't know how to deal with this yet.", i.ToString());
        //                }
        //                catch
        //                {
        //                    Console.WriteLine("problems");
        //                }
        //            }
        //            else if (subFolder.Items[i] is MailItem)
        //            {
        //                item = (MailItem)subFolder.Items[i];
        //                item = subFolder.Items[i];
        //                Console.WriteLine("Item: {0}", i.ToString());
        //                Assert.IsTrue(item.SenderName == "display name of sender");
        //                Assert.IsTrue(item.Subject.Contains("test"));
        //                Assert.IsTrue(item.Body.Contains("text you need to look for"));
        //            }
        //            else
        //            {
        //                Console.WriteLine("item " + i + " is not a mail or report item.  have no use for it");
        //            }
        //        }
        //    }
        //    catch (System.Runtime.InteropServices.COMException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        ns = null;
        //        app = null;
        //        inboxFolder = null;
        //   }
       // }
    }
}

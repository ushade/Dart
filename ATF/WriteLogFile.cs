using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;

namespace ATF
{
    class WriteLogFile
    {
            public static bool WriteLog(string strFileName, string strMessage)
            {
                try
                {
                   var LogFilePath = Directory.GetParent(TestContext.CurrentContext.TestDirectory).Parent.FullName + "\\Log\\";
                    FileStream objFilestream = new FileStream(string.Format("{0}\\{1}",LogFilePath , strFileName), FileMode.Append, FileAccess.Write);
                    StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                    objStreamWriter.WriteLine(strMessage);
                    objStreamWriter.Close();
                    objFilestream.Close();
                    return true;
                }
                catch (Exception ex)
                {
                     string s = ex.GetBaseException().Message;
                     return false;
                }
            }
     }
}  
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Reports
{
    //Test Raporlama (ExtentRapor)
    public class ExtentReporting
    {
        //Raporlama Araçları
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            //Rapor Yolu
            var path=Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"..\..\..\..\results\";

            //Rapor oluşmadıysa rapor oluştur
            if (extentReports == null)
            {
                Directory.CreateDirectory(path);
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);
                extentReports.AttachReporter(htmlReporter);
            }
            return extentReports;
        }
        //Test oluşturma
        public static void CreateTest(string testName)
        {
            extentTest=StartReporting().CreateTest(testName);
        }

        //Rapor sonlandırma
        public static void EndReporting()
        {
            StartReporting().Flush();
        }
        //Test aşmasında bilgi alma
        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }
        //Test geçtiyse
        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }
        //Test geçmezse
        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }
        //Test sonunda ekran görüntüsü alma
        public static void LogScreenShot(string info,string image)
        {
            extentTest.Info(info,MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}

using HtmlAgilityPack;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AAA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ParseCnBlogs();



        }

        private static int i = 0;
        public static void ParseCnBlogs(string url="")
        {
            i++;
            Console.WriteLine(i);
            if (string.IsNullOrEmpty(url))
            {
                url = "https://www.bxwxorg.com/read/13606/1589657.html";
            }
            HtmlWeb web = new HtmlWeb();
            //1.支持从web或本地path加载html
            var htmlDoc = web.Load(url);
            //内容是
            //htmlDoc.DocumentNode.SelectNodes("//div[@id='content']")[0].InnerText
            //章节
            //
            //htmlDoc.DocumentNode.SelectNodes("//a[@id='pager_next']")[0].Attributes["href"].Value

            string fileName = "test.txt";

            StreamWriter sw = File.AppendText(fileName);
            var title = htmlDoc.DocumentNode.SelectNodes("//div[@class='bookname']/h1")[0].InnerText;
            title = title.Replace("节", "章 ");
            sw.WriteLine();//自动换行
            sw.WriteLine(title);//自动换行
            var cc = htmlDoc.DocumentNode.SelectNodes("//div[@id='content']")[0].InnerText;
            string reg = @"[<].*?[>]";
            cc = Regex.Replace(cc, reg, "");
            cc=cc.Replace("喜欢重生之民国元帅请大家收藏：(www.bxwxorg.com)重生之民国元帅笔下文学更新速度最快。", "");
            sw.WriteLine(cc);//自动换行
            sw.Close();
            if (i < 600)
            {
                ParseCnBlogs("https://www.bxwxorg.com" + htmlDoc.DocumentNode.SelectNodes("//a[@id='pager_next']")[0].Attributes["href"].Value);
            }

        }



    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Smarty
{
    public class TextPrintContentLine
    {
        public int LineType { get; set; }
        public object Content { get; set; }

        public int FontSize { get; set; }

        public bool Center { get; set; }
    }
    public class TextPrintContentBuffer
    {
        private List<string> lineKeys = new List<string>();//保存行的主键
        private Dictionary<string, TextPrintContentLine> lines = new Dictionary<string, TextPrintContentLine>();
        public void AppendText(string text)
        {
            string key = Guid.NewGuid().ToString();
            lineKeys.Add(key);
            lines.Add(key, new TextPrintContentLine { LineType = 0, Content = text });
        }

        public void AppendText(string text, int fontsize)
        {
            string key = Guid.NewGuid().ToString();
            lineKeys.Add(key);
            lines.Add(key, new TextPrintContentLine { LineType = 0, Content = text, FontSize = fontsize });
        }

        public void AppendText(string text, int fontsize, bool center)
        {
            string key = Guid.NewGuid().ToString();
            lineKeys.Add(key);
            lines.Add(key, new TextPrintContentLine { LineType = 0, Content = text, FontSize = fontsize, Center = center });
        }

        public void AppendImage(Image iamge)
        {
            string key = Guid.NewGuid().ToString();
            lineKeys.Add(key);
            lines.Add(key, new TextPrintContentLine { LineType = 1, Content = iamge });
        }

        public List<string> Keys { get { return lineKeys; } }

        public Dictionary<string, TextPrintContentLine> Values { get { return lines; } }

        public string DocTitle { get; set; }
    }

    public class PrintFixedImage
    {
        public string DocTitle { get; set; }
        public Image Content { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Page { get; set; }

        public bool PrintOffset { get; set; }
    }

    public class TextDocPrintHelper
    {
        public TextDocPrintHelper()
        {
            lineWordCount = 44; //设置每行打印字数
            lineHeight = 14;//行高1/100 英寸
            fontSize = 9;//9号字体
            printPage = 0;
        }

        private PrintFixedImage fixedImage;
        private TextPrintContentBuffer mutiContent;
        private List<string> textLines;
        private StringBuilder content;
        private int lineHeight;              //打印行高
        private int fontSize;
        private int pagerHeight = 0;
        private int pagerWidth = 0;
        /// <summary>
        /// 汉字字数
        /// </summary>
        private int lineWordCount;
        private bool preview = false;

        public void Print(PrintFixedImage image, double width, double height, bool preview = false)
        {
            if (image == null) return;

            this.fixedImage = image;
            this.preview = preview;
            this.pagerWidth = getYc(width);//换算成英寸/像素
            this.pagerHeight = getYc(height);

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = image.DocTitle;
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pd.PrintPage += new PrintPageEventHandler(PrintFixedContent);
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", this.pagerWidth, this.pagerHeight);
            pd.DefaultPageSettings.PaperSize = pageSize;
            if (preview)
            {
                ppd.Document = pd;
                ppd.ShowDialog();
            }
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }

        public void Print(StringBuilder content, double width, bool preview = false)
        {
            if (content == null) return;

            this.content = content;
            this.preview = preview;
            this.pagerHeight = this.content.Length / 30 * 22 + 10;
            this.pagerWidth = getYc(width);//换算成英寸/像素
            textLines = content.ToString().TrySplitStrOfLine(lineWordCount);

            if (textLines == null && textLines.Count == 0) return;

            this.pagerHeight = (textLines.Count * lineHeight);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = textLines[0];//使用第一个作为标题
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            pd.PrintPage += new PrintPageEventHandler(PrintContent);
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", this.pagerWidth, this.pagerHeight);
            pd.DefaultPageSettings.PaperSize = pageSize;
            if (preview)
            {
                ppd.Document = pd;
                ppd.ShowDialog();
            }
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }

        public void Print(TextPrintContentBuffer content, double width, bool preview = false)
        {
            if (content == null) return;

            this.mutiContent = content;
            this.preview = preview;
            this.pagerHeight = 200;
            this.pagerWidth = getYc(width);//换算成英寸/像素

            this.pagerHeight = GetPaperHieght(lineHeight);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = content.DocTitle;
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            pd.PrintPage += new PrintPageEventHandler(PrintMutiContent);
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", this.pagerWidth, this.pagerHeight);
            pd.DefaultPageSettings.PaperSize = pageSize;

            if (preview)
            {
                ppd.Document = pd;
                ppd.ShowDialog();
            }
            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败." + ex.Message);
            }
        }

        private void PrintFixedContent(object sender, PrintPageEventArgs e)
        {
            printPage += 1;
            e.Graphics.DrawImage(fixedImage.Content, fixedImage.X, fixedImage.Y);
            if (fixedImage.PrintOffset)
            {
                e.Graphics.DrawString("偏移量 X:" + fixedImage.X, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Red, 10, this.pagerHeight - 50);
                e.Graphics.DrawString("偏移量 Y:" + fixedImage.Y, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Red, 100, this.pagerHeight - 50);

                e.Graphics.DrawString("宽 W:" + pagerWidth, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Red, 10, this.pagerHeight - 25);
                e.Graphics.DrawString("高 H:" + pagerHeight, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Red, 100, this.pagerHeight - 25);
            }
            if (fixedImage.Page > printPage) { fixedImage.Y = pagerHeight / 2; e.HasMorePages = true; }
        }

        private int printPage = 0;
        private void PrintContent(object sender, PrintPageEventArgs e)
        {
            var mark = 0;
            foreach (var item in textLines)
            {
                e.Graphics.DrawString(item, new Font(new FontFamily("宋体"), fontSize), System.Drawing.Brushes.Black, 10, mark * lineHeight + 5);
                mark++;
            }
        }

        private void PrintMutiContent(object sender, PrintPageEventArgs e)
        {
            float top = 10;
            foreach (var key in mutiContent.Keys)
            {
                TextPrintContentLine item = mutiContent.Values[key];
                if (item.LineType == 1)
                {
                    Image image = item.Content as Image;
                    if (image != null)
                    {
                        string str = "使用手机扫一扫";
                        Font f = new Font("宋体", 9);
                        SizeF size = e.Graphics.MeasureString(str, f);
                        e.Graphics.DrawString(str, f, new SolidBrush(Color.Black), (pagerWidth - image.Width) / 2 - 30, top, new StringFormat(StringFormatFlags.DirectionVertical));
                        e.Graphics.DrawImage(image, (pagerWidth - image.Width) / 2 - 1, top);
                        top += image.Height + 10;
                    }
                }
                else
                {
                    int fontsize = item.FontSize == 0 ? fontSize : item.FontSize;
                    int wordCount = (int)((this.pagerWidth - 20) / (0.35 * fontsize / 25.4 * 96)) * 2 - 4;
                    float h = 0.35f * fontsize / 25.4f * 96 + 5;

                    textLines = item.Content.ToString().TrySplitStrOfLine(wordCount);
                    foreach (var text in textLines)
                    {
                        string line = text;
                        if (item.Center) line = line.PadSpaceOfMiddle(wordCount);
                        e.Graphics.DrawString(line, new Font(new FontFamily("宋体"), fontsize), System.Drawing.Brushes.Black, 10, top);

                        top += h + 5;
                    }
                }
            }
        }

        private int getYc(double mm)
        {
            return (int)(mm / 25.4 * 96);
        }

        private int GetPaperHieght(int lineHeight)
        {
            int height = 0;
            if (this.mutiContent == null) return 0;

            int count = 0;

            int imageHeight = 0;

            foreach (var item in mutiContent.Values.Values)
            {

                if (item.LineType == 1)
                {
                    Image image = item.Content as Image;
                    if (image != null) imageHeight += image.Height + 10;

                    height += image.Height + 10;
                }
                else
                {
                    int fontSize = (int)(0.35 * item.FontSize / 25.4 * 96);
                    fontSize = fontSize == 0 ? lineHeight : fontSize;
                    int wordCount = (int)(this.pagerWidth / (0.35 * fontSize / 25.4 * 96)) * 2 - 4;

                    int tempCount = item.Content.ToString().TrySplitStrOfLine(wordCount).Count;
                    count += tempCount;
                    height += (fontSize + 5) * tempCount;
                }
            }

            return height + 10;//(lineHeight + 5) * count + imageHeight + 10;
        }
    }
}

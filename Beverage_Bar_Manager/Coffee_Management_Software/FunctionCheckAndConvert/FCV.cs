using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Management_Software.FunctionCheckAndConvert
{
    class FCV
    {
        public bool CheckStringIsNumber(string str)
        {
            bool isNumeric = !string.IsNullOrEmpty(str) && str.All(Char.IsDigit);
            return isNumeric;
        }
        public string FormatNumber<T>(T number, int maxDecimals = 4)
        {
            return Regex.Replace(String.Format("{0:n" + maxDecimals + "}", number),
                                 @"[" + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "]?0+$", "");
        }

        public void ChangeTextButton(Button button,Button button1, bool flag)
        {
            button.Text = flag ? "Thêm mới" : "Chỉnh sửa";
            button.Image = flag ? Coffee_Management_Software.Properties.Resources.round_add_button__1_ :  
                Coffee_Management_Software.Properties.Resources.update__1_;
            button1.Enabled = !flag;  
        }

        public string LoadImageToPic(PictureBox picture)
        {
            string path = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.InitialDirectory = "E:/PRN211/PRN211_GroupProject_Group1/Coffee_Management_Software/Image";
            oFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            oFile.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                path = oFile.FileName;
                Image img = Image.FromFile(path);
                picture.Image = img;
            }
            return path;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfControlLibrary2.Elements;

namespace UP._02_ver._2.Classes
{
    public class ValidationsField
    {
        public bool ValidationsOnlyNumber(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            else
            {
                if (Regex.IsMatch(text.Trim(), @"^[0-9]+$")) return true;
                else MessageBox.Show("В строке присудствуют лишние символы");
            }
            return false;
        }
        public bool ValidationsOnlyText(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            else
            {
                if (Regex.IsMatch(text.Trim(), @"^[A-Za-zА-Яа-я]+$")) return true;
                else MessageBox.Show("В строке присудствуют лишние символы");
            }
            return false;
        }
        public bool ValidationsShortName(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            else
            {
                if (Regex.IsMatch(text.Trim(), @"^[A-Za-zА-Яа-я0-9]+$")) return true;
                else MessageBox.Show("В строке присудствуют лишние символы");
            }
            return false;
        }
        public bool ValidationsVersion(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            else
            {
                if (Regex.IsMatch(text.Trim(), @"^[A-Za-z0-9.-]+$")) return true;
                else MessageBox.Show("В строке присудствуют лишние символы");
            }
            return false;
        }
    }
}

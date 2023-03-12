using System;
using System.Text.RegularExpressions;

namespace UserRegistration
{
    public class PasswordStrengthCheker
    {
        // ���������� �������� ������������ ��������� ������ ������������.
        public static int GetPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return 0;
            }
            int result = 0;
            // +1 ���� �� �����.
            if (Math.Max(password.Length, 7) > 7)
            {
                result++;
            }
            //+1 ���� �� ������� ������� � ������ ��������
            if (Regex.Match(password, "[a-z]").Success)
            {
                result++;
            }
            //+1 ���� �� ������� ������� � ������� ��������
            if (Regex.Match(password, "[A-Z]").Success)
            {
                result++;
            }
            // +1 ���� �� ������� �����.
            if (Regex.Match(password, "[0-9]").Success)
            {
                result++;
            }
            // +1 ���� �� ������� ������������ �������.
            if (Regex.Match(password,
            "[\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\{\\}\\[\\]\\:\\'\\;\\\"\\/\\?\\.\\>\\,\\<\\~\\`\\-\\\\_\\=\\+\\|]").Success)
            {
                result++;
            }
            return result;
        }
    }
}

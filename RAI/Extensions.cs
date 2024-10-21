using Telerik.Windows.Controls.GridView;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System;

namespace RAI
{
    public static class Extensions
    {
        public static string GetMimeType(this ImageFormat imageFormat)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            return (codecs.First(codec => codec.FormatID == imageFormat.Guid).MimeType).Replace("image/", "");
        }

        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }

        public static int GetTimeStamp(this DateTime date)
        {
            var value = date.ToString("yyyy-MM-ddTHH:mm:sszzz");
            DateTime Start = DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);

            return (int)Start.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }

        public static string FormatarCnpjCpf(this string cnpjCpf)
        {
            if (cnpjCpf != null) cnpjCpf = cnpjCpf.Replace(" ", "").Replace(".", "").Replace("/", "").Replace("-", "");

            try
            {
                if (cnpjCpf?.Length == 11)
                    return Convert.ToUInt64(cnpjCpf).ToString(@"000\.000\.000\-00");

                if (cnpjCpf?.Length == 14)
                    return Convert.ToUInt64(cnpjCpf).ToString(@"00\.000\.000/0000\-00");
            }
            catch (Exception)
            {
            }

            return cnpjCpf;
        }
        public static string RemoverFormatacaoCnpjCpf(this string cnpjCpf)
        {
            return cnpjCpf.Trim().Replace(".", "").Replace("-", "");
        }

        public static string FormatarCelularTelefone(this string celularTelefone)
        {
            if (celularTelefone != null) celularTelefone = celularTelefone.Replace(" ", "");

            if (celularTelefone?.Length == 10)
                return Convert.ToUInt64(celularTelefone).ToString(@"(00) 0000-0000");

            if (celularTelefone?.Length == 11)
                return Convert.ToUInt64(celularTelefone).ToString(@"(00) 00000-0000");

            return celularTelefone;
        }

        public static void SelectGridCell(this RadGridView grid, int column)
        {
            GridViewRow row1 = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as GridViewRow;
            //var cell = (GridViewCell)row1.Cells[column];
            //var cont = (Telerik.Windows.Controls.GridView.LookupElement)cell.Content;
            //cont.ComboBox.IsDropDownOpen = true;
            ((GridViewCell)row1.Cells[column]).BeginEdit();
        }

        public static string Left(this string text, int length)
        {
            if (text.Length > length) return text.Substring(0, length);
            return text;
        }

        public static string Right(this string text, int length)
        {
            if (text.Length > length) return text.Substring(text.Length - length, length);
            return text;
        }

        public static bool IsValidCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsValidCpfCnpj(this string cpf_cnpj)
        {
            if (cpf_cnpj.Length == 11 || cpf_cnpj.Length == 14)
                return (IsValidCpf(cpf_cnpj) || IsValidCnpj(cpf_cnpj));
            else
                return false;
        }

        public static bool IsValidCnpj(this string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumeric(this string text) => double.TryParse(text, out _);

        public static bool IsTimeSpan(this string text) => TimeSpan.TryParse(text, out _);

        public static string GetValueOrNull(this string value)
        {
            if (value.Trim() == "") return null;
            return value.Trim();
        }

        public static string ToZero(this string value)
        {
            if (value.Trim() == "") return "0";
            return value.Trim();
        }

        public static decimal? ToDecimal(this string value, int decimalPlaces = 2)
        {
            if (value.Trim() == "" || value == "0") return null;

            if (!value.IsNumeric()) return null;

            return Math.Round(Convert.ToDecimal(value), decimalPlaces);
        }

        public static int? ToIntOrNull(this string value)
        {
            if (value.Trim() == "" || value == "0") return null;

            decimal number;

            if (decimal.TryParse(value, out number))
                return (int)Math.Floor(number);

            return null;
        }

        public static int ToInt(this string value)
        {
            if (value == null || value.Trim() == "") return 0;

            int newInt;
            if (int.TryParse(value, out newInt))
                return newInt;

            return 0;
        }

        public static int ToInt(this object value)
        {
            if (value == null) return 0;
            return Convert.ToInt32(value);
        }

        public static int? GetValueOrNull(this object value)
        {
            if (value != null)
                return Convert.ToInt32(value);

            return null;
        }

        public static DateTime? GetValueOrNull(this DateTime value, bool condition = true)
        {
            if (condition && DateTime.MinValue != value)
                return value;
            else
                return null;
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public static string ToTotalHoursMinutes(this TimeSpan time)
        {
            return $"{((int)time.TotalHours).ToString("00")}:{time:mm}";
        }

        public static List<List<T>> Partition<T>(this List<T> values, int chunkSize)
        {
            return values.Select((x, i) => new { Index = i, Value = x })
                         .GroupBy(x => x.Index / chunkSize)
                         .Select(x => x.Select(v => v.Value).ToList())
                         .ToList();
        }

        public static string RemoveAccents(this string text)
        {
            var sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }
    }
}
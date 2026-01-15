using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Utilities
{
    public class Functions
    {
        #region Convert Image

        #region resizeImage

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="PathToSave"> Path to which the image would be saved. </param> 
        /// <param name="Quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
        public static void resizeImage(string PathToSave, Image Img, int Quality)
        {
            if (Quality < 0 || Quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Png);
            //ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            Img.Save(PathToSave, jpegCodec, encoderParams);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        //private static ImageCodecInfo GetEncoderInfo(string mimeType)
        //{
        //    // Get image codecs for all image formats 
        //    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        //    // Find the correct image codec 
        //    for (int i = 0; i < codecs.Length; i++)
        //        if (codecs[i].MimeType == mimeType)
        //            return codecs[i];

        //    return null;
        //}

        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        #endregion

        public static Byte[] ImageToByteArray(Image ImageIn, int Quality)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                if (ImageIn != null)
                {
                    if (Quality < 0 || Quality > 100)
                        MessageBox("W", Utilities.Parameters.Notification, "Quality must be between 0 and 100.", 5000);

                    // Encoder parameter for image quality 
                    EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
                    // JPEG image codec 
                    ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Png);
                    //ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = qualityParam;
                    ImageIn.Save(ms, jpegCodec, encoderParams);

                    Byte[] image = new Byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(image, 0, Convert.ToInt32(ms.Length));
                    return image;
                }
                else
                {
                    return new Byte[ms.Length];
                }
            }
            catch (Exception)
            {
                return new Byte[ms.Length];
            }
        }

        public static byte[] ImageToByteArray(Image ImageIn)
        {
            //ImageConverter _imageConverter = new ImageConverter();
            //byte[] xByte = (byte[])_imageConverter.ConvertTo(ImageIn, typeof(byte[]));
            //return xByte;

            using (var stream = new MemoryStream())
            {
                ImageIn.Save(stream, ImageIn.RawFormat);
                //if (ImageFormat.Bmp.Equals(ImageIn.RawFormat))
                //    ImageIn.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                //else if (ImageFormat.Jpeg.Equals(ImageIn.RawFormat))
                //    ImageIn.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //else if (ImageFormat.Png.Equals(ImageIn.RawFormat))
                //    ImageIn.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //else
                //    ImageIn.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
        }

        public static Image ByteArrayToImage(Byte[] ByteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(ByteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region txt file

        /// <summary>
        /// Lưu nội dung vào tập tin txt
        /// </summary>
        /// <param name="FilePath">Đường dẫn tập tin</param>
        /// <param name="Content">Nội dung cần lưu</param>
        public static void WriteLog(string FilePath, string Content)
        {
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            string dateLog = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            FileInfo fInfo = new FileInfo(FilePath + "\\" + fileName);
            StreamWriter text = fInfo.AppendText();
            text.WriteLine("\n" + dateLog + "\n" + Content);
            text.Close();
        }

        #endregion

        #region Message box

        /// <summary>
        /// Hộp thoại thông báo Ok
        /// </summary>
        /// <param name="TypeMessage">N-Black; W-Blue; E-Red</param>
        /// <param name="Title">Tiêu đề thông báo</param>
        /// <param name="Content">Nội dung thông báo</param>
        public static void MessageBoxOK(string TypeMessage, string Title, string Content)
        {
            frmMessageBoxOK frmMsgOK = new frmMessageBoxOK();
            frmMsgOK.InitMessage(TypeMessage, Title, Content);
            frmMsgOK.ShowDialog();
        }

        /// <summary>
        /// Hộp thoại xác nhận Yes/No
        /// </summary>
        /// <param name="Content">Nội dung xác nhận</param>
        /// <returns></returns>
        public static DialogResult MessageBoxYesNo(string Content)
        {
            frmMessageBoxYesNo frmYesNo = new frmMessageBoxYesNo();
            frmYesNo.InitMessage(Parameters.Confirm, Content);
            DialogResult dlg = frmYesNo.ShowDialog();
            return dlg;
        }

        /// <summary>
        /// Hộp thoại thông báo Ok theo thời gian
        /// </summary>
        /// <param name="TypeMessage">N-Black; W-Blue; E-Red</param>
        /// <param name="Title">Tiêu đề thông báo</param>
        /// <param name="Content">Nội dung thông báo</param>
        /// <param name="DisplaySecond">Thời gian hiện hộp thoại</param>
        public static void MessageBox(string TypeMessage, string Title, string Content, int DisplaySecond)
        {
            frmMessageBox frmMsg = new frmMessageBox();
            frmMsg.InitMessage(TypeMessage, Title, Content, DisplaySecond);
            frmMsg.Show();
        }

        #endregion

        #region EncryptByRC2 & DecryptByRC2

        public static string CreateHashValue(String plaintext, int n)
        {
            HashAlgorithm hash;
            byte[] buf, result;
            buf = Encoding.ASCII.GetBytes(plaintext);
            hash = HashAlgorithm.Create("SHA256");
            result = hash.ComputeHash(buf);
            return BitConverter.ToString(result).Substring(0, n);
        }

        public static string EncryptByRC2(String plaintext, String Key, String IV)
        {
            int size = plaintext.Length;

            //tạo 1 thể hiện cho RC2
            RC2CryptoServiceProvider myRC2 = new RC2CryptoServiceProvider();

            //tạo khóa cho RC2
            myRC2.Key = Encoding.ASCII.GetBytes(CreateHashValue(Key, 16));
            myRC2.IV = Encoding.ASCII.GetBytes(CreateHashValue(IV, 8));

            //tạo một bộ mã hóa
            ICryptoTransform myRC2_Ecryptor = myRC2.CreateEncryptor(myRC2.Key, myRC2.IV);

            //dữ liệu muốn mã hóa được đưa vào một vùng nhớ
            MemoryStream memEncrypt = new MemoryStream();
            //tạo 1 crypto stream
            CryptoStream EncryptCrypto = new CryptoStream(memEncrypt, myRC2_Ecryptor, CryptoStreamMode.Write);

            //đọc dữ liệu vào 1 mảng byte
            byte[] arrEncript = Encoding.ASCII.GetBytes(plaintext);

            //ghi tất cả dữ liệu mã hóa xuống crypto stream
            EncryptCrypto.Write(arrEncript, 0, arrEncript.Length);
            EncryptCrypto.FlushFinalBlock();

            //lấy dữ liệu đã mã hóa ra tử vùng nhớ byte[] = memEncrypt.ToArray()
            byte[] arrEncripted = memEncrypt.ToArray();

            String kq = plaintext.Length + " " + Convert.ToBase64String(arrEncripted, 0, arrEncripted.Length, Base64FormattingOptions.InsertLineBreaks);

            memEncrypt.Close();
            EncryptCrypto.Close();
            return kq;
        }

        public static string DecryptByRC2(String encryptedtext, String Key, String IV)
        {
            //lay kich thuoc
            int i = 0;
            while (encryptedtext[i] != ' ')
            {
                i++;
            }
            String str = encryptedtext.Substring(0, i);
            int length = Int32.Parse(str);

            //đọc dữ liệu da ma hoa vào 1 mảng byte
            byte[] arrEncripted = Convert.FromBase64String(encryptedtext.Remove(0, i + 1));

            //tạo 1 thể hiện cho RC2
            RC2CryptoServiceProvider myRC2 = new RC2CryptoServiceProvider();

            //tạo khóa cho RC2
            myRC2.Key = Encoding.ASCII.GetBytes(CreateHashValue(Key, 16));
            myRC2.IV = Encoding.ASCII.GetBytes(CreateHashValue(IV, 8));

            //tạo một bộ mã hóa
            ICryptoTransform myRC2_Decryptor = myRC2.CreateDecryptor(myRC2.Key, myRC2.IV);

            //dữ liệu muốn giải mã được đưa vào một vùng nhớ
            MemoryStream memDecrypt = new MemoryStream(arrEncripted);
            //tạo 1 crypto stream
            CryptoStream DecryptCrypto = new CryptoStream(memDecrypt, myRC2_Decryptor, CryptoStreamMode.Read);

            //lấy lại dữ liệu từ crypto stream --> byte[]
            byte[] arrDecripted = new byte[length];
            DecryptCrypto.Read(arrDecripted, 0, arrDecripted.Length);

            //String kq = Convert.ToBase64String(arrDecripted,0,arrDecripted.Length, Base64FormattingOptions.InsertLineBreaks);
            String kq = Encoding.ASCII.GetString(arrDecripted);

            //dong cac stream
            DecryptCrypto.Close();
            memDecrypt.Close();
            return kq;
        }

        #endregion

        #region Xml functions

        public static XmlAttribute CreatedAttribute(XmlDocument doc, string AttributeName, string value)
        {
            XmlAttribute attr = doc.CreateAttribute(AttributeName);
            attr.Value = value;
            return attr;
        }

        #endregion

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}

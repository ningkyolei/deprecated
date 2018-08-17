using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace 测试在Winform上生成图片验证码
{
    public class ImageValidationCodeHelper
    {
        #region Private Fields

        private const double PI2 = 6.283185307179586476925286766559;

        private readonly float _ImageHeight;
        private readonly float _ImageWidth;
        private readonly int _FontSize;

        private float _Margin
        {
            get
            {
                var aMargin = _ImageWidth / _ValidationCodeLength;
                return aMargin;
            }
        }

        private string _ValidationCode;
        private readonly ValidationCodeTypeEnums _ValidationCodeTypeEnum;
        private readonly int _ValidationCodeLength;

        #endregion

        #region Public Property

        public string ValidationCode
        {
            get { return _ValidationCode; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 默认构造函数（ImageHeight=50;ImageWidth=200;FontSize=30;ValidationCodeLength=4;CodeTypeEnums=CodeTypeEnums.Alphas）
        /// </summary>
        public ImageValidationCodeHelper()
            : this(null)
        {

        }

        public ImageValidationCodeHelper(Parameter pParameter)
        {
            if (pParameter == null)
            {
                pParameter = new Parameter();
            }

            _ImageHeight = pParameter.ImageHeight.HasValue ? pParameter.ImageHeight.Value : 50;
            _ImageWidth = pParameter.ImageWidth.HasValue ? pParameter.ImageWidth.Value : 200;
            _FontSize = pParameter.FontSize.HasValue ? pParameter.FontSize.Value : 30;
            _ValidationCodeLength = pParameter.ValidationCodeLength.HasValue ? pParameter.ValidationCodeLength.Value : 4;
            _ValidationCodeTypeEnum = pParameter.CodeTypeEnum;
        }

        #endregion

        #region Public Field
        /// <summary>
        /// 验证码类型
        /// </summary>
        public enum ValidationCodeTypeEnums
        {
            /// <summary>
            /// 数字与字母混合
            /// </summary>
            Alphas,
            /// <summary>
            /// 数字
            /// </summary>
            Numbers,
            //字母
            Characters,
            /// 数字与字母混合
            Words
        }

        #endregion

        #region Private Methods

        private string GenerateNumbers()
        {
            var aText = string.Empty;

            var aRandom = new Random();

            for (var i = 0; i < _ValidationCodeLength; i++)
            {
                var aNumberString = Convert.ToString(aRandom.Next(10000) % 10);

                aText += aNumberString;
            }

            return aText.Trim();
        }


        private string GenerateCharacters()
        {
            var aText = string.Empty;

            var aRandom = new Random();

            for (var i = 0; i < _ValidationCodeLength; i++)
            {
                var aNumberString = Convert.ToString((char)(65 + aRandom.Next(10000) % 26));

                aText += aNumberString;
            }

            return aText.Trim();
        }


        private string GenerateAlphas()
        {
            var aText = string.Empty;

            var aRandom = new Random();

            for (var i = 0; i < _ValidationCodeLength; i++)
            {
                string aNumberString;
                if (aRandom.Next(500) % 2 == 0)
                {
                    aNumberString = Convert.ToString(aRandom.Next(10000) % 10);
                }
                else
                {
                    aNumberString = Convert.ToString((char)(65 + aRandom.Next(10000) % 26));
                }

                aText += aNumberString;
            }

            return aText.Trim();
        }


        private Bitmap TwistImage(Bitmap pSrcBitmap, bool bXDir, double dMultValue, double dPhase)
        {
            var aDestBitmap = new Bitmap(pSrcBitmap.Width, pSrcBitmap.Height);

            // 将位图背景填充为白色

            var aGraphics = Graphics.FromImage(aDestBitmap);

            aGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, aDestBitmap.Width, aDestBitmap.Height);

            aGraphics.Dispose();


            var dBaseAxisLen = bXDir ? (double)aDestBitmap.Height : (double)aDestBitmap.Width;


            for (var i = 0; i < aDestBitmap.Width; i++)
            {
                for (var j = 0; j < aDestBitmap.Height; j++)
                {
                    var dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;

                    dx += dPhase;

                    var dy = Math.Sin(dx);


                    // 取得当前点的颜色

                    var nOldX = bXDir ? i + (int)(dy * dMultValue) : i;

                    var nOldY = bXDir ? j : j + (int)(dy * dMultValue);


                    var color = pSrcBitmap.GetPixel(i, j);

                    if (nOldX >= 0 && nOldX < aDestBitmap.Width
                        && nOldY >= 0 && nOldY < aDestBitmap.Height)
                    {
                        aDestBitmap.SetPixel(nOldX, nOldY, color);
                    }
                }
            }


            return aDestBitmap;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 创建验证码图片Stream
        /// </summary>
        /// <returns></returns>
        public Stream CreateImageStream()
        {
            string aValidationCode;

            switch (_ValidationCodeTypeEnum)
            {
                case ValidationCodeTypeEnums.Alphas:

                    aValidationCode = GenerateAlphas();

                    break;

                case ValidationCodeTypeEnums.Numbers:

                    aValidationCode = GenerateNumbers();

                    break;

                case ValidationCodeTypeEnums.Characters:

                    aValidationCode = GenerateCharacters();

                    break;

                default:

                    aValidationCode = GenerateAlphas();

                    break;
            }

            _ValidationCode = aValidationCode;

            MemoryStream aMemoryStream;

            if (aValidationCode == null || aValidationCode.Trim() == String.Empty)
            {
                return null;
            }

            var aBitmap = new Bitmap((int)_ImageWidth, (int)_ImageHeight);

            var aGraphics = Graphics.FromImage(aBitmap);

            try
            {
                var aRandom = new Random();

                aGraphics.Clear(Color.White);

                // 画图片的背景噪音线

                for (var i = 0; i < 18; i++)
                {
                    var x1 = aRandom.Next(aBitmap.Width);

                    var x2 = aRandom.Next(aBitmap.Width);

                    var y1 = aRandom.Next(aBitmap.Height);

                    var y2 = aRandom.Next(aBitmap.Height);

                    aGraphics.DrawLine(new Pen(Color.FromArgb(aRandom.Next()), 1), x1, y1, x2, y2);
                }

                var aFont = new Font("Times New Roman", _FontSize, FontStyle.Bold);

                var aBrush = new LinearGradientBrush(new Rectangle(0, 0, aBitmap.Width, aBitmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);

                if (_ValidationCodeTypeEnum != ValidationCodeTypeEnums.Words)
                {
                    for (var i = 0; i < aValidationCode.Length; i++)
                    {
                        aGraphics.DrawString(aValidationCode.Substring(i, 1), aFont, aBrush, 2 + i * _Margin, 1);
                    }
                }
                else
                {
                    aGraphics.DrawString(aValidationCode, aFont, aBrush, 2, 2);
                }

                // 画图片的前景噪音点

                for (var i = 0; i < 150; i++)
                {
                    var x = aRandom.Next(aBitmap.Width);

                    var y = aRandom.Next(aBitmap.Height);

                    aBitmap.SetPixel(x, y, Color.FromArgb(aRandom.Next()));
                }

                // 画图片的波形滤镜效果

                if (_ValidationCodeTypeEnum != ValidationCodeTypeEnums.Words)
                {
                    aBitmap = TwistImage(aBitmap, true, 3, 1);
                }

                // 画图片的边框线

                aGraphics.DrawRectangle(new Pen(Color.Silver), 0, 0, aBitmap.Width - 1, aBitmap.Height - 1);


                aMemoryStream = new MemoryStream();

                aBitmap.Save(aMemoryStream, ImageFormat.Gif);
            }

            finally
            {
                aGraphics.Dispose();

                aBitmap.Dispose();
            }

            return aMemoryStream;
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <returns></returns>
        public Image CreateImage()
        {
            var aStream = CreateImageStream();
            var aImage = Image.FromStream(aStream);
            return aImage;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="pText"></param>
        /// <returns></returns>
        public bool Validate(string pText)
        {
            var aText = pText.ToLower();
            var aCode = ValidationCode.ToLower();
            var aFlag = aText.Equals(aCode);
            return aFlag;
        }

        #endregion

        public class Parameter
        {
            public float? ImageHeight { get; set; }
            public float? ImageWidth { get; set; }
            public int? FontSize { get; set; }
            public int? ValidationCodeLength { get; set; }
            public ValidationCodeTypeEnums CodeTypeEnum { get; set; }
        }
    }
}
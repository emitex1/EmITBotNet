using System;
using System.Collections.Generic;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace ir.EmIT.EmITBotNet
{
    //todo حذف توابع اضافه و ادغام موارد قابل ادغام
    //todo راست به چپ و برعکس

    public class KeyboardGenerator
    {
        /*public static InlineKeyboardMarkup makeVerticalKeyboard(Dictionary<int, string> menu)
        {
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[menu.Count][];
            for (int i = 0; i < menu.Count; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton[] {
                    new InlineKeyboardCallbackButton(menu[i][1].ToString(), menu[i][0].ToString())
                };
            }
            return new InlineKeyboardMarkup(keyboard);
        }

        public static InlineKeyboardMarkup makeHorizontalKeyboard(Dictionary<int, string> menu)
        {
            InlineKeyboardCallbackButton[] keyboard = new InlineKeyboardCallbackButton[menu.Count];
            for (int i = 0; i < menu.Count; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton(menu[i][1].ToString(), menu[i][0].ToString());
            }
            return new InlineKeyboardMarkup(keyboard);
        }*/

        /// <summary>
        /// ساخت کیبورد عمودی از متن ها و داده های منو
        /// </summary>
        /// <param name="menu">منوی دوبعدی موردنظر از متن ها و داده ها</param>
        /// <returns>کیبورد براساس منو</returns>
        public static InlineKeyboardMarkup makeVerticalKeyboard(string[][] menu)
        {
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[menu.Length][];
            for (int i = 0; i < menu.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton[] {
                    new InlineKeyboardCallbackButton(menu[i][1].ToString(), menu[i][0].ToString())
                };
            }
            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد افقی از متن ها و داده های منو
        /// </summary>
        /// <param name="menu">منوی دوبعدی موردنظر از متن ها و داده ها</param>
        /// <returns>کیبورد براساس منو</returns>
        public static InlineKeyboardMarkup makeHorizontalKeyboard(string[][] menu)
        {
            InlineKeyboardCallbackButton[] keyboard = new InlineKeyboardCallbackButton[menu.Length];
            for (int i = 0; i < menu.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton(menu[menu.Length - i - 1][1].ToString(), menu[menu.Length - i - 1][0].ToString());
            }
            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد عمودی از متن های منو
        /// </summary>
        /// <param name="menu">منوی موردنظر</param>
        /// <returns>کیبورد براساس منو</returns>
        public static InlineKeyboardMarkup makeVerticalKeyboard(string[] menu)
        {
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[menu.Length][];
            for (int i = 0; i < menu.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton[] {
                    new InlineKeyboardCallbackButton(menu[i], (i+1).ToString())
                };
            }
            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد افقی از متن های منو
        /// </summary>
        /// <param name="menu">منوی موردنظر</param>
        /// <returns>کیبورد براساس منو</returns>
        public static InlineKeyboardMarkup makeHorizontalKeyboard(string[] menu)
        {
            InlineKeyboardCallbackButton[] keyboard = new InlineKeyboardCallbackButton[menu.Length];
            for (int i = 0; i < menu.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton(menu[menu.Length - i - 1], (menu.Length - i).ToString());
            }
            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد براساس ماتریس ورودی
        /// </summary>
        /// <param name="textMatrix">ماتریس دوبعدی متن دکمه ها</param>
        /// <returns>کیبورد تولید شده</returns>
        public static InlineKeyboardMarkup makeKeyboard(string[][] textMatrix)
        {
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[textMatrix.Length][];
            for (int i = 0; i < textMatrix.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton[textMatrix[i].Length];
                for (int j = 0; j < textMatrix[i].Length; j++)
                {
                    keyboard[i][j] = new InlineKeyboardCallbackButton(textMatrix[i][textMatrix[i].Length - j - 1], (i* textMatrix[i].Length + textMatrix[i].Length - j).ToString());
                }
                
            }
            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد براساس ماتریس سه بعدی شامل متن و داده دکمه ها
        /// </summary>
        /// <param name="textDataMatrix">ماتریس سه بعدی شامل متن و داده دکمه ها</param>
        /// <returns>کیبورد تولید شده</returns>
        public static InlineKeyboardMarkup makeKeyboard(string[][][] textDataMatrix)
        {
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[textDataMatrix.Length][];
            for (int i = 0; i < textDataMatrix.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton[textDataMatrix[i].Length];
                for (int j = 0; j < textDataMatrix[i].Length; j++)
                {
                    keyboard[i][j] = new InlineKeyboardCallbackButton(textDataMatrix[i][textDataMatrix[i].Length - j - 1][0], textDataMatrix[i][textDataMatrix[i].Length - j - 1][1]);
                }

            }
            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد ماتریسی براساس آرایه ورودی و تعداد ستون موردنیاز هر ردیف
        /// </summary>
        /// <param name="textArr">آرایه شامل متن دکمه ها</param>
        /// <param name="columnCount">تعداد ستون موردنیاز در هر ستون</param>
        /// <param name="hasReturnBtn">آیا دکمه بازگشت هم باشد؟</param>
        /// <param name="dataArr">آرایه شامل داده های متناظر دکمه ها</param>
        /// <returns>کیبورد تولید شده</returns>
        public static InlineKeyboardMarkup makeKeyboard(string[] textArr, int columnCount, bool hasReturnBtn, string[] dataArr = null)
        {
            int rowCount = (int)Math.Ceiling((double)textArr.Length / columnCount);
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[rowCount + (hasReturnBtn ? 1 : 0)][];
            for (int i = 0; i < rowCount; i++)
            {
                if (i == rowCount - 1 && textArr.Length % columnCount != 0)
                    keyboard[i] = new InlineKeyboardCallbackButton[textArr.Length % columnCount];
                else
                    keyboard[i] = new InlineKeyboardCallbackButton[columnCount];
            }
            for (int i = 0; i < textArr.Length; i++)
            {
                keyboard[i / columnCount][i % columnCount] = new InlineKeyboardCallbackButton(textArr[i], (dataArr == null ? (i + 1).ToString() : dataArr[i] ));
            }

            if (hasReturnBtn)
            {
                keyboard[rowCount] = new InlineKeyboardCallbackButton[1];
                keyboard[rowCount][0] = new InlineKeyboardCallbackButton("بازگشت \U000021A9", "0");
            }

            return new InlineKeyboardMarkup(keyboard);
        }

        /// <summary>
        /// ساخت کیبورد شامل ماه های شمسی
        /// </summary>
        /// <param name="defaltMonth">ماه پیش فرض</param>
        /// <returns>کیبورد ماه های شمسی</returns>
        public static InlineKeyboardMarkup makeMonthKeyboard(int defaltMonth = -1)
        {
            string[] monthArr = new string[12];
            for (int i = 0; i < 12; i++)
            {
                monthArr[i] = PersianDateTime.GetMonthName(i - 1) + (i == defaltMonth - 1 ? " \U00002705" : "");
            }
            return makeKeyboard(monthArr, 3, false);
        }

        /// <summary>
        /// ساخت کیبورد شامل سال ها
        /// </summary>
        /// <param name="defaultYear">سال پیش فرض</param>
        /// <returns>کیبورد سال ها</returns>
        public static InlineKeyboardMarkup makeYearKeyboard(int defaultYear = -1)
        {
            string[] yearTextArr = new string[10];
            string[] yearDataArr = new string[10];
            for (int i = 0; i < 10; i++)
            {
                yearTextArr[i] = (1390 + i).ToString() + (1390+i == defaultYear ? " \U00002705" : "");
                yearDataArr[i] = (1390 + i).ToString();
            }
            return makeKeyboard(yearTextArr, 5, false, yearDataArr);
        }

        /// <summary>
        /// ساخت کیبورد شامل سری اعداد
        /// </summary>
        /// <param name="fromNumber">از شماره</param>
        /// <param name="toNumber">تا شماره</param>
        /// <param name="columnCount">تعداد شماره در هر سطر</param>
        /// <param name="hasReturnBtn">داشتن دکمه بازگشت</param>
        /// <param name="defaultNumber">شماره پیش فرض</param>
        /// <returns>کیبورد ماتریسی شامل بازه اعداد</returns>
        public static InlineKeyboardMarkup makeNumberMatrixKeyboard(int fromNumber, int toNumber, int columnCount = 5, bool hasReturnBtn = false, int defaultNumber = -1)
        {
            int roundMaxNumber = toNumber;
            if ((toNumber-fromNumber) % columnCount != 0)
                roundMaxNumber += (columnCount - ((toNumber-fromNumber) % columnCount));
            string[] numberArr = new string[roundMaxNumber - fromNumber];
            string[] dataArr = new string[roundMaxNumber - fromNumber];
            for (int i = 0; i < roundMaxNumber - fromNumber; i++)
            {
                if (i < toNumber)
                {
                    numberArr[i] = ((i + fromNumber) + (i + fromNumber == defaultNumber ? " \U00002705" : "")).ToString();
                    dataArr[i] = (i + fromNumber).ToString();
                }
                else
                {
                    numberArr[i] = "-";
                    dataArr[i] = "-1";
                }
            }
            return makeKeyboard(numberArr, columnCount, hasReturnBtn, dataArr);
        }
    }
}

using System;
using System.Collections.Generic;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace ir.EmIT.EmITBotNet
{
    //todo کامنت گذاری کلاس
    //todo حذف توابع اضافه و ادغام موارد قابل ادغام
    //todo راست به چپ و برعکس

    public class KeyboardGenerator
    {
        public static InlineKeyboardMarkup makeVerticalKeyboard(Dictionary<int, string> menu)
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
        }

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

        public static InlineKeyboardMarkup makeHorizontalKeyboard(string[][] menu)
        {
            InlineKeyboardCallbackButton[] keyboard = new InlineKeyboardCallbackButton[menu.Length];
            for (int i = 0; i < menu.Length; i++)
            {
                keyboard[i] = new InlineKeyboardCallbackButton(menu[menu.Length - i - 1][1].ToString(), menu[menu.Length - i - 1][0].ToString());
            }
            return new InlineKeyboardMarkup(keyboard);
        }

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
        /// <returns>کیبورد تولید شده</returns>
        public static InlineKeyboardMarkup makeKeyboard(string[] textArr, int columnCount, bool hasReturnBtn, string[] dataArr = null)
        {
            int rowCount = (int)Math.Ceiling((double)textArr.Length / columnCount);
            InlineKeyboardCallbackButton[][] keyboard = new InlineKeyboardCallbackButton[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                if (i == rowCount - 1 && hasReturnBtn)
                    keyboard[i] = new InlineKeyboardCallbackButton[textArr.Length % columnCount];
                else
                    keyboard[i] = new InlineKeyboardCallbackButton[columnCount];
            }
            for (int i = 0; i < textArr.Length; i++)
            {
                keyboard[i / columnCount][i % columnCount] = new InlineKeyboardCallbackButton(textArr[i], (dataArr == null ? (i + 1).ToString() : dataArr[i] ));
            }

            if (hasReturnBtn)
                keyboard[rowCount-1][0] = new InlineKeyboardCallbackButton(textArr[textArr.Length - 1], "0");

            return new InlineKeyboardMarkup(keyboard);
        }

        public static InlineKeyboardMarkup makeMonthKeyboard(int defaltMonth = -1)
        {
            string[] monthArr = new string[12];
            for (int i = 0; i < 12; i++)
            {
                monthArr[i] = PersianDateTime.GetMonthName(i - 1) + (i == defaltMonth - 1 ? " \U00002705" : "");
            }
            return makeKeyboard(monthArr, 3, false);
        }

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

        public static InlineKeyboardMarkup makeNumberMatrixKeyboard(int maxNumber, int columnCount = 5, bool hasReturnBtn = false, int defaultNumber = -1)
        {
            int roundMaxNumber = maxNumber;
            if (maxNumber % columnCount != 0)
                roundMaxNumber += (columnCount - (maxNumber % columnCount));
            string[] numberArr = new string[roundMaxNumber + (hasReturnBtn ? 1 : 0)];
            string[] dataArr = new string[roundMaxNumber + (hasReturnBtn ? 1 : 0)];
            for (int i = 0; i < roundMaxNumber; i++)
            {
                if (i < maxNumber)
                {
                    numberArr[i] = ((i + 1) + (i == defaultNumber - 1 ? " \U00002705" : "")).ToString();
                    dataArr[i] = (i + 1).ToString();
                }
                else
                {
                    numberArr[i] = "-";
                    dataArr[i] = "-1";
                }
            }
            if (hasReturnBtn)
            {
                numberArr[roundMaxNumber] = "بازگشت \U000021A9";
                dataArr[roundMaxNumber] = "0";
            }
            //todo سپردن ساخت دکمه بازگشت به تابع زیر
            return makeKeyboard(numberArr, columnCount, hasReturnBtn, dataArr);
        }
    }
}

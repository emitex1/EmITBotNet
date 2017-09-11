namespace ir.EmIT.EmITBotNet.NFAUtility
{
    /// <summary>
    /// ساختار تابعی که بعد از رسیدن به یک وضعیت باید فراخوانی شود
    /// </summary>
    /// <param name="afd">شیئ شامل پارامترهای ورودی به این تابع</param>
    public delegate void AfterFunction(AfterFunctionData afd);
}

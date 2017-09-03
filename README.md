# EmITBotNet
## Developed by : EmIT (Seyed Emad Armoun) (سید عماد آرمون)
A framework for making Telegram Bots using C#
چارچوب ساخت ربات های تلگرام با زبان سی.شارپ

| Name | Version | Language | Dependency |
| :--------------: | :-----:| :-------------:| :-----:|
| EmITBotNet | 0.1 | C# | Telegram.Bot |

Modules :
* KeyboardGenerator : for making horizontal, vertical, matrix keyboards from ready data
* LogRegisterar : for saving user interactions in a DB

```c#
using ir.EmIT.EmITBotNet
///...
string[] menuData = new string[] {"Menu1" , "Menu2", "Menu3"}
KeyboardGenerator.makeKeyboard(menuData);
```

Package manager:

```powershell
Install-Package EmITBotNet
```

http://www.EmadArmoun.ir

http://www.Em-IT.ir

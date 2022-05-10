NetWealthCurrencyConvert

CurrencyConversionRateAutomaticUpdate - 
This process uses https://exchangeratesapi.io/ to gather all of the latest conversion rates for each of the currencies, over 160+.

NetWeathCurrencyAPI -
This is the API which communicates with an Azure SQL Database which has tables which store available currencies and exchange rates. These rates are not live, they are updated by the above CurrencyConversionRateAutomaticUpdate console application.

WebWealthCurrencyWeb -
A simple web design that allows users to pick from over 160 currencies to convert to. This webpage communicates with NetWealthCurrencyAPI to get a list of stored currencies which can be used to calculate a conversion.

If you wish to run this on a localDB, you can do this by running the 2 scripts in NetWeathCurrencyAPI/Scripts in number order. Once you have ran the 2 files you will need to run CurrencyConversionRateAutomaticUpdate, you will also need to update your connection string in the XSD.
You can also run the 3rd file if you do not wish to run the 50 minute console application to get some exchange rates in the table. These will however be outdated (valid on 10/05/2022 ~17:00).

Technologies used:
C# .Net6
MVC
Razor Pages ASP.NET core
SQL


With more time, i would have made a much more optimized Exchange rate importer as the current program takes around 50 minutes to complete. Instead i have attached a script that will allow you to importer exchange rates (valid on 10/05/2022 ~17:00).

I would have also completed some xUnit testing, testing partiations of code logic within my project.
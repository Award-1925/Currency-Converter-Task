NetWealthCurrencyConvert

CurrencyConversionRateAutomaticUpdate - 
This process uses https://exchangeratesapi.io/ to gather all of the latest conversion rates for each of the currencies, over 160+.

NetWeathCurrencyAPI -
This is the API which communicates with an Azure SQL Database which has tables which store available currencies and exchange rates. These rates are not live, they are updated by the above CurrencyConversionRateAutomaticUpdate console application.

WebWealthCurrencyWeb -
A simple web design that allows users to pick from over 160 currencies to convert to. This webpage communicates with NetWealthCurrencyAPI to get a list of stored currencies which can be used to calculate a conversion.

If you wish to run this on a localDB, you can do this by running the 2 scripts in NetWeathCurrencyAPI/Scripts in number order. Once you have ran the 2 files you will need to run CurrencyConversionRateAutomaticUpdate, you will also need to update your connection string in the XSD.

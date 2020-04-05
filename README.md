# Simple Stock Ticker Web API

The backend for a simple stock ticker.  Used by the frontend project available [in this Github repo](https://github.com/ducttape12/StockTickerUI).

Written by Keith Ott.  [See Keith Ott's resume here.](https://simplestockticker.keithott.com/ott-keith-resume-2020.pdf)

## Running

This project was written in .NET Core 3.1.  The easiest way to run the project is by installing [Visual Studio 2019](https://visualstudio.microsoft.com/vs/).

Tests are split into two projects.  The tests in StockTicketIntegrationTests will communcate with the financialmodelingprep.com API, whereas the tests in StockTickerUnitTests are all self-contained.

## Technologies Used

The following technology was used in building this backend:

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)
* [.NET Core 3.1](https://dotnet.microsoft.com/)
* MSTest
* [Moq](https://github.com/moq/moq4)

## API

This project gathers its information from the [Financial Modeling Prep API](https://financialmodelingprep.com/developer/docs/).

## Demo

The API is available at [https://stocktickerwebapi.azurewebsites.net](https://stocktickerwebapi.azurewebsites.net).  There are two endpoints available:

* https://stocktickerwebapi.azurewebsites.net/api/search?query={query}
  * Returns the first 30 stock ticker symbols matching {query} ordered alphabetically by symbol
* https://stocktickerwebapi.azurewebsites.net/api/profile/{ticker}
  * Returns information about the company associated with the stock {ticker} symbol

This API is used by [this UI](https://github.com/ducttape12/StockTickerUI).  Visit [https://simplestockticker.keithott.com](https://simplestockticker.keithott.com) to see a demo of this application.

## License

Copyright 2020 Keith Ott

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
# Palindrome

1. .NET Core API is running at http://localhost:10750/api, .net core framework 2.1 on visual studio 2017 version 15.7.4
API is using Entity Framework Core, Code First approach with Fluent API. DBContext is injected into controller.

2. DB is using sqlite, db file palindrome.db is at same folder with project PalindromeAPI
There is only 1 table named Tbl in database palindrome.db


3. .NET MVC core front-end web is running at http://localhost:3073/, .net core framework 2.1 on visual studio 2017 version 15.7.4
frontend is using bootstrap (navbar, layout, button, modal), JQuery and .NET core MVC template

4. How to run API and Web
- open solution PalindromeAPI.sln by VS2017, this will load 2 projects PalindromeAPI and PalindromeWeb
- right-click on PalindromeAPI project > Debug > start new instance
- right-click on PalindromeWeb > Debug > start new instance
- paste the full sentence into the textbox and press "Check" button to check the palindrome, result will show under the textbox and the palindrome will be persisted into sqlite db file
- press button "Clear Text" to clear the textbox
- press button "Open persisted palindromes" to open a bootstrap modal which list all persisted palindromes

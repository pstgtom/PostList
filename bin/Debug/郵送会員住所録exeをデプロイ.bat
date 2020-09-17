@echo off

set ans=
set /p ans="C:\Dropbox\住所録 へコピーしますか？ y/n : "

echo;

if %ans% == y (
copy 口酒井農業水利組合郵送会員住所録.exe c:\dropbox\住所録
echo "C:\Dropbox\住所録 へコピーしました。"
) else (
echo スキップします
)

echo;

set ans=
set /p ans="D:\Develope\口酒井\住所録 へコピーしますか？ y/n : "

echo;

if %ans% == y (
copy 口酒井農業水利組合郵送会員住所録.exe D:\Develope\口酒井\住所録
echo "D:\Develope\口酒井\\住所録 へコピーしました。"
) else (
echo スキップします
)

echo;

set ans=
set /p ans="D:\Croud\kuchsakai-dropbox\住所録 へコピーしますか？ y/n" : 

echo;

if %ans% == y (
copy 口酒井農業水利組合郵送会員住所録.exe D:\Croud\kuchsakai-dropbox\住所録
echo "D:\Croud\kuchsakai-dropbox\住所録 へコピーしました。"
) else (
echo スキップします
)

echo;

pause

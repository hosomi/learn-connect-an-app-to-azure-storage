# learn-connect-an-app-to-azure-storage

https://docs.microsoft.com/ja-jp/learn/modules/connect-an-app-to-azure-storage

## 環境

* Azrue Portal (Concierge Subscription)
* PowerShell
* VisualStudio 2019 

## 1. Azure にログイン

``az login`` : 

ブラウザが起動するのでフォーム認証する。  

```powershell
> az login
You have logged in. Now let us find all the subscriptions to which you have access...
The following tenants don't contain accessible subscriptions. Use 'az login --allow-no-subscriptions' to have tenant level access.
********-****-****-****-************
********-****-****-****-************
[
  {
    "cloudName": "AzureCloud",
    "homeTenantId": "********-****-****-****-************",
    "id": "********-****-****-****-************",
    "isDefault": true,
    "managedByTenants": [],
    "name": "Concierge Subscription",
    "state": "Enabled",
    "tenantId": "********-****-****-****-************",
    "user": {
      "name": "***********@*****.***",
  }
]
```

## 2. Azure に必要なリソースを作成

### 2.1 ストレージアカウントの作成

```powershell
az storage account create `
  --resource-group learn-e9ec2d4f-667f-4016-b51a-8c522fc12204 `
  --kind StorageV2 `
  --sku Standard_LRS `
  --access-tier Cool `
  --name <name>
```

* ``<name>`` : 作成するストレージアカウントの名前（英数小文字のみ使えます）。

 
### 2.2 作成したストレージアカウントの接続文字列の取得


```powershell
az storage account show-connection-string `
  --resource-group learn-e9ec2d4f-667f-4016-b51a-8c522fc12204 `
  --name <name> `
  --query connectionString
```

* ``<name>`` : 作成したストレージアカウントの名前。


## 特記事項
 

* 利用する nuget パッケージが非推奨になっていますので置き換えてください。  

:x: ``dotnet add package WindowsAzure.Storage``:  

↓    

:heavy_check_mark: ``dotnet add package Azure.Storage.Blobs``:  
（必要に応じて引数にバージョンを付与してください。）  

```powershell
dotnet add package Azure.Storage.Blobs
```

パッケージの使い方等は公式の Microsoft Docs を参照してください。  
https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-quickstart-blobs-dotnet  


* ソリューションファイルに言語（C#） のバージョンを指定について

説明では次のように TargetFramework に C# 7.1 を指定していますが、.NET Core 3.1 の場合、この作業は不要です。  
（説明のプロジェクトでは .NET Core 2.2 系の為、言語バージョンの指定が必要となっています。）  

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <LangVersion>7.1</LangVersion>
    <TargetFramework>netcoreapp2.2</TargetFramework>
  </PropertyGroup>
  ...
</Project>
```

VisualStudio 2019 で .NET Core（コンソールアプリ）を作成した場合はデフォルトで .NET Core 3.1 が選択されます。  

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>
...
```




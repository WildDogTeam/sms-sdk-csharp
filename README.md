# wilddog-sms

![](https://docs.wilddog.com/images/logo-d2df5d3b45.svg)

[Wilddog SMS](https://docs.wilddog.com/sms/index.html) SDK for .Net platform

## Getting started

### 环境依赖：
1. .net > 4.6.0
2. Newtonsoft.Json >= 10.0.3

### 安装:

`PM> Install-Package Wilddog.SMS`

OR

Visual Studio中通过nuget搜索`Wilddog.SMS`

### 初始化

```c#
using Wilddog.Sms;
using Wilddog.Sms.Http;

Client client = new Client("YOUR_APP_ID", "YOUR_SMS_KEY");
```

### 发送验证码短信

#### 使用野狗生成验证码
```c#
SubmitResponse submitRsps = client.SendCode("PHONE_NUMBER", "TEMPLATE_ID");
if (submitRsps.Success)
{
    Console.WriteLine(submitRsps.ToString());
}
else
{
    Console.WriteLine(submitRsps.WilddogError.ToString());
}
```

#### 使用自生成验证码
```c#
IList Params = new ArrayList();
Params.Add("123456");
SubmitResponse submitRsps = client.SendCode("PHONE_NUMBER", "TEMPLATE_ID", Params);
if (submitRsps.Success)
{
    Console.WriteLine(submitRsps.ToString());
}
else
{
    Console.WriteLine(submitRsps.WilddogError.ToString());
}
```

### 校验验证码

```c#
CheckCodeResponse checkCodeRsps = client.CheckCode("PHONE_NUMBER", code);
if (checkCodeRsps.Success)
{
    Console.WriteLine(checkCodeRsps.ToString());
}
else
{
    Console.WriteLine(checkCodeRsps.WilddogError.ToString());
}
```

### 发送通知短信

```c#
IList Params = new ArrayList();
Params.Add("PARAM1");
IList mobiles = new ArrayList();
mobiles.Add("PHONE_NUMBER");
SubmitResponse submitRsps = client.SendNotify(mobiles, "TEMPLATE_ID", Params);
if (submitRsps.Success)
{
    Console.WriteLine(submitRsps.ToString());
}
else
{
    Console.WriteLine(submitRsps.WilddogError.ToString());
}
```

### 查询发送状态

#### V1
```c#
StatusResponse statusRsps = client.QueryStatus(rrid);
if (statusRsps.Success)
{
    Console.WriteLine(statusRsps.ToString());
}
else
{
    Console.WriteLine(statusRsps.WilddogError.ToString());
}
```

#### V2
```c#
StatusResponse statusRsps = client.QueryStatus();
if (statusRsps.Success)
{
    Console.WriteLine(statusRsps.ToString());
}
else
{
    Console.WriteLine(statusRsps.WilddogError.ToString());
}
```

### 查询账户余额

```c#
BalanceResponse balanceResp = client.QueryBalance();
if (balanceResp.Success)
{
    Console.WriteLine(balanceResp.ToString());
}
else
{
    Console.WriteLine(balanceResp.WilddogError.ToString());
}
```
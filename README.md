# Fukicycle.Tool.HttpClientExtensions
[![Nuget](https://img.shields.io/nuget/v/Fukicycle.Tool.HttpClientExtensions.svg)](https://www.nuget.org/packages/Fukicycle.Tool.HttpClientExtensions)

[![Build and publish packages](https://github.com/fukicycle/Fukicycle.Tool.HttpClientExtensions/actions/workflows/production.yml/badge.svg)](https://github.com/fukicycle/Fukicycle.Tool.HttpClientExtensions/actions/workflows/production.yml)

This library is a helper that creates requests necessary for HTTP communication. If you are having trouble with complicated settings for HTTP communication, please try using it.

Happy coding :)

## Features
1. Provides a helper for HttpRequest.

## Installing and Getting started
### 1. install package.
`Fukicycle.Tool.HttpClientExtensions` is available for download and installation as [NuGet packages](https://www.nuget.org/packages/Fukicycle.Tool.HttpClientExtensions).
```
dotnet add package Fukicycle.Tool.HttpClientExtensions --version <version>
```

### 2. Create your app.
```cs
HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:8001/") };  // 👈 set your base address!
Item item = new Item
{
    Id = 1,
    Name = "New item",
    CreateAt = DateTime.Now
};
HttpRequestMessage httpRequestMessage = new HttpRequestMessageBuilder()                    // 👈 create request message builder!
                                            .AddHeader("some-header","header-value")       // 👈 set your header.
                                            .AddAuthorizationHeader("Bearer",token)        // 👈 set your authorization header.
                                            .AddHttpMethod(HttpMethod.Post)                // 👈 set your HttpMethod
                                            .AddEndPoint("/post/item")                     // 👈 set your end point for api or http request.
                                            .AddItemBody<Item>(item)                       // 👈 set your body.
                                            .Build();                                      // 👈 create HttpRequestMessage
HttpResponseResult responseResult = await new RequestHelper(client).SendAsync(httpRequestMessage); // 👈 Passing your http client. After that, you can send request!
// 👇 Now, we supported bellow contents.
Console.WriteLine(responseResult.JsonBody);
Console.WriteLine(responseResult.Message);
Console.WriteLine(responseResult.StatusCode);
```


if you uses DI, you can use bellow.
```cs
//Program.cs
builder.Services.AddScoped<RequestHelper>();

//Some services
public class SomeService
{
    private readonly RequestHelper _requestHelper;

    public SomeService(RequestHelper requestHelper)
    {
        _requestHelper = requestHelper;
    }

    public Task<Item> GetItemAsync()
    {
        //setup your request message...
        HttpRequestMessage httpRequestMessage = ...
        var result = await _requestHelper.SendAsync(httpRequestMessage);
        return System.Text.Json.JsonSerializer.Desirialize<Item>(result.JsonBody);
    }
}
```

## Contributing
Pull requests and stars are always welcome.
Contributions are what make the open source community such an amazing place to be learn, inspire, and create.   
Any contributions you make are greatly appreciated.

1. Fork the Project.
2. Create your Feature Branch(`git checkout -b feature/amazing_feature`).
3. Commit your Changes(`git commit -m 'Add some changes'`).
4. Push to the Branch(`git push origin feature/amazing_feature`).
5. Open a Pull Request.

## Author
- [fukicycle](https://github.com/fukicycle)

## License
MIT. Click [here](./LICENSE) for details.

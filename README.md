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
```
HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:8001/") };  // 👈 set your base address!
HttpRequestMessage httpRequestMessage = new HttpRequestMessageBuilder()                    // 👈 create request message builder!
                                            .AddHttpMethod(HttpMethod.Post)                // 👈 set your HttpMethod
                                            .AddEndPoint("/get/times")                     // 👈 set your end point for api or http request.
                                            .Build();                                      // 👈 create HttpRequestMessage
HttpResponseResult responseResult = await new RequestHelper(client).SendAsync(httpRequestMessage); // 👈 Passing your http client. After that, you can send request!
// 👇 Now, we supported bellow contents.
Console.WriteLine(responseResult.JsonBody);
Console.WriteLine(responseResult.Message);
Console.WriteLine(responseResult.StatusCode);
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

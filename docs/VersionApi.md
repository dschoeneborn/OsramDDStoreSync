# IO.Swagger.Api.VersionApi

All URIs are relative to *https://tuner4tronic.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetApiVersion**](VersionApi.md#getapiversion) | **GET** /ddstore/api/v1/version/api | Returns the API version.
[**GetDatabaseVersion**](VersionApi.md#getdatabaseversion) | **GET** /ddstore/api/v1/version/db | Returns the database version.


<a name="getapiversion"></a>
# **GetApiVersion**
> string GetApiVersion ()

Returns the API version.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetApiVersionExample
    {
        public void main()
        {
            var apiInstance = new VersionApi();

            try
            {
                // Returns the API version.
                string result = apiInstance.GetApiVersion();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionApi.GetApiVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getdatabaseversion"></a>
# **GetDatabaseVersion**
> string GetDatabaseVersion ()

Returns the database version.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDatabaseVersionExample
    {
        public void main()
        {
            var apiInstance = new VersionApi();

            try
            {
                // Returns the database version.
                string result = apiInstance.GetDatabaseVersion();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionApi.GetDatabaseVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


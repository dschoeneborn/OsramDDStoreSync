# IO.Swagger.Api.PicturesApi

All URIs are relative to *https://tuner4tronic.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetPictureByRef**](PicturesApi.md#getpicturebyref) | **GET** /ddstore/api/v1/pictures/{picref} | Returns a associated picture for a device description file.
[**GetThumb**](PicturesApi.md#getthumb) | **GET** /ddstore/api/v1/pictures/thumb/{picref} | Returns a associated thumb picture for a device description file.


<a name="getpicturebyref"></a>
# **GetPictureByRef**
> System.IO.Stream GetPictureByRef (string picref)

Returns a associated picture for a device description file.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetPictureByRefExample
    {
        public void main()
        {
            var apiInstance = new PicturesApi();
            var picref = picref_example;  // string | The picture reference from a DdInfo

            try
            {
                // Returns a associated picture for a device description file.
                System.IO.Stream result = apiInstance.GetPictureByRef(picref);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PicturesApi.GetPictureByRef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **picref** | **string**| The picture reference from a DdInfo | 

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: image/png

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getthumb"></a>
# **GetThumb**
> System.IO.Stream GetThumb (string picref)

Returns a associated thumb picture for a device description file.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetThumbExample
    {
        public void main()
        {
            var apiInstance = new PicturesApi();
            var picref = picref_example;  // string | The picture reference from a DdInfo

            try
            {
                // Returns a associated thumb picture for a device description file.
                System.IO.Stream result = apiInstance.GetThumb(picref);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PicturesApi.GetThumb: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **picref** | **string**| The picture reference from a DdInfo | 

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: image/png

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


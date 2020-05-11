# IO.Swagger.Api.DdFileApi

All URIs are relative to *https://tuner4tronic.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetDdfileByRef**](DdFileApi.md#getddfilebyref) | **GET** /ddstore/api/v1/ddfile/{xmlref} | Returns a single xml file for the given xml reference from a DdInfo.
[**GetDdfileBySearch**](DdFileApi.md#getddfilebysearch) | **GET** /ddstore/api/v1/ddfile/gtin/{gtin} | Returns a single xml file matching the given parameters.
[**GetDdfileFromModelId**](DdFileApi.md#getddfilefrommodelid) | **GET** /ddstore/api/v1/ddfile/modelid/{modelId} | Returns a single xml file matching the given modelId.
[**GetDdfileFromNaed**](DdFileApi.md#getddfilefromnaed) | **GET** /ddstore/api/v1/ddfile/naed/{naed} | Returns a single xml file matching the given naed.
[**GetFamiliyFile**](DdFileApi.md#getfamiliyfile) | **GET** /ddstore/api/v1/ddfile/family | Returns the family programming file.


<a name="getddfilebyref"></a>
# **GetDdfileByRef**
> System.IO.Stream GetDdfileByRef (string xmlref, string format = null)

Returns a single xml file for the given xml reference from a DdInfo.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDdfileByRefExample
    {
        public void main()
        {
            var apiInstance = new DdFileApi();
            var xmlref = xmlref_example;  // string | A xml file reference.
            var format = format_example;  // string | Optional paramter to select the xml format, default is \"dd\" as the existing dd file or \"fea\" for the new format. (optional)  (default to dd)

            try
            {
                // Returns a single xml file for the given xml reference from a DdInfo.
                System.IO.Stream result = apiInstance.GetDdfileByRef(xmlref, format);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdFileApi.GetDdfileByRef: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **xmlref** | **string**| A xml file reference. | 
 **format** | **string**| Optional paramter to select the xml format, default is \&quot;dd\&quot; as the existing dd file or \&quot;fea\&quot; for the new format. | [optional] [default to dd]

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getddfilebysearch"></a>
# **GetDdfileBySearch**
> System.IO.Stream GetDdfileBySearch (string gtin, string fwVersion = null, string hwVersion = null, string format = null)

Returns a single xml file matching the given parameters.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDdfileBySearchExample
    {
        public void main()
        {
            var apiInstance = new DdFileApi();
            var gtin = gtin_example;  // string | Mandatory parameter to identify the xml
            var fwVersion = fwVersion_example;  // string | Optional paramter to select a xml for the given firmware version (optional) 
            var hwVersion = hwVersion_example;  // string | Optional paramter to select a xml for the given hardware version (optional) 
            var format = format_example;  // string | Optional paramter to select the xml format, default is \"dd\" as the existing dd file or \"fea\" for the new format. (optional)  (default to dd)

            try
            {
                // Returns a single xml file matching the given parameters.
                System.IO.Stream result = apiInstance.GetDdfileBySearch(gtin, fwVersion, hwVersion, format);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdFileApi.GetDdfileBySearch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gtin** | **string**| Mandatory parameter to identify the xml | 
 **fwVersion** | **string**| Optional paramter to select a xml for the given firmware version | [optional] 
 **hwVersion** | **string**| Optional paramter to select a xml for the given hardware version | [optional] 
 **format** | **string**| Optional paramter to select the xml format, default is \&quot;dd\&quot; as the existing dd file or \&quot;fea\&quot; for the new format. | [optional] [default to dd]

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getddfilefrommodelid"></a>
# **GetDdfileFromModelId**
> System.IO.Stream GetDdfileFromModelId (string modelId, string format = null)

Returns a single xml file matching the given modelId.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDdfileFromModelIdExample
    {
        public void main()
        {
            var apiInstance = new DdFileApi();
            var modelId = modelId_example;  // string | Mandatory parameter to identify the xml
            var format = format_example;  // string | Optional paramter to select the xml format, default is \"dd\" as the existing dd file or \"fea\" for the new format. (optional)  (default to dd)

            try
            {
                // Returns a single xml file matching the given modelId.
                System.IO.Stream result = apiInstance.GetDdfileFromModelId(modelId, format);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdFileApi.GetDdfileFromModelId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelId** | **string**| Mandatory parameter to identify the xml | 
 **format** | **string**| Optional paramter to select the xml format, default is \&quot;dd\&quot; as the existing dd file or \&quot;fea\&quot; for the new format. | [optional] [default to dd]

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getddfilefromnaed"></a>
# **GetDdfileFromNaed**
> System.IO.Stream GetDdfileFromNaed (string naed, string format = null)

Returns a single xml file matching the given naed.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDdfileFromNaedExample
    {
        public void main()
        {
            var apiInstance = new DdFileApi();
            var naed = naed_example;  // string | Mandatory parameter to identify the xml
            var format = format_example;  // string | Optional paramter to select the xml format, default is \"dd\" as the existing dd file or \"fea\" for the new format. (optional)  (default to dd)

            try
            {
                // Returns a single xml file matching the given naed.
                System.IO.Stream result = apiInstance.GetDdfileFromNaed(naed, format);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdFileApi.GetDdfileFromNaed: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **naed** | **string**| Mandatory parameter to identify the xml | 
 **format** | **string**| Optional paramter to select the xml format, default is \&quot;dd\&quot; as the existing dd file or \&quot;fea\&quot; for the new format. | [optional] [default to dd]

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getfamiliyfile"></a>
# **GetFamiliyFile**
> System.IO.Stream GetFamiliyFile ()

Returns the family programming file.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetFamiliyFileExample
    {
        public void main()
        {
            var apiInstance = new DdFileApi();

            try
            {
                // Returns the family programming file.
                System.IO.Stream result = apiInstance.GetFamiliyFile();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdFileApi.GetFamiliyFile: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**System.IO.Stream**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


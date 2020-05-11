# IO.Swagger.Api.DdInfosApi

All URIs are relative to *https://tuner4tronic.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CheckIfDriverIsSupported**](DdInfosApi.md#checkifdriverissupported) | **GET** /ddstore/api/v1/ddinfos/issupported | Checks if a driver is supported from the DDStore.  One of the main parameters must be used to identify the driver, either the ddstore database id, the gtin or the model id.  In case the driver is identified by gtin, additional the firmware version can be used to select the correct driver.
[**GetDdInfo**](DdInfosApi.md#getddinfo) | **GET** /ddstore/api/v1/ddinfos | Returns a list of dd file infos.


<a name="checkifdriverissupported"></a>
# **CheckIfDriverIsSupported**
> bool? CheckIfDriverIsSupported (int? ddstoreId = null, string modelId = null, string gtin = null, string fwVersion = null, string scope = null)

Checks if a driver is supported from the DDStore.  One of the main parameters must be used to identify the driver, either the ddstore database id, the gtin or the model id.  In case the driver is identified by gtin, additional the firmware version can be used to select the correct driver.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CheckIfDriverIsSupportedExample
    {
        public void main()
        {
            var apiInstance = new DdInfosApi();
            var ddstoreId = 56;  // int? | Parameter to identify the driver (optional)  (default to 0)
            var modelId = modelId_example;  // string | Parameter to identify the driver (optional) 
            var gtin = gtin_example;  // string | Parameter to identify the driver (optional) 
            var fwVersion = fwVersion_example;  // string | Optional paramter to select the correct driver if gtin is used. (optional) 
            var scope = scope_example;  // string | Optional parameter for filtering by application scope.              Application scope filter values are: \"pc\", \"cloud\", \"field\". If not provided \"pc\" is the default value. (optional)  (default to pc)

            try
            {
                // Checks if a driver is supported from the DDStore.  One of the main parameters must be used to identify the driver, either the ddstore database id, the gtin or the model id.  In case the driver is identified by gtin, additional the firmware version can be used to select the correct driver.
                bool? result = apiInstance.CheckIfDriverIsSupported(ddstoreId, modelId, gtin, fwVersion, scope);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdInfosApi.CheckIfDriverIsSupported: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **ddstoreId** | **int?**| Parameter to identify the driver | [optional] [default to 0]
 **modelId** | **string**| Parameter to identify the driver | [optional] 
 **gtin** | **string**| Parameter to identify the driver | [optional] 
 **fwVersion** | **string**| Optional paramter to select the correct driver if gtin is used. | [optional] 
 **scope** | **string**| Optional parameter for filtering by application scope.              Application scope filter values are: \&quot;pc\&quot;, \&quot;cloud\&quot;, \&quot;field\&quot;. If not provided \&quot;pc\&quot; is the default value. | [optional] [default to pc]

### Return type

**bool?**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getddinfo"></a>
# **GetDdInfo**
> List<DdInfo> GetDdInfo (int? offset = null, int? limit = null, string search = null, string filter = null, string scope = null)

Returns a list of dd file infos.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDdInfoExample
    {
        public void main()
        {
            var apiInstance = new DdInfosApi();
            var offset = 56;  // int? | Optional parameter for pagination. Indicates the index of the first returned element. (optional)  (default to -1)
            var limit = 56;  // int? | Optional parameter for pagination. Defines how many elements are returned. (optional)  (default to 20)
            var search = search_example;  // string | Optional parameter for searching. Searches in BasicCode, Naed, ModelId and DeviceTypeName, space separated search substrings return an intersection of the individal search results (AND). (optional) 
            var filter = filter_example;  // string | Optional parameter for filtering by interface types and ECG types.               The filter string is a comma separated list of any filter value combinations.              Interface filter values are: \"dali\", \"nfc\", \"otprog\"              ECG type  filter values are: \"led\", \"hid\", \"fluo\", \"indoor\", \"outdoor\"              Example filter string: \"nfc,led\" (optional) 
            var scope = scope_example;  // string | Optional parameter for filtering by application scope.               Application scope filter values are: \"pc\", \"cloud\", \"field\". If not provided \"pc\" is the default value. (optional)  (default to pc)

            try
            {
                // Returns a list of dd file infos.
                List&lt;DdInfo&gt; result = apiInstance.GetDdInfo(offset, limit, search, filter, scope);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DdInfosApi.GetDdInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **offset** | **int?**| Optional parameter for pagination. Indicates the index of the first returned element. | [optional] [default to -1]
 **limit** | **int?**| Optional parameter for pagination. Defines how many elements are returned. | [optional] [default to 20]
 **search** | **string**| Optional parameter for searching. Searches in BasicCode, Naed, ModelId and DeviceTypeName, space separated search substrings return an intersection of the individal search results (AND). | [optional] 
 **filter** | **string**| Optional parameter for filtering by interface types and ECG types.               The filter string is a comma separated list of any filter value combinations.              Interface filter values are: \&quot;dali\&quot;, \&quot;nfc\&quot;, \&quot;otprog\&quot;              ECG type  filter values are: \&quot;led\&quot;, \&quot;hid\&quot;, \&quot;fluo\&quot;, \&quot;indoor\&quot;, \&quot;outdoor\&quot;              Example filter string: \&quot;nfc,led\&quot; | [optional] 
 **scope** | **string**| Optional parameter for filtering by application scope.               Application scope filter values are: \&quot;pc\&quot;, \&quot;cloud\&quot;, \&quot;field\&quot;. If not provided \&quot;pc\&quot; is the default value. | [optional] [default to pc]

### Return type

[**List<DdInfo>**](DdInfo.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


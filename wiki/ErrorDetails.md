# API Error Settings
The framework provides you the option to configure setting about the error handling. The list and settings are quite scarce at the moment.

## Messaging Settings
You can customise how the messages are generated and with what details using the following settings

| Parameter | Type | Default Value | Purpose
|--|--|--|--|
| IncludeExceptionDetail | bool | false | Specifies if the exception details need to be included in the error response |

## Logging Settings
Currently they are no supported. Will be availablein upcoming releases.

## Serialization Settings
You can customise how the response is being serialized

| Parameter | Type | Default Value | Purpose
|--|--|--|--|
| UseCamelCase| bool | true| Specifies if response properties should be returned in Camel case |

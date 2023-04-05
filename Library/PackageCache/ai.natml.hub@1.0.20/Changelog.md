## 1.0.20
+ Added `Tag.TryParse` method for safely parsing a predictor tag from a `string`.

## 1.0.19
+ Fixed `Dtype.FromType` returning `null` type for `bool` input.

## 1.0.18
+ Added `Tag` class to improve working with predictor tags.
+ Added `Predictor.graphs` field.
+ Added `Predictor.endpoints` field.
+ Added `Predictor.license` field.
+ Added `Predictor.media` field.
+ Added `Graph.status` field.
+ Added `Endpoint.variant` field.
+ Added `Endpoint.signature` field.
+ Added `EndpointParameter.optional` field.
+ Added `EndpointParameter.stringDefault` field.
+ Added `EndpointParameter.floatDefault` field.
+ Added `EndpointParameter.intDefault` field.
+ Added `EndpointParameter.boolDefault` field.
+ Removed `EndpointParameterValue` type.

## 1.0.17
+ Fixed `NatMLHub.CreateMediaSession` method raising exception for legacy clients.

## 1.0.16
+ Updated to NatML Graph 1.1.2.
+ Added `PredictorSession.fingerprint` field for identifying predictor graphs across sessions.
+ Added `PredictorSession.secret` field for working with encrypted graphs.
+ Added `CreateMediaSessionRequest.Input.product` field for identifying media session product.
+ Deprecated `CreateMediaSessionRequest.Input.api` input field. Use `product` field instead.

## 1.0.15
+ Added stability fixes on WebGL.

## 1.0.14
+ Fixed `NatMLHub.Bundle` incorrect results causing invalid session tokens when building from Windows Editor.
+ Fixed crash when using NatCorder or NatDevice without setting access key in Windows Editor.

## 1.0.13
+ Added `NatMLHub.CreateMediaSession` method for creating media sessions.
+ Added `NatMLHub.CreatePredictorSession` method for creating edge predictor sessions.
+ Added `NatMLHub.CreatePredictionSession` method for creating cloud prediction sessions.
+ Added `NatMLHub.Bundle` property for fetching the current application's NatML bundle identifier.
+ Added `NatMLHub.EditorBundle` proeprty for fetching the current Unity editor's NatML bundle identifier.
+ Added `GraphFormat.FormatForPlatform` method for retrieving the supported graph format for a given platform.
+ Added `Platform.ToNatML` extension method for converting a Unity `RuntimePlatform` to a NatML platform identifier.
+ Fixed rare crash on startup on Android (NatDevice#8).
+ Deprecated `NatMLHub.CreateAppToken` method. Use `NatMLHub.CreateMediaSession` method instead.
+ Deprecated `NatMLHub.CreateSession` method. Use `NatMLHub.CreatePredictorSession` method instead.
+ Deprecated `NatMLHub.FormatForPlatform` method. Use `GraphFormat.FormatForPlatform` method instead.
+ Deprecated `HubSettings.EditorBundle` property. Use `NatMLHub.EditorBundle` property instead.
+ Removed `NatMLHub.RequestPrediction` method.
+ Removed `NatMLHub.WaitForPrediction` method.
+ NatML Hub now requires iOS 14+.

## 1.0.12
+ Added default NatML icon and splash screen textures.
+ Fixed `BindingError` exception when running in WebGL.

## 1.0.11
+ Fixed `HubSettings.OnUpdateSettings` event being triggered with stale access key value.

## 1.0.10
+ Updated `HubSettings.OnUpdateSettings` event to also be invoked when the Editor opens.

## 1.0.9
+ Deprecated `Predictor.type` field as it is no longer supported by the NatML Hub API.
+ Deprecated `NatMLHub.RequestPrediction` method as it is no longer supported by the NatML Hub API.
+ Deprecated `NatMLHub.WaitForPrediction` method as it is no longer supported by the NatML Hub API.
+ Deprecated `UploadType.Feature` constant as it is no longer supported by the NatML Hub API.
+ Deprecated `DataType` class as it is no longer supported by the NatML Hub API.
+ Deprecated `Feature` class as it is no longer supported by the NatML Hub API.
+ Deprecated `Prediction` class as it is no longer supported by the NatML Hub API.
+ Deprecated `PredictorType` class as it is no longer supported by the NatML Hub API.
+ Deprecated `PredictionStatus` class as it is no longer supported by the NatML Hub API.
+ Deprecated `RequestPredictionRequest` class as it is no longer supported by the NatML Hub API.
+ Deprecated `RequestPredictionResponse` class as it is no longer supported by the NatML Hub API.
+ Removed `NatMLHub.ReportPrediction` method as it is no longer supported by the NatML Hub API.
+ Removed `NatMLHub.Subscribe` method as it is no longer supported by the NatML Hub API.
+ Removed `PredictionUpdatedRequest` class as it is no longer supported by the NatML Hub API.
+ Removed `PredictionUpdatedResponse` class as it is no longer supported by the NatML Hub API.
+ Removed `ReportPredictionRequest` class as it is no longer supported by the NatML Hub API.
+ Removed `ReportPredictionResponse` class as it is no longer supported by the NatML Hub API.

## 1.0.8
+ Added support for the WebGL platform.
+ Refactored `NatMLBundleIdentifier` attribute to `NatMLBundle`.
+ Refactored `BuildEmbedHelper.BundleIdentifierOverride` property to `BundleOverride`.

## 1.0.7
+ Fixed bug where `BuildEmbedHelper` fails to embed data on supported target.

## 1.0.6
+ Fixed serialization failures due to `HubSettings.OnUpdateSettings` being invoked on a background thread.

## 1.0.5
+ Added `BuildEmbedHelper` class to simplify embedding data and settings in builds.
+ Added `HubSettings.EditorBundle` for retrieving Editor bundle identifier when generating app tokens.
+ Updated `HubSettings.OnUpdateSettings` to not be invoked when scripts are recompiled.

## 1.0.4
+ Fixed NatML Hub library causing hard crash on Android.

## 1.0.3
+ Added `HubSettings.OnUpdateSettings` event raised when settings are updated by the user.
+ Added `NatMLHub.CurrentPlatform` property for getting the current NatML platform identifier.
+ Added `NatMLHub.ToPlatform` extension method to convert a Unity `RuntimePlatform` to a NatML platform identifier.
+ Added `NatMLHub.FormatForPlatform` method to get the default graph format for a given NatML platform.

## 1.0.2
+ Added `HubSettings.User` property for fetching NatML user info with current access key.
+ Refactored `NatMLHub.CreateApplicationToken` function to `CreateAppToken`.

## 1.0.1
+ Added `NatMLHub.CreateApplicationToken` function for creating application tokens for NatML media API's.
+ Added `NatMLBundleIdentifier` attribute for specifying runtime application bundle ID.

## 1.0.0
+ First release.
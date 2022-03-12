![Nami SDK logo](https://cdn.namiml.com/brand/sdk/Nami-SDK@0.5x.png)

# nami-xamarin

This repository is a community supported project provided by not maintained by Nami ML.

Head over to the [Issues](https://github.com/namiml/nami-xamarin/issues) list to see known open issues with the binding libraries.

Please feel free to contribute to the project by opening any new issues and creating pull requests with any proposed fixes!

Any accepted PRs will receive one 6 month period free of our Pro plan for one organization on the Nami Platform (limit one per organization).

--- 

Nami is the #1 Subscription and IAP Marketing platform.

No need to learn the complexities of the StoreKit and Play Billing frameworks.  Integrate our SDK in minutes into your Xamarin app and start selling and growing your digital revenue today with our generous Free Tier.

Create an account at https://app.namiml.com/join

---

## Project Status

✅ **iOS Sample App**

🐛 **iOS Binding** - Complete and available on NuGet but with some reported bugs

🏗 **Android Binding** - Partially implemented

🏗 **Forms Sample App** - Not integrated with iOS binding


## Repository Structure

-  `Android` - code for the Android binding library
-  `FormsSampleApp` - example app using Xamarin forms and the Android binding library
-  `NamiSDKComboBinding` - iOS binding library
-  `Samples/Xamarin-iOS-BasicSample` -  example app using the iOS binding library

## iOS

### Adding the Binding Library to your project

Check out our [Quickstart with Xamarin guide](https://docs.namiml.com/docs/xamarin-setup) to get up and running in minutes.

There are 2 options for adding the Nami ML SDK to your Xamarin project.  We recommend using NuGet, but you can also build the Binding Library directly from this repository and add it to you project.

https://www.nuget.org/packages/NamiML.SDK/


### Build from repository

In order to build the Binding Library, you first need to download the correct version of the Nami SDK framework to be included.   The frameworks for building with Xamarin are available at https://packages.namiml.com/NamiSDK/Xamarin/v.v.v/Nami.framework.zip.

Please replace `v.v.v` with the correct version of the Xamarin binding you are trying to use.  Check out our releases for the latest.

**Latest Framework: https://packages.namiml.com/NamiSDK/Xamarin/1.2.7/Nami.framework.zip

Save the zip file to the root of this repository and then unzip it.

You should now be able to build the Binding Library in Visual Studio.

## Android

For the v1.2.7 release the Android files are available here:
https://packages.namiml.com/NamiSDK/Xamarin/1.2.7/sdk-android-2.0.0.aar
https://packages.namiml.com/NamiSDK/Xamarin/1.2.7/sdk-android-2.0.0.pom

The Android files need to be added to `Android/NamiML/Jars/`.

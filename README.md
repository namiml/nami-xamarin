# nami-xamarin
Repository for Nami Xamarin binding project

## Adding the Binding Library to your project

There are 2 options for adding the Nami ML SDK to your Xamarin project.  We recommend using NuGet, but you can also build the Binding Library directly from this repository and add it to you project.

### Build from repository

In order to build the Binding Library, you first need to download the correct version of the Nami SDK framework to be included.   The frameworks for building with Xamarin are available at https://packages.namiml.com/NamiSDK/Xamarin/v.v.v/Nami.framework.zip.

Please replace `v.v.v` with the correct version of the Xamarin binding you are trying to use.  Check out our releases for the latest.

Save the zip file to the root of this repository and then unzip it.

You should now be able to build the Binding Library in Visual Studio.

# Developer Notes

notes for the interested :)

## Deploy a new Version

To deploy this application one first needs to have cloned this repository and opened the Solution in Visual Studio 2022. Afterwards one needs to have installed the required NuGet Packages.

1. right-click on the **Installer** -Project and click on _Rebuild_. 
2. right-click on the **SwissTransportGUI** -Project and Build for Production.
3. Create a new Tag on Git. --> bump the Version accordingly
4. Create a new Release on Github
5. Upload a ZIP of the Contents of _src/SwissTransportGUI/bin/Release_ to Github with the following name `SwissTransportGUI-<version>-x64-Release.zip`
6. Upload the Installer from _src/Installer/bin/Release/Installer.msi_ to Github with the following Name `WinInstaller-<version>-x64.msi`
7. Write a beautiful note for the release and publish it.
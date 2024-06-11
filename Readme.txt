1. Automating the Rahushettyacademy webpage using Selenium c# : https://rahulshettyacademy.com/loginpagePractise/

2. Three ways we can run test parallely:
        //run all data sets of Test method in parallel - [Parallelizable(ParallelScope.All)]
        //run all test method in one class parallel - [Parallelizable(ParallelScope.Children)]
        //run all test files in project parallel - [Parallelizable(ParallelScope.Self)]

3. Threadsafe: Threadlocal object is added to access multiple drivers parallely.

4. Run test through command line with filter: dotnet test .\TestProject_C#seleniumframework.csproj --filter TestCategory=Smoke

5. Change global variable like browser name and run: dotnet test .\TestProject_C#seleniumframework.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter\(name=\"browserName\",value=\"Edge\"\)

6. change browser running in command line: dotnet test .\TestProject_C#seleniumframework.csproj --filter TestCategory=Smoke --% -- TestRunParameters.Parameter\(name=\"<browsername>\", value=\"<Edge>\"\)

7. Nuget packages reuired: selenium webdriver, selenium support, selenium extras, webdriver manager, system.configuration.configuration manager, pageobject,

8. Folders: Test for test files, utilites for base class, app config file for global configuration, test data

9. Add the below lines in project file : 

	<Target Name="CopyCustomContent" AfterTargets="AfterBuild">
		<Copy SourceFiles="App.config" DestinationFiles="$(Outdir)\testhost.dll.config" />
	</Target>


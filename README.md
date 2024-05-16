# Learning Management System (LMS) Breakdown:
[Application Demo](https://youtu.be/_SGxrE34MmE)
- The LMS seeks to emulate the functionality found in popular LMS's such as [Canvas](https://www.instructure.com/canvas).
- Users can access two unique views: 
    - Student View
    - Instructor View
- Students can be created from the home screen through the `Student Management` page.

## Student Management Functionality: 
- Create a Student
- Remove a Student from a Course
- Update a Student's information
- Delete a Student

## Instructor Functionality: 
- Create a Course
- Enroll Students in a Course
    - View enrolled Students
    - Remove enrolled Students
- Add Modules to a Course
    - Add Items to the Course Modules
- Add Assignments to a Course
    - View and Grade Student submissions for an Assignment

## Student Functionality: 
- View enrolled Courses and their details
    - View Course Modules, Module Items, and Assignments
    - Submit Assignments through text input, similar to a Discussion Post

# Technologies: 
- C #
- .NET 8.0
- .NET MAUI

## How to run: 
- After cloning the repository or downloading the Zip file version: 
1. **Ensure .NET 8 SDK is Installed by running:** 
    ```
    dotnet --list-sdks
    ```
    - If it is not installed you can [download .NET8.0 from the webiste](https://dotnet.microsoft.com/download)
2. **Check for MAUI Workload**
    ```
    dotnet workload list
    ```
    - If MAUI is not installed, run the following command:
    ```
    dotnet workload install maui
    ```
3. Navigate to `../Learning-Management-System/MAUI.LearningManagement` by running:
    ```
    cd path/to/Learning-Management-System/MAUI.LearningManagement
    ```
    - NOTE: The path commands on will use '\' instead of '/' for navigation if on a Windows computer
4. Build the Project
- To target all buils: 
```
dotnet build
```
- To target individual builds run any of the following:
```
dotnet build -f net8.0-android
dotnet build -f net8.0-ios
dotnet build -f net8.0-maccatalyst
dotnet build -f net8.0-windows10.0.19041.0
```
5. Run the Application
- Specify which build you want to run
    - Will match any of the four above if you ran `dotnet build`
    - Will match the specified target if you chose just one. In this case I will choose the Windows build. 
```
dotnet run -f net8.0-windows10.0.19041.0
```

### NOTE: All of these steps can be skipped by installing Visual Studio Community, Selecting .NET 8 from the packages list, and clicking the run and debug button. 

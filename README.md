
# Point Of Sales Restaurant Management System

A point of sales Restaurant Management System in C# .Net Framework.
## Packages

Packages used in this application are 


- Guna.Charts.WinForms

- Guna.UI2


## Run Locally

Clone the project

```bash
  git clone https://github.com/Mahad-Saffi/Restaurant-Management-System-In-C-Sharp.git
```

- Go to the Project directory and run RMS.sln and add reference of DLLforRMS.

- For this purpose, right click on References in Visual Studio and Choose Add Reference..

- Then browse and add the file `DLLForRMS >> DLLForRMS >> bin >> Debug >> DLLForRMS.dll`
 
- After this if it is giving warning on packages then go to Project in upper menu bar and  select Manage NuGet Packages and configure both packages.


## Configure Database

- Open the sql `Database Schema` File and Execute it.
- Then connect it with DLLForRMS.sln Project.
- Open DLLForRMS.sln then go to `Utilities >> GetConnectString.cs` and add your connect string in connection string variable.


## Initialization

- In this project you have to make admin first time manually. To make it, Open `RMS.sln` and then Program.cs. Here add this line with your own Username, Password, Email and Phone Number before `Application.Run(new LoginForm())`.

```bash
  InitialAccount.AddAdmin(/*Username*/ "admin", /*Password*/ "admin", /*email*/ "admin@gmail.com", /*Phone Number*/ 03001234567);
```

- And now you can Login as admin with your given username and password and can add Rider, Manager, Customer Or another Admin. 
- After Initilizing your admin account, it would be a better practice to go to DLLForRMS.sln and delete InitialAccount.cs class. So, that no other than the admin could make admin account.


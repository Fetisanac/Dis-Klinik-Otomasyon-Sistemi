; Inno Setup Script for Diş Kliniği Otomasyon
; Bu script Inno Setup 6.x ile uyumludur

#define MyAppName "Diş Kliniği Otomasyon"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Diş Kliniği"
#define MyAppExeName "DisKlinikOtomasyon.exe"
#define MyAppId "{9B086E8E-81BD-4325-A915-E9C6B779CD40}"

[Setup]
; Uygulama Bilgileri
AppId={#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=
OutputDir=.\Setup
OutputBaseFilename=DisKlinikOtomasyon_Setup
SetupIconFile=.\DisKlinik.Hasta.Forms\Gemini_Generated_Image_brv29rbrv29rbrv2.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
ArchitecturesInstallIn64BitMode=x64

; Kurulum sırasında kullanıcıya gösterilecek bilgiler
InfoBeforeFile=
InfoAfterFile=

; .NET Framework 4.7.2 gereksinimi
[Languages]
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 6.1

[Files]
; Ana uygulama dosyaları (publish klasöründen)
Source: ".\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; DevExpress DLL'leri
Source: ".\publish\DevExpress.*.dll"; DestDir: "{app}"; Flags: ignoreversion
; .NET Framework DLL'leri
Source: ".\publish\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\publish\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\publish\*.config"; DestDir: "{app}"; Flags: ignoreversion
Source: ".\publish\*.xml"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
// .NET Framework 4.7.2 kontrolü
function InitializeSetup(): Boolean;
var
  Version: String;
  Release: Cardinal;
begin
  Result := True;
  
  // .NET Framework 4.7.2 Release numarası: 461808
  if RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', Release) then
  begin
    // Release >= 461808 means .NET Framework 4.7.2 or later
    if Release < 461808 then
    begin
      MsgBox('.NET Framework 4.7.2 veya üzeri bir sürüm gereklidir.' + #13#10 + 
             'Lütfen önce .NET Framework 4.7.2 veya üzerini kurun.' + #13#10 + #13#10 +
             'İndirme: https://dotnet.microsoft.com/download/dotnet-framework', 
             mbCriticalError, MB_OK);
      Result := False;
    end;
  end
  else
  begin
    // .NET Framework 4.x yüklü değil veya eski sürüm
    MsgBox('.NET Framework 4.7.2 veya üzeri bir sürüm gereklidir.' + #13#10 + 
           'Lütfen önce .NET Framework 4.7.2 veya üzerini kurun.' + #13#10 + #13#10 +
           'İndirme: https://dotnet.microsoft.com/download/dotnet-framework', 
           mbCriticalError, MB_OK);
    Result := False;
  end;
end;


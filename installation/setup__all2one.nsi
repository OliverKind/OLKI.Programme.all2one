;NSIS Installer for all2one 2.0.3.7
;Using Modern Interface, Setup-Options, etc.
;Written by Oliver Kind

;--------------------------------
;Set Compressor

  SetCompress auto
  SetCompressor LZMA

;--------------------------------
;Includeings

  !include "MUI2.nsh"  ;Modern UI
  !include "Sections.nsh"
  !include "LogicLib.nsh"
  ; include a function library that includes a file/directory size reporting command
  !include "FileFunc.nsh"   ; for ${GetSize} for EstimatedSize registry entry

;--------------------------------
;Defining

  !define AppName          'all2one'
  !define Version          '2.0.3.7'
  !define Company          'OLKI-Software'
  !define Comments         'Ein Programm um schnell Dateien von einem Verzeichniss und Unterverzeichnissen in ein Verzeichniss zu verschieben'
  !define Copyright        '2025 - Oliver Kind'
  !define FinishFile       'all2one.exe'
  !define ReadmeFile       'ReadMe.txt'
  !define EulaFile         'LGPL-License.txt'
  !define InformationFile  'Information.rtf'

;--------------------------------
;General

  ;Name and file
  Name ${AppName}
  OutFile "../../${AppName}__v${Version}__Setup.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\${Company}\${AppName}\"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "SOFTWARE\${Company}\${AppName}" "InstallDir"
  
  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

  ;Interface Settings
  !define MUI_ABORTWARNING

;--------------------------------
;Pages
  ;Install Pages
  !insertmacro MUI_PAGE_WELCOME
    !define MUI_LICENSEPAGE_RADIOBUTTONS
  !insertmacro MUI_PAGE_LICENSE .\..\bin\Release\licenses\${EulaFile}
    !define MUI_PAGE_HEADER_TEXT "Installationshinweise"
    !define MUI_PAGE_HEADER_SUBTEXT "Bitte lesen Sie die Hinweise zur Installation der Software"
  !insertmacro MUI_PAGE_LICENSE .\..\doc\${InformationFile}
  !insertmacro MUI_PAGE_DIRECTORY
    !define MUI_STARTMENUPAGE_DEFAULTFOLDER "${Company} - ${AppName}"
    Var StartMenuFolder
  !insertmacro MUI_PAGE_STARTMENU  "Application" $StartMenuFolder
  !insertmacro MUI_PAGE_INSTFILES
    !define MUI_FINISHPAGE_NOAUTOCLOSE
    !define MUI_FINISHPAGE_RUN_CHECKED
    !define MUI_FINISHPAGE_RUN $INSTDIR\${FinishFile}
    !define MUI_FINISHPAGE_SHOWREADME_NOTCHECKED
    !define MUI_FINISHPAGE_SHOWREADME $INSTDIR\${ReadmeFile}
  !insertmacro MUI_PAGE_FINISH

  ;Uninstall Pages
  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
     !define MUI_UNFINISHPAGE_NOAUTOCLOSE
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "German"
  ;LoadLanguageFile "${NSISDIR}\Contrib\Language files\German.nlf"

;--------------------------------

;Version Information
  VIProductVersion "${Version}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "ProductName" "${AppName}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "Comments" "${Comments}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "CompanyName" "${Company}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "LegalTrademarks" "${AppName} ist ein Markenzeichen von ${Company}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "LegalCopyright" "� ${Company} ${Copyright}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "FileDescription" "Setup f�r ${AppName}"
  VIAddVersionKey /LANG=${LANG_GERMAN} "FileVersion" ${Version}

;--------------------------------

;Installer Sections
SetOverwrite on
ShowInstDetails show
ShowUnInstDetails show

;~~~~~~~~~~~~~~~~~~~~~~~

;Other Installations
Section ""

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  File ".\..\bin\Release\changelog.txt"
  File ".\..\bin\Release\Interop.WIA.dll"
  File ".\..\bin\Release\Octokit.dll"
  File ".\..\bin\Release\OLKI.Toolbox.dll"
  File ".\..\bin\Release\all2one.exe"
  File ".\..\bin\Release\all2one.exe.config"
  File ".\..\bin\Release\doc\${InformationFile}"
  File ".\..\bin\Release\doc\${ReadmeFile}"
  File ".\..\bin\Release\Resources\ProgamIcons\Program_Symbol.ico"
  
  SetOutPath "$INSTDIR\Licenses"
  File ".\..\bin\Release\Licenses\CC4.0-License.txt"
  File ".\..\bin\Release\Licenses\CPOL-License.txt"
  File ".\..\bin\Release\Licenses\LGPL-License.txt"
  File ".\..\bin\Release\Licenses\MIT-License (CroweMan; 22.06.2010).txt"
  File ".\..\bin\Release\Licenses\MIT-License (octokit.net; 16.08.2017).txt"

  ;Create Desktop shortcut
  CreateShortCut "$DESKTOP\${AppName}.lnk" "$INSTDIR\all2one.exe" ""
  
  ;Create Starmenue Entry
  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
    CreateShortCut "$SMPROGRAMS\$StartMenuFolder\all2one.lnk" "$INSTDIR\all2one.exe"
    CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
    CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Readme.lnk" "$INSTDIR\${ReadmeFile}"
    CreateShortCut "$SMPROGRAMS\$StartMenuFolder\EULA.lnk" "$INSTDIR\${EulaFile}"
    CreateShortCut "$SMPROGRAMS\$StartMenuFolder\Installationshinweise.lnk" "$INSTDIR\${InformationFile}"
  !insertmacro MUI_STARTMENU_WRITE_END

  ;Store installation folder for overwriting with a newer version
  WriteRegStr HKCU "SOFTWARE\${Company}\${AppName}" "InstallDir" $INSTDIR

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  ; write uninstall strings
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "DisplayName" '${AppName}'
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "UninstallString" '$INSTDIR\Uninstall.exe'
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "DisplayIcon" '$INSTDIR\program_symbol.ico'
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "DisplayVersion" '${Version}'
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "Publisher" '${Company}'
;  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "EstimatedSize" ${AppSize}
    ; get cumulative size of all files in and under install dir
    ; report the total in KB (decimal)
    ; place the answer into $0  ($1 and $2 get other info we don't care about)
    ${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
    ; Convert the decimal KB value in $0 to DWORD
    ; put it right back into $0
    IntFmt $0 "0x%08X" $0
    ; Create/Write the reg key with the dword value
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}" "EstimatedSize" $0
SectionEnd

;--------------------------------
;Uninstaller Section
; Uninstaller
Section "Uninstall"
  ;Delte program directory
  RMDir /R "$INSTDIR"

  ;Delte company directory if empty
  RMDir "$SMPROGRAMS\${Company}"

  ;Delete directory in AppData
  ReadRegStr $R1 HKCU "SOFTWARE\${Company}\${AppName}\" "SettingDir"
  RMDir /R $R1
  RMDir "$APPDATA\${Company}\"

  ;Delete Desktop shortcut
  Delete "$DESKTOP\${AppName}.lnk"
  ;Delete Starmenue
  !insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuFolder
  RMDir /R "$SMPROGRAMS\$StartMenuFolder"

  ;Delete registry
  DeleteRegKey HKCU "SOFTWARE\${Company}\${AppName}\InstallDir"
  DeleteRegKey HKCU "SOFTWARE\${Company}\${AppName}\SettingDir"
  DeleteRegKey HKCU "SOFTWARE\${Company}\${AppName}"
  DeleteRegKey /ifempty HKCU "SOFTWARE\${Company}"
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${Company} ${AppName}"
SectionEnd
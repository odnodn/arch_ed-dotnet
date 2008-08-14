# Auto-generated by EclipseNSIS Script Wizard
# 17/09/2007 16:43:00

Name "Archetype Editor"

# Defines
!define REGKEY "SOFTWARE\$(^Name)"
!define VERSION "2.0"
!define COMPANY "Ocean Informatics Pty Ltd"
!define URL www.oceaninformatics.com

# MUI defines
!define MUI_ICON "..\ocean-transparent.ico"
!define MUI_FINISHPAGE_NOAUTOCLOSE
!define MUI_LICENSEPAGE_RADIOBUTTONS
!define MUI_STARTMENUPAGE_REGISTRY_ROOT HKLM
!define MUI_STARTMENUPAGE_NODISABLE
!define MUI_STARTMENUPAGE_REGISTRY_KEY ${REGKEY}
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME StartMenuGroup
!define MUI_STARTMENUPAGE_DEFAULTFOLDER "Ocean Informatics\Archetype Editor"
!define MUI_UNICON "..\ocean-transparent.ico"
!define MUI_WELCOMEFINISHPAGE_BITMAP "ocean.bmp"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "oceanheader.bmp"
!define MUI_UNFINISHPAGE_NOAUTOCLOSE
!define MUI_FINISHPAGE_RUN "$INSTDIR\ArchetypeEditor.exe"

# Included files
!include Sections.nsh
!include MUI.nsh

# Variables
Var StartMenuGroup

# Installer pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "Ocean Archetype Editor Licence Agreement.rtf"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_STARTMENU Application $StartMenuGroup
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

# Installer languages
!insertmacro MUI_LANGUAGE English

# Installer attributes
OutFile InstallExe\OceanArchetypeEditorInstall.exe
InstallDir "$PROGRAMFILES\Ocean Informatics\Archetype Editor"
CRCCheck on
XPStyle on
ShowInstDetails show
VIProductVersion ${VERSION}.0.0
VIAddVersionKey ProductName "Ocean Archetype Editor"
VIAddVersionKey ProductVersion "${VERSION}"
VIAddVersionKey CompanyName "${COMPANY}"
VIAddVersionKey CompanyWebsite "${URL}"
VIAddVersionKey FileVersion ""
VIAddVersionKey FileDescription ""
VIAddVersionKey LegalCopyright "Copyright � Ocean Informatics Pty Ltd 2008"
InstallDirRegKey HKLM "${REGKEY}" Path
ShowUninstDetails show

# Installer sections
Section -Main SEC0000
    SetOutPath $INSTDIR
    SetOverwrite off
    File ..\bin\ArchetypeEditor.exe.config

    SetOverwrite on 
    File ..\bin\ArchetypeEditor.exe
    File ..\bin\*.dll
    File ..\AdlParser\libOceanInformatics.AdlParser.dll
    File ..\bin\*.ico
    File ..\bin\*.xml
    File ..\bin\*.xsd
    File ..\ocean-transparent.ico
    File "..\Ocean Archetype Editor Licence Agreement.html"

    SetOutPath $INSTDIR\Help
    File ..\bin\Help\ArchetypeEditor.chm

    SetOutPath $INSTDIR\HTML
    File ..\bin\HTML\*

    SetOutPath $INSTDIR\HTML\Images
    File ..\bin\HTML\Images\*

    SetOutPath $INSTDIR\PropertyUnits
    File ..\bin\PropertyUnits\*

    SetOutPath $INSTDIR\Terminology
    File ..\bin\Terminology\*

    SetOverwrite ifnewer
    SetOutPath $INSTDIR\..\Archetypes\cluster
    File /nonfatal ..\Archetypes\cluster\*.adl
    SetOutPath $INSTDIR\..\Archetypes\composition
    File /nonfatal ..\Archetypes\composition\*.adl
    SetOutPath $INSTDIR\..\Archetypes\element
    File /nonfatal ..\Archetypes\element\*.adl
    SetOutPath $INSTDIR\..\Archetypes\entry\action
    File /nonfatal ..\Archetypes\entry\action\*.adl
    SetOutPath $INSTDIR\..\Archetypes\entry\admin_entry
    File /nonfatal ..\Archetypes\entry\admin_entry\*.adl
    SetOutPath $INSTDIR\..\Archetypes\entry\evaluation
    File /nonfatal ..\Archetypes\entry\evaluation\*.adl
    SetOutPath $INSTDIR\..\Archetypes\entry\instruction
    File /nonfatal ..\Archetypes\entry\instruction\*.adl
    SetOutPath $INSTDIR\..\Archetypes\entry\observation
    File /nonfatal ..\Archetypes\entry\observation\*.adl
    SetOutPath $INSTDIR\..\Archetypes\section
    File /nonfatal ..\Archetypes\section\*.adl
    SetOutPath $INSTDIR\..\Archetypes\structure
    File /nonfatal ..\Archetypes\structure\*.adl

    WriteRegStr HKLM "${REGKEY}\Components" Main 1
SectionEnd

Section
    DeleteRegKey HKCR ".adl"
    WriteRegStr HKCR ".adl" "" "AdlFile"

    WriteRegStr HKCR "AdlFile" "" "ADL File Type"
    WriteRegStr HKCR "AdlFile\DefaultIcon" "" "$INSTDIR\ArchetypeEditor.exe,0"
    WriteRegStr HKCR "AdlFile\shell" "" "open"
    WriteRegStr HKCR "AdlFile\shell\open\command" "" '$INSTDIR\ArchetypeEditor.exe "%1"'

    System::Call 'Shell32::SHChangeNotify(i 0x8000000, i 0, i 0, i 0)'
SectionEnd

Section -post SEC0001
    WriteRegStr HKLM "${REGKEY}" Path $INSTDIR
    SetOutPath $INSTDIR
    WriteUninstaller $INSTDIR\uninstall.exe
    !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    SetOutPath $SMPROGRAMS\$StartMenuGroup
    SetOutPath $INSTDIR
    CreateShortcut "$SMPROGRAMS\$StartMenuGroup\Uninstall $(^Name).lnk" $INSTDIR\uninstall.exe
    CreateShortcut "$SMPROGRAMS\$StartMenuGroup\Archetype Editor.lnk" $INSTDIR\ArchetypeEditor.exe
    !insertmacro MUI_STARTMENU_WRITE_END
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" DisplayName "$(^Name)"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" DisplayVersion "${VERSION}"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" Publisher "${COMPANY}"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" URLInfoAbout "${URL}"
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" DisplayIcon $INSTDIR\uninstall.exe
    WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" UninstallString $INSTDIR\uninstall.exe
    WriteRegDWORD HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" NoModify 1
    WriteRegDWORD HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)" NoRepair 1
SectionEnd

# Macro for selecting uninstaller sections
!macro SELECT_UNSECTION SECTION_NAME UNSECTION_ID
    Push $R0
    ReadRegStr $R0 HKLM "${REGKEY}\Components" "${SECTION_NAME}"
    StrCmp $R0 1 0 next${UNSECTION_ID}
    !insertmacro SelectSection "${UNSECTION_ID}"
    GoTo done${UNSECTION_ID}
next${UNSECTION_ID}:
    !insertmacro UnselectSection "${UNSECTION_ID}"
done${UNSECTION_ID}:
    Pop $R0
!macroend

# Uninstaller sections
Section /o un.Main UNSEC0000

    Delete /REBOOTOK $INSTDIR\*
    RMDir /r /REBOOTOK $INSTDIR\Help
    RMDir /r /REBOOTOK $INSTDIR\HTML
    RMDir /r /REBOOTOK $INSTDIR\PropertyUnits
    RMDir /r /REBOOTOK $INSTDIR\Terminology
    DeleteRegValue HKLM "${REGKEY}\Components" Main
SectionEnd

Section un.post UNSEC0001
    DeleteRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\$(^Name)"
    Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\Uninstall $(^Name).lnk"
    Delete /REBOOTOK "$SMPROGRAMS\$StartMenuGroup\Archetype Editor.lnk"
    Delete /REBOOTOK $INSTDIR\uninstall.exe
    DeleteRegValue HKLM "${REGKEY}" StartMenuGroup
    DeleteRegValue HKLM "${REGKEY}" Path
    DeleteRegKey /IfEmpty HKLM "${REGKEY}\Components"
    DeleteRegKey /IfEmpty HKLM "${REGKEY}"
    RmDir /REBOOTOK $SMPROGRAMS\$StartMenuGroup
    RmDir /REBOOTOK $INSTDIR
SectionEnd

# Installer functions
Function .onInit
    InitPluginsDir
FunctionEnd


# Uninstaller functions
Function un.onInit
    ReadRegStr $INSTDIR HKLM "${REGKEY}" Path
    !insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuGroup
    !insertmacro SELECT_UNSECTION Main ${UNSEC0000}
FunctionEnd

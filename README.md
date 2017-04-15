This allows you to replace the execution of one application with another (e.g. replace Notepad with Notepad++).

# Example

Download [ApplicationReplacer from the releases page](https://github.com/rgl/ApplicationReplacer/releases/) and
extract it to `C:\Program Files\ApplicationReplacer`.

Then, to replace Notepad with Notepad++ execute (as Administrator) the following PowerShell script:

```powershell
New-Item -Force -Path 'HKLM:\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe' `
    | Set-ItemProperty `
        -Name Debugger `
        -Value '"C:\Program Files\ApplicationReplacer\ApplicationReplacer.exe" -- "C:\Program Files\Notepad++\notepad++.exe"'
```

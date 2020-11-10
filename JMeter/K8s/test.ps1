foreach ($file in Get-ChildItem) {
    if ($file.length -gt 1KB) {
        Write-Host $file
        Write-Host $file.length
        Write-Host $file.lastaccesstime
    }
}
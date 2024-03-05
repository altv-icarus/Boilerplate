param(
    $directoryPath
)

# Check if the directory exists
if (-not (Test-Path -Path $directoryPath)) {
    # If the directory doesn't exist, create it
    New-Item -Path $directoryPath -ItemType Directory -Force
    Write-Output "Directory created: $directoryPath"
} else {
    Write-Output "Directory already exists: $directoryPath"
}
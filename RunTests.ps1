# Run all tests and save output to TestOutput.txt
# Note: 402 (Payment Required) and 429 (Too Many Requests) errors should be ignored
# as they are due to Toggl API rate limiting

Write-Host "Running all tests..." -ForegroundColor Cyan
Write-Host "Output will be saved to TestOutput.txt" -ForegroundColor Cyan
Write-Host ""

# Run dotnet test with detailed verbosity and save output
dotnet test Toggl.Api.Test --logger "console;verbosity=detailed" 2>&1 | Tee-Object -FilePath "TestOutput.txt"

Write-Host ""
Write-Host "Test run complete. Results saved to TestOutput.txt" -ForegroundColor Green
Write-Host ""
Write-Host "Note: 402 and 429 errors are expected due to Toggl API rate limiting and should be ignored." -ForegroundColor Yellow

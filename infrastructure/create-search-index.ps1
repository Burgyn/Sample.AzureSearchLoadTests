param (
    [Parameter(Mandatory = $true)][string]$prefix,
    [Parameter(Mandatory = $true)][string]$apiKey
)

$header = @{
    "Content-Type" = "application/json"
    "api-key"      = "$apiKey"
}

$url = "https://$prefix-search-test-acs.search.windows.net/indexes/ordersindex?api-version=2019-05-06&allowIndexDowntime=true"
$filePath = "index.json"
Write-Host "--------------------------------------------------"
Write-Host $_.info -ForegroundColor Green
Write-Host "url: $url"
Write-Host "filePath: $filePath"
Write-Host

Invoke-WebRequest -Uri $url -Method PUT -Headers $header -InFile $filePath
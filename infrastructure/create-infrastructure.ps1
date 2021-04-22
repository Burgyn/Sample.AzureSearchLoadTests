param (
    [Parameter(Mandatory = $true)][string]$prefix
)

terraform init
terraform apply -var="prefix=$prefix"

$apikey = terraform output search_api_key

& "./create-search-index.ps1" -prefix $prefix -apiKey $apikey
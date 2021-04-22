param (
    [Parameter(Mandatory = $true)][string]$prefix
)

terraform destroy -var="prefix=$prefix"
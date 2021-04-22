provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "example" {
  name     = "${var.prefix}-search-test-rsg"
  location = "West Europe"
}

resource "azurerm_search_service" "example" {
  name                = "${var.prefix}-search-test-acs"
  resource_group_name = azurerm_resource_group.example.name
  location            = azurerm_resource_group.example.location
  sku                 = "standard"
}

output "search_api_key" {
   value = azurerm_search_service.example.primary_key
}
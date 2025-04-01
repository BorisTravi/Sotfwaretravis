provider "azurerm" {
  features {}
}

variable "web_app_name_suffix" {
  type    = string
  default = ""
}

variable "sku" {
  type    = string
  default = "B1"
}

variable "location" {
  type    = string
  default = ""
}

locals {

  unique_suffix         = var.web_app_name_suffix != "" ? web_app_name_suffix : substr(md5(azurerm_resource_group.rg.id), 0, 8)
  web_app_name          = "webapp-${local.unique_suffix}"
  app_service_plan_name = "asp-${local.unique_suffix}"
  location              = var.location != "" ? var.location : azurerm_resource_group.rg.location
}

resource "azurerm_resource_group" "rg" {
  name     = "my-resource-group"
  location = "eastus"

}

resource "azurerm_service_plan" "app_service_plan" {
  name                = local.app_service_plan_name
  resource_group_name = azurerm_resource_group.rg.name
  location            = local.location
  os_type             = "Linux"
  sku_name            = var.sku
}
resource "azurerm_linux_web_app" "app_service" {
  name                = local.web_app_name
  resource_group_name = azurerm_resource_group.rg.name
  location            = local.location
  service_plan_id     = azurerm_service_plan.app_service_plan.id

  site_config {
    application_stack {
      dotnet_version = "8.0" 
    }
  }

  app_settings = {
    ASPNETCORE_ENVIRONMENT  = "Development"
    UseOnlyInMemoryDatabase = "true"
  }
}

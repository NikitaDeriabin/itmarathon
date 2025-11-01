terraform {
  backend "s3" {
    bucket       = "epammarathon2025terraform"
    key          = "terraform.tfstate"
    region       = "eu-central-1"
    use_lockfile = true
    encrypt      = true
  }
}

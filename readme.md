# Záťažový test na odhalenie limitov AZURE Cognitive Search (ACS) indexovania

Postup spustenia záťažového testu:

## Vytvoriť infraštruktúru

Na správu infraštruktúry sa využíva Terraform. Je potrebné ho mať nainštalovaný lokálne. Taktiež je potrebné AZURE CLI.

- Prihlásiť sa do AZURE CLI `az login`
- Nastaviť si správnu subscription *(pokiaľ ich pod svojím účtom máte viac)* `az account set -s {your-subscription}`
- Spustiť vytvorenie infraštruktúry

```cmd
cd .\infrastructure\
.\create-infrastructure.ps1 -prefix {your-prefix}
```

`{your-prefix}`: zdroje ako ACS vyžadujú unikátny názov. Preto je potrebné zadať váš unikátny prefix, ktorý sa pridá k názvu. `{your-prefix}-search-test-acs`

## Spustiť test

```cmd
cd .\src\Sample.AzureSearchLoadTests\
dotnet run run --apiKey {api-key} --prefix {your-prefix} --iterationCount {iteration-count}
```

- `{api-key}`: Api kľúč k vytvorenému ACS. *(Pri vytváraní inraštruktúry sa vypíše na konzolu)*
- `{your-prefix}`: váš prefix infraštruktúry
- `{iteration-count}`: počet iterácií.

## Zrušiť infraštruktúru

```terraform
cd .\infrastructure\
.\destroy-infrastructure.ps1 -prefix {your-prefix}
```

## Výsledky

Výsledky sú v súbore `result.csv`.
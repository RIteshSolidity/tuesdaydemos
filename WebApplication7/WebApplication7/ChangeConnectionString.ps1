param
(
    [string] $sqlUsername,
    [string] $sqlPassword,
    [string] $sqlServer,
    [string] $databaseName
)


# connection string with username and password
# from Azure Key vault
$connectionString =  "Password=$sqlPassword;Persist Security Info=False;User ID=$sqlUsername;Initial Catalog=$databaseName;Data Source=$sqlServer;"

$a = Get-Content 'C:\Users\citynextadmin\source\repos\SampleWebAPP\SampleWebAPP\appsettings.json' -raw | ConvertFrom-Json
$a.ConnectionStrings.CustomerConnection =$connectionString
$a | ConvertTo-Json  | set-content 'C:\mytestBis.json'
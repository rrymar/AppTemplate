Write-Host "Enter migration name:"

$ManualMigration = Read-Host
$MigrationName = $ManualMigration.Replace(" ", "_");


Write-Host "Preparing cs migration '$MigrationName'";

$sourcePath = "\AppTemplate.Database\Migrations"
$destPath = "\AppTemplate.Database.Migrations\Migrations"
$scriptsPath = "\AppTemplate.Database.Migrations\Scripts"
$project = "AppTemplate.Database"
$outpufFile = "\AppTemplate.Database.Migrations\MigrationsScript.sql"
$contextName = "DataContext"
$startupProject  = "AppTemplate.Web"


$root = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot ..\.. ))


pushd $root

dotnet ef migrations add $migrationName --project $project --startup-project $startupProject --context $contextName

popd

Set-location ($root + $scriptsPath)

Write-Host "Prepare sql migration"
try {
    ./toSql.ps1 -project $project -sourcePath $sourcePath -destPath $destPath -contextName $contextName -startupProject $startupProject
}
catch 
{
    popd
    return
}
./create-migration-script.ps1 -sourcePath $destPath -destPath $outpufFile
popd

Write-Host ".cs and .sql migrations have been created. Review creted migrations and remove CS one. Press enter."
Read-Host
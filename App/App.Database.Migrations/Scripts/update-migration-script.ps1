$destPath = "\AppTemplate.Database.Migrations\Migrations"
$outpufFile = "\AppTemplate.Database.Migrations\MigrationsScript.sql"

./create-migration-script.ps1 -sourcePath $destPath -destPath $outpufFile
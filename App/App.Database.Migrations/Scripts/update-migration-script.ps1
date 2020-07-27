$destPath = "\App.Database.Migrations\Migrations"
$outpufFile = "\App.Database.Migrations\MigrationsScript.sql"

./create-migration-script.ps1 -sourcePath $destPath -destPath $outpufFile
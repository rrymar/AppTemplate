$destPath = "AppTemplate.Database.Migrations\SqlMigrations"
$outpufFile = "AppTemplate.Database.Migrations\MigrationsScript.sql"

./create-migration-script.ps1 -sourcePath $destPath -destPath $outpufFile
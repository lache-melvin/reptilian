#requires -PSEdition Core

# install sql server cli tool. flags avoid being prompted during install execution
Install-Module sqlserver -Confirm:$False -Force

$attempts=20
$sleepSeconds=3
do
{
    try
    {
        # instance inside the container 
        # - hostname is db as that's the name of the database service in docker-compose
        # - port 1433 is the default SQL Server port inside the container
        Invoke-Sqlcmd -ServerInstance "db,1433" -Username SA -Password Pa55word! -Query "CREATE DATABASE [reptilian-cli]";
        Write-Host "Database reptilian-cli successfully created.";
        break;
    }
    catch [Exception]
    {
        Write-Host "Retrying..."
    }
    $attempts--
    if ($attempts -gt 0)
    {
        Start-Sleep $sleepSeconds
    }
} while ($attempts -gt 0)
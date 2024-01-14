docker run -it --rm \
    -e "ACCEPT_EULA=Y" \
    -e "SA_PASSWORD=Password1!" \
    -p 1433:1433 \
    --name sqlserver \
    mcr.microsoft.com/mssql/server
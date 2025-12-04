#!/bin/bash

# Iniciar SQL Server en background
/opt/mssql/bin/sqlservr &

# Esperar a que SQL Server esté listo
echo "Esperando a que SQL Server inicie..."
sleep 30

# Ejecutar script de inicialización
echo "Ejecutando script de inicialización..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -C -i /init.sql

echo "Inicialización completada"

# Mantener el contenedor corriendo (importante!)
wait
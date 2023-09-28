@echo off
echo Turning Off Adapter
netsh interface set interface "Wi-Fi" DISABLED
echo Turning Adapter Back On
netsh interface set interface "Wi-Fi" ENABLED
echo Adapter Restarted
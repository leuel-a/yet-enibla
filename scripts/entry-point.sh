#!/bin/bash
set -e

echo "Applying database migrations..."
cd ./yet-enibla.Web && dotnet ef database update

# function to display a colored progress bar
show_progress () {
    local progress=$1
    local total=50
    local done=$((progress * total / 100))
    local remaining=$((total - done))

    local green=$(printf '\e[42m')
    local red=$(printf '\e[41m')
    local reset=$(printf '\e[0m')

    printf "\rProgress: ["
    printf "%-${done}s" "" | sed "s/ /${green} /g"
    printf "%-${remaining}s" "" | sed "s/ /${red} /g"
    printf "${reset}] %d%%" "$progress"
}

for i in $(seq 0 5 100); do
    show_progress $i
    sleep 0.2
done

echo

echo "Starting the application..."
cd ..
dotnet yet-enibla.Web.dll

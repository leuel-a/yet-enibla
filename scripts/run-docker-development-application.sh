#!/usr/bin/env bash

docker run -e ASPNETCORE_URLS="http://+:3000" \
  -e ASPNETCORE_ENVIRONMENT="Production" \
  -p 3000:3000 \
  yet-enibla-dev:latest

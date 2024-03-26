#!/bin/bash
version="1.0.0" 
repo="anwaarnoaman/"
 
dotnet clean
dotnet build
docker build -t "$repo"bambooapi:"$version" -f Dockerfile .
 
docker push "$repo"bambooapi:"$version"
 
echo "$repo"bambooapi:"$version task completed"
 
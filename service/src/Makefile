SHELL := /bin/bash
SLN_NAME = OnlineClothes

migrate:
	cd ./$(SLN_NAME).Persistence && dotnet ef migrations add $(name) -s ../$(SLN_NAME).Api/
	
remove-migrate:
	cd ./$(SLN_NAME).Persistence && dotnet ef migrations remove  -s ../$(SLN_NAME).Api/

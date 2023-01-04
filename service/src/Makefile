SHELL := /bin/bash
SLN_NAME = OnlineClothes

migrate:
	cd ./$(SLN_NAME).Persistence && dotnet ef migrations add $(name) -s ../$(SLN_NAME).Api/
	
update-db:
	cd ./$(SLN_NAME).Persistence && dotnet ef database update -s ../$(SLN_NAME).Api/
	
remove-migrate:
	cd ./$(SLN_NAME).Persistence && dotnet ef migrations remove  -s ../$(SLN_NAME).Api/
	
compose-up:
	docker-compose -f docker-compose.dev.yaml -p oop_src up -d --remove-orphans 
	
compose-down:
	docker-compose -f docker-compose.dev.yaml -p oop_src down 

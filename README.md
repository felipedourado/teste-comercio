# teste-comercio

Este projeto tem por finalidade a utilização de um exercício.

O Projeto utiliza as seguintes tecnologias:

ASP.NET Core 7.0
Entity Framework Core 7.0
MediatR
Swagger
Redis (for distributed caching)
Sql Server
Jwt Token Authentication
Custom Asp.Net Identity
Api Versioning
FluentValidation
PolyCache (for caching)
Serilog
Elasticsearch (for writing Logs)
Mapper
Docker
xUnit
HealthCheck-UI

Boas práticas e princípios de design:

Clean Architecture
Clean Code
CQRS
Authentication and Authorization
Distributed caching
Solid Principles
Separate ReadOnly and Write DbContext
Separate ReadOnly and Write Repository
REST API Naming Conventions
Use multiple environments in ASP.NET Core (Development,Production,Staging,etc)
Modular Design
Custom Exceptions
Custom Exception Handling
Unit tests
Integration tests
PipelineBehavior for Validation and Performance tracking.


![teste](https://github.com/felipedourado/teste-comercio/assets/5496333/14a22500-b1dc-4dc1-bfc3-3cc663220f11)


Para subir esse projeto é necessário rodar o docker-compose-redis-only e em seguida o docker-compose.sql-server
Tambem será necessário buildar o projeto e abrir o Package Manager Console e executar o seguinte comando:

Update-Database -Context AppDbContext




ToDo

Segregar a criação de usuários para uma aplicação apenas de identity server e utilizar base mongo
Gerar PDF do relatorio consolidado
Enviar relatorio consolidado por email
Trocar SQL Server por mysql
Unificar os arquivos docker-compose em um só
Subir Kibana e Logstash para validar os logs gerados
SonarLint
MutationTest
Boas Práticas OWASP para segurança
Implementar 2FA no indentity server
FortClient


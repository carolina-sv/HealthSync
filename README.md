# HealthSync - API de Agendamentos Médicos

API resiliente desenvolvida em **.NET 10** utilizando **Clean Architecture** e **DDD**.

## Tecnologias e Arquitetura
- **Clean Architecture**: Separação clara entre Domain, Application, Infrastructure e API.
- **PostgreSQL**: Persistência de dados relacionais.
- **RabbitMQ**: Mensageria assíncrona para notificações de agendamentos.
- **Background Services**: Worker service para consumo de filas em tempo real.

## Como Rodar o Projeto

### 1. Infraestrutura (Docker)
Suba os containers necessários para o funcionamento do sistema:

# Banco de Dados (PostgreSQL)
docker run -d --name HealthSyncDb -p 5432:5432 -e POSTGRES_PASSWORD=sua_senha -d postgres

# Mensageria (RabbitMQ com Painel Management)
docker run -d --name HealthSync_RabbitMQ -p 5672:5672 -p 15672:15672 rabbitmq:3-management

### 2. Configuração de Segurança (User Secrets)
As credenciais de banco estão ocultas por segurança. Configure sua string de conexão localmente:

cd src/HealthSync.API
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=HealthSyncDb;Username=postgres;Password=sua_senha"

### 3. Execução
dotnet run --project src/HealthSync.API

## Endpoints Principais
- **POST /api/Patients**: Cadastra um novo paciente (necessário para agendamentos).
- **POST /api/Appointments**: Cria um agendamento e dispara evento para o RabbitMQ.
- **Swagger UI**: Disponível em http://localhost:5000/swagger

## Preview 

<img width="1176" height="1849" alt="HealthSync" src="https://github.com/user-attachments/assets/a674a197-8a4c-4fa3-9975-9cec946bc0ce" />


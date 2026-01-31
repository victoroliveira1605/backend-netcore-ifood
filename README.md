# iFood API

API REST desenvolvida em .NET Core 8.0 para gerenciamento de restaurantes e pedidos.

## 🚀 Tecnologias

- .NET 8.0
- ASP.NET Core Web API
- Swagger/OpenAPI
- Health Checks

## 📋 Funcionalidades

### Restaurantes
- `GET /api/restaurantes` - Lista todos os restaurantes ativos
- `GET /api/restaurantes/{id}` - Obtém um restaurante por ID

### Pedidos
- `GET /api/pedidos` - Lista todos os pedidos
- `GET /api/pedidos/{id}` - Obtém um pedido por ID
- `GET /api/pedidos/restaurante/{restauranteId}` - Lista pedidos de um restaurante específico

## 🏗️ Arquitetura

A API segue os padrões de mercado para .NET Core:

- **Repository Pattern** - Separação de acesso a dados
- **Service Layer** - Lógica de negócio isolada
- **DTOs** - Transferência de dados otimizada
- **Dependency Injection** - Inversão de controle
- **Health Checks** - Monitoramento de saúde da aplicação
- **Logging** - Registro de eventos e erros
- **Swagger** - Documentação automática da API

## 📁 Estrutura do Projeto

```
iFoodApi/
├── Controllers/          # Controladores da API
├── DTOs/                 # Data Transfer Objects
├── Models/               # Modelos de domínio
├── Repositories/         # Repositórios (acesso a dados)
├── Services/             # Serviços (lógica de negócio)
├── Program.cs            # Configuração da aplicação
└── appsettings.json      # Configurações
```

## 🛠️ Como Executar

### Pré-requisitos
- .NET 8.0 SDK instalado

### Executar a aplicação

```bash
# Restaurar dependências
dotnet restore

# Executar a aplicação
dotnet run
```

A API estará disponível em:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger: `https://localhost:5001/swagger` ou `http://localhost:5000/swagger`

## 📝 Exemplos de Uso

### Listar Restaurantes
```bash
GET https://localhost:5001/api/restaurantes
```

### Listar Pedidos
```bash
GET https://localhost:5001/api/pedidos
```

### Obter Pedidos de um Restaurante
```bash
GET https://localhost:5001/api/pedidos/restaurante/1
```

## 🔍 Health Check

```bash
GET https://localhost:5001/health
```

## 📚 Documentação

A documentação completa da API está disponível através do Swagger UI quando a aplicação está em execução.

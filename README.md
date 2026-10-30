## 📋 Sobre o projeto

O **TaskFlow API** é uma API REST desenvolvida em C# com ASP.NET Core para gerenciamento de projetos pessoais e tarefas, permitindo organizar atividades, definir prioridades e prazos e acompanhar seu andamento.

## 🎯 Objetivo

Praticar e demonstrar boas práticas de desenvolvimento backend, explorando os princípios SOLID, Design Patterns quando apropriado e testes automatizados.

## 📦 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- **.NET SDK 10.0:** para compilar e executar a API.
- **Docker:** para executar o PostgreSQL em um contêiner.
- **Git:** para clonar o repositório.
- **Visual Studio ou outra IDE compatível com desenvolvimento .NET** para facilitar a execução e depuração da API.

## 🛠️ Configuração do ambiente local

Siga os passos abaixo para configurar o banco de dados PostgreSQL e executar a API localmente.

### 1. Configure as variáveis de ambiente do Docker

Na raiz do projeto, você encontrará o arquivo `.env.example`, que contém um exemplo da configuração necessária para o PostgreSQL.

1. Crie uma cópia do arquivo `.env.example` e renomeie-a para `.env`.
2. Abra o arquivo `.env` e substitua `COLOQUE_SUA_SENHA` pela senha que deseja utilizar no PostgreSQL.

**Importante:** o arquivo `.env` contém informações locais e não deve ser enviado ao repositório. Ele já está incluído no `.gitignore`.

### 2. Inicie o banco de dados

Com o Docker instalado e em execução, abra um terminal na pasta que contém o arquivo `compose.yaml` e execute:

```bash
docker compose up -d
```

O Docker Compose utilizará as configurações do arquivo `.env` para iniciar o contêiner do PostgreSQL.

Aguarde a inicialização do banco antes de prosseguir.

### 3. Configure os User Secrets da API

Para manter a senha do banco fora dos arquivos versionados, a API utiliza o recurso User Secrets do .NET durante o desenvolvimento local.

No terminal, entre na pasta do projeto que contém o arquivo `.csproj` e execute:

```bash
dotnet user-secrets init
```

Esse comando precisa ser executado apenas uma vez por projeto na sua máquina.

Em seguida, configure a connection string:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=TaskFlowDB;Username=postgres;Password=SUA_SENHA"
```

Substitua `SUA_SENHA` pela mesma senha configurada no arquivo `.env`.

Os User Secrets são armazenados fora da pasta do projeto e não são enviados ao GitHub.

### 4. Execute a API

Após iniciar o PostgreSQL e configurar os User Secrets, execute a API pelo Visual Studio ou pelo terminal:

```bash
dotnet run
```

A aplicação utilizará a connection string configurada nos User Secrets para se conectar ao banco de dados local.

**Observação:** se o projeto exigir migrations para criar as tabelas, execute as migrations antes de utilizar os endpoints da API.

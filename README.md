# 💻 FIAP Cloud Games (FCG) 

![Status do Build](https://shields.io)
![Licença](https://shields.io)

> Api com o objetivo de manter uma plataforma de venda de jogos digitais e gestão de servidores para partidas online.

## 🚀 Funcionalidades

- [x] Autenticação segura via JWT.
- [x] Integração em tempo real com banco de dados.
- [ ] Módulo de Jogos (Em desenvolvimento).

## 🛠️ Tecnologias Utilizadas

O projeto foi desenvolvido utilizando a seguinte stack tecnológica:

* **Linguagem:** C# (.NET 8)
* **Framework:** ASP.NET Core Web API
* **Documentação:** Swagger (OpenAPI)
* **Banco de Dados:** SQL Server / Entity Framework Core

## 🌐 Estrutura da API REST (.NET 8)

A API foi desenhada seguindo as convenções arquiteturais do REST, utilizando JSON para tráfego de dados. Os endpoints principais mapeados e disponíveis para consumo são:

| Método | Endpoint | Descrição | Status HTTP |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/usuario` | Lista todos os usuários cadastrados | `200 OK` |
| **GET** | `/api/usuario/{id}` | Busca um usuário específico por ID | `200 OK` / `404 Not Found` |
| **POST** | `/api/usuario` | Cadastra um novo usuário no sistema | `201 Created` / `400 Bad Request` |
| **PUT** | `/api/usuario/{id}` | Atualiza os dados de um usuário existente | `204 No Content` / `400 Bad Request` |

## 📦 Como Instalar e Rodar Localmente

Siga o guia passo a passo para configurar o ambiente de desenvolvimento local:

1. **Clonar o Repositório:**
   ```bash
   git clone https://github.com
   cd Fiap.Cloud.Games
   ```
2. **Configurar as Variáveis de Ambiente:**
   Com o projeto `Fiap.Cloud.Games.Api` rodando `HTTP`,  existe um arquivo chamado `Fiap.Cloud.Games.Api.http` com as credenciais configuradas para geração de tokens com dois níveis de acesso `Usuário` e  `Administrador`.

3. **Banco de Dados:**
Com banco `Sqlite` já configurado no projeto, não tem necessidade de gerar `Migrations`,  existe um arquivo chamado `Fiap.Cloud.Games.Api.http` com json email e senha inseridos para geração de tokens com dois níveis de acesso `Usuário` e  `Administrador`.

4. **Instalar Dependências e Iniciar:**
   ```bash
   npm install
   npm run dev
   ```

## 📄 Licença

Este projeto está sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais informações.

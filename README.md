# 💻 FIAP Cloud Games (FCG) 

> Api com o objetivo de manter uma plataforma de venda de jogos digitais e gestão de servidores para partidas online.

## 🚀 Funcionalidades

- [x] Autenticação segura via JWT.
- [x] Integração em tempo real com banco de dados.
- [x] Projeto de teste.
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
2. **Configurar Ambiente:**
   Com o projeto `Fiap.Cloud.Games.Api` rodando em uma máquina windows no protocolo `HTTP`, não tem necessidade de configuração.

3. **Use os JSONs Prontos:**.
   Utilize o arquivo estruturado `Fiap.Cloud.Games.Api.http` para obter login(email) e senha.

4. **Níveis de Acesso:**.
  Token gerado corresponde ao nível exigido pelo endpoint (o arquivo `Fiap.Cloud.Games.Api.http` possui modelos prontos para os perfis Usuário e Administrador).

5. **Banco de Dados Em Memória:**
Com banco `Sqlite` já configurado no projeto, não tem necessidade de gerar `Migrations`, o arquivo `api_banco.db` que está na camada `Fiap.Cloud.Games.Infra.` consta as tabelas necessárias para rodar o projeto.

## 📄 Licença

Este projeto está sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais informações.

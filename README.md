# API de Controle de Estoque

## Descrição
Esta API foi desenvolvida para gerenciar o controle de estoque de produtos, permitindo a entrada e saída de itens. Além disso, a API mantém um log detalhado de todas as operações realizadas, permitindo um acompanhamento preciso do histórico de movimentações de estoque.

## Funcionalidades
- **Consulta de todos os Produtos**
- **Consulta de um Produto específico pelo Id**
- **Registro de Produtos**
- **Atualização de um Produto**
- **Remoção de um Produto**
- **Entrada de quantidade de Produtos no estoque**
- **Saída de quantidade de Produtos no estoque**
- **Consulta de todas as Transações**
- **Remoção de Transações**

## Tecnologias Utilizadas
- **C#** com **ASP.NET Core**
- **Entity Framework Core** para manipulação do banco de dados
- **SqLite** para persistência de dados
- **Swagger** para documentação da API

## Endpoints Principais

### Produtos
- **GET /produtos** - Lista todos os produtos.
- **GET /produtos/{id}** - Obtém detalhes de um produto específico.
- **POST /produtos** - Cadastra um novo produto.
- **PUT /produtos/{id}** - Atualiza os dados de um produto existente.
- **DELETE /produtos/{id}** - Remove um produto.

### Movimentações de Estoque
- **POST /entrada** - Registra a entrada de um produto.
- **POST /saida** - Registra a saída de um produto.
- **GET /transacoes** - Consulta o log de movimentações de entrada e saída.

## Como Rodar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/Murilo013/ControleDeEstoque.git
   
2. Execute as migrações para criar o banco de dados
   ```bash
   dotnet ef database update
   
3. Inicie a API
   ```bash
   dotnet run
   
4. Pegue a url indicada e insira "/swagger" após.
 
   

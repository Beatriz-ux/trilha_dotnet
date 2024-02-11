# Pratica de .net P004 - Gestão Financeira Pessoal
## Endpoints
- Categoria:
    [HttpGet("Categoria")]: Exibir todas as categorias que foram cadastradas
    [HttpGet("Categoria/{id}")]: Exibir uma determinada categoria a partir do Id
    [HttpPost("Categoria")]: Recebe as informações para cadastrar uma nova Categoria
    [HttpDelete("Categoria/{id}")]: Apaga uma categoria por id
- Conta:
    [HttpGet("Conta")]: Exibir todas as contas que foram cadastradas
    [HttpGet("Conta/{id}")]: Exibir uma determinada conta a partir do Id
    [HttpPost("Conta")]: Recebe as informações para cadastrar uma nova Conta
    [HttpDelete("Conta/{id}")]: Apaga uma conta por id

- Custo Fixo e Custo Variavel:
    [HttpGet("Custo")]: Exibir todas as custos que foram cadastradas
    [HttpGet("Custo/{id}")]: Exibir uma determinada custo a partir do Id
    [HttpPost("Custo")]: Recebe as informações para cadastrar uma nova custo
    [HttpDelete("Custo/{id}")]: Apaga uma custo por id
    [HttpPut]

- Investimento:
    [HttpGet("Investimento")]: Exibir todos os investimentos que foram cadastradas
    [HttpGet("Investimento/{id}")]: Exibir uma determinado investimento a partir do Id
    [HttpPost("Investimento")]: Recebe as informações para cadastrar um novo investimento
    [HttpDelete("Investimento/{id}")]: Apaga um investimento por id

- Objetivo:
    [HttpGet("objetivo")]: Exibir todos os objetivos que foram cadastradas
    [HttpGet("objetivo/{id}")]: Exibir um determinado objetivo a partir do Id
    [HttpPost("objetivo")]: Recebe as informações para cadastrar um novo objetivo
    [HttpDelete("objetivo/{id}")]: Apaga um objetivo por id

- Transacao:
    [HttpGet("transação")]: Exibir todas as transações que foram cadastradas
    [HttpGet("transação/{id}")]: Exibir uma determinada transação a partir do Id
    [HttpPost("transação")]: Recebe as informações para cadastrar uma nova transação
    [HttpDelete("transação/{id}")]: Apaga uma transação por id

- Usuario:
    [HttpGet("usuario")]: Exibir todos os usuarios que foram cadastradas
    [HttpGet("usuario/{id}")]: Exibir uma determinado usuario a partir do Id
    [HttpPost("usuario")]: Recebe as informações para cadastrar um novo usuario
    [HttpDelete("usuario/{id}")]: Apaga um usuario por id
    [HttpPut("{usuarioId}")] : Atualiza um usuario


    

## Visão Geral
Este projeto tem como objetivo auxiliar os usuários na gestão de suas finanças pessoais. Ele permitirá registrar entradas e saídas de dinheiro, agendar gastos futuros, lidar com gastos parcelados e muito mais.

## Entidades Principais
O projeto será composto pelas seguintes entidades principais:

### 1. Conta
Uma conta representa a fonte de dinheiro do usuário, como contas bancárias, carteira, investimentos, etc.

### 2. Transação
Uma transação é um registro de dinheiro que entra ou sai da conta. Pode ser uma compra, pagamento, depósito, retirada, etc.

### 3. Categoria
As categorias são utilizadas para classificar as transações, ajudando o usuário a entender como está gastando seu dinheiro. Exemplos de categorias incluem alimentação, moradia, transporte, lazer, etc.

### 4. Gasto Futuro
Os gastos futuros são despesas planejadas que ocorrerão em uma data posterior. Os usuários podem agendar esses gastos para um melhor planejamento financeiro.

### 5. Gasto Parcelado
Gastos parcelados são despesas que se repetem regularmente, como aluguel, mensalidades, etc. Eles podem ser registrados como parcelas que ocorrem em datas específicas.

## Relacionamentos
As principais relações entre as entidades são:

- Uma Conta pode ter várias Transações.
- Uma Transação pertence a uma única Conta e está associada a uma Categoria.
- Um Gasto Futuro pertence a uma Conta e pode ocorrer em uma data futura.
- Um Gasto Parcelado pertence a uma Conta e é composto por várias parcelas.

## Tecnologias
O projeto será desenvolvido usando as seguintes tecnologias:
- Backend: .Net
- Banco de Dados: MySQL

## Funcionalidades Planejadas
Algumas das funcionalidades planejadas para este projeto incluem:
- Registro de transações financeiras.
- Classificação de transações em categorias.
- Agendamento de gastos futuros.
- Gerenciamento de gastos parcelados.
- Visualização de relatórios e gráficos de despesas.
- Estabelecimento de metas de economia.

---
<p> Este é um esboço inicial do projeto de gestão financeira pessoal. As entidades e relacionamentos podem ser mais detalhados e refinados conforme o projeto avança. </p>

## Autores

| [<img src="https://avatars.githubusercontent.com/u/81397160?v=4" width=115><br><sub>Alberto Henrique</sub>](https://github.com/albertolunia) | [<img src="https://avatars.githubusercontent.com/u/82838311?v=4" width=115><br><sub>Beatriz</sub>](https://github.com/Beatriz-ux) |  [<img src="https://avatars.githubusercontent.com/u/59913116?v=4" width=115><br><sub>Alessandro</sub>](https://github.com/AlessanBass) | [<img src="https://avatars.githubusercontent.com/u/42046499?v=4" width=115><br><sub>Brendom Gonçalves</sub>](https://github.com/BrendomGoncalves) | [<img src="https://avatars.githubusercontent.com/u/17802288?v=4" width=115><br><sub>Lucas</sub>](https://github.com/eulucasilva) |
| :------------------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------: |

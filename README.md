# Pratica de .net P004 - Gestão Financeira Pessoal
## Endpoints
- Categoria:
    [HttpGet("Categoria")]: Exibir todas as categorias que foram cadastradas
    [HttpGet("Clientes/{id}")]: Exibir uma determinada categoria a partir do Id
    [HttpPost("Clientes")]: Recebe as informações para cadastrar uma nova Categoria
    [HttpDelete("Clientes/{id}")]: Apaga uma categoria por id


    

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

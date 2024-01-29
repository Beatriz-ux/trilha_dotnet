-- Inserir dados na tabela 'categoria'
INSERT INTO categoria (nomeCategoria) VALUES
('Alimentação'),
('Transporte'),
('Lazer');

-- Inserir dados na tabela 'conta'
INSERT INTO conta (tipoConta, saldoConta) VALUES
('Corrente', 5000.00),
('Poupança', 10000.00),
('Investimento', 25000.00);

-- Inserir dados na tabela 'Custo_Fixo'
INSERT INTO Custo_Fixo (valorParcelaFixo, dataProximaParcelaFixo, parcelasRestanresFixo, idConta, idCategoria) VALUES
(500.00, '2024-02-01', 12, 1, 1),
(200.00, '2024-02-05', 6, 2, 2);

-- Inserir dados na tabela 'Custo_Variavel'
INSERT INTO Custo_Variavel (valorVariavel, dataPlanejada, idConta, idCategoria) VALUES
(100.00, '2024-02-10', 1, 3),
(50.00, '2024-02-15', 3, 1);

-- Inserir dados na tabela 'trasicao'
INSERT INTO trasicao (valorTransacao, dataTransacao, tipoTransacao, idConta, idCategoria) VALUES
(50.00, '2024-02-20', 'Débito', 2, 2),
(200.00, '2024-02-25', 'Crédito', 1, 3);

-- Inserir dados na tabela 'usuario'
INSERT INTO usuario (nomeUsuario, emailUsuario, senhaUsuario, idConta) VALUES
('João Silva', 'joao@email.com', 'senha123', 2),
('Maria Oliveira', 'maria@email.com', 'senha456', 3);
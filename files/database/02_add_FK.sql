ALTER TABLE Custo_Variavel
ADD CONSTRAINT fk_custo_variavel_conta
FOREIGN KEY (idConta) REFERENCES Conta(idConta);

ALTER TABLE Custo_Variavel
ADD CONSTRAINT fk_custo_variavel_categoria
FOREIGN KEY (idCategoria) REFERENCES Conta(idCategoria);

ALTER TABLE Custo_Fixo
ADD CONSTRAINT fk_custo_fixo_conta
FOREIGN KEY (idConta) REFERENCES Conta(idConta);

ALTER TABLE Custo_Fixo
ADD CONSTRAINT fk_custo_fixo_categoria
FOREIGN KEY (idCategoria) REFERENCES Conta(idCategoria);

ALTER TABLE Transicao
ADD CONSTRAINT fk_transicao_conta
FOREIGN KEY (idConta) REFERENCES Conta(idConta);

ALTER TABLE Transicao
ADD CONSTRAINT fk_transicao_categoria
FOREIGN KEY (idCategoria) REFERENCES Conta(idCategoria);

ALTER TABLE Usuario
ADD CONSTRAINT fk_usuario_conta
FOREIGN KEY (idConta) REFERENCES Conta(idConta);
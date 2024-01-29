ALTER TABLE Custo_Fixo
ADD CONSTRAINT fk_custo_fixo_conta
FOREIGN KEY (idConta) REFERENCES conta(idConta);

ALTER TABLE Custo_Fixo
ADD CONSTRAINT fk_custo_fixo_categoria
FOREIGN KEY (idCategoria) REFERENCES categoria(idCategoria);

ALTER TABLE Custo_Variavel
ADD CONSTRAINT fk_custo_variavel_conta
FOREIGN KEY (idConta) REFERENCES conta(idConta);

ALTER TABLE Custo_Variavel
ADD CONSTRAINT fk_custo_variavel_categoria
FOREIGN KEY (idCategoria) REFERENCES categoria(idCategoria);

ALTER TABLE trasicao
ADD CONSTRAINT fk_transacao_conta
FOREIGN KEY (idConta) REFERENCES conta(idConta);

ALTER TABLE trasicao
ADD CONSTRAINT fk_transacao_categoria
FOREIGN KEY (idCategoria) REFERENCES categoria(idCategoria);

ALTER TABLE usuario
ADD CONSTRAINT fk_usuario_conta
FOREIGN KEY (idConta) REFERENCES conta(idConta);
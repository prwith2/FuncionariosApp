CREATE DATABASE MeuPesqueiroDB;
USE MeuPesqueiroDB;

-- TABELA: Funcionários
CREATE TABLE Funcionarios (
    Id_funcionario INT PRIMARY KEY,
    Nome_funcionario VARCHAR(100),
    Senha_funcionario VARCHAR(30)
);

-- TABELA: Equipamentos
CREATE TABLE Equipamentos (
    Id_equipamentos INT PRIMARY KEY,
    Nome_equipamento VARCHAR(100),
    Equipamento_em_Uso BIT,
    Quantidade_Equipamento INT
);

-- TABELA: Gerencia (Relacionamento N:N entre Funcionários e Equipamentos)
CREATE TABLE Gerencia (
    Id_funcionario INT,
    Id_equipamentos INT,
    PRIMARY KEY (Id_funcionario, Id_equipamentos),
    FOREIGN KEY (Id_funcionario) REFERENCES Funcionarios(Id_funcionario),
    FOREIGN KEY (Id_equipamentos) REFERENCES Equipamentos(Id_equipamentos)
);

-- TABELA: Aluguel
CREATE TABLE Aluguel (
    Id_aluguel INT PRIMARY KEY,
    Valor_aluguel DECIMAL(10,2),
    Data_hora_retirada DATETIME,
    Data_hora_devolucao DATETIME,
    Observacao VARCHAR(500),
    Id_equipamentos INT,
    FOREIGN KEY (Id_equipamentos) REFERENCES Equipamentos(Id_equipamentos)
);

-- TABELA: Cliente
CREATE TABLE Cliente (
    Id_cliente INT PRIMARY KEY,
    Nome_cliente VARCHAR(100),
    Senha_cliente VARCHAR(30),
    Email_cliente VARCHAR(40)
);

-- TABELA: AluguelCliente (Relacionamento N:N)
CREATE TABLE AluguelCliente (
    Id_cliente INT,
    Id_aluguel INT,
    PRIMARY KEY (Id_cliente, Id_aluguel),
    FOREIGN KEY (Id_cliente) REFERENCES Cliente(Id_cliente),
    FOREIGN KEY (Id_aluguel) REFERENCES Aluguel(Id_aluguel)
);

-- TABELA: Compra
CREATE TABLE Compra (
    Id_compra INT PRIMARY KEY,
    Dt_compra DATE,
    Valor_total DECIMAL(10,2)
);

-- TABELA: CompraCliente (Relacionamento N:N)
CREATE TABLE CompraCliente (
    Id_cliente INT,
    Id_compra INT,
    PRIMARY KEY (Id_cliente, Id_compra),
    FOREIGN KEY (Id_cliente) REFERENCES Cliente(Id_cliente),
    FOREIGN KEY (Id_compra) REFERENCES Compra(Id_compra)
);

-- TABELA: Produtos
CREATE TABLE Produtos (
    Id_produto INT PRIMARY KEY,
    Nome_produto VARCHAR(100),
    Valor_produto DECIMAL(10,2),
    Qtd_produto INT,
    Fornecedor VARCHAR(100),
    IdCompra INT,
    FOREIGN KEY (IdCompra) REFERENCES Compra(Id_compra)
);

-- TABELA: PeixeCapturado
CREATE TABLE PeixeCapturado (
    Id_peixeCapturado INT PRIMARY KEY,
    Peso DECIMAL(5,2),
    DataPeixeCapturado DATE,
    IdEspecie INT,
    FOREIGN KEY (IdEspecie) REFERENCES Especie(Id_especie)
);

-- TABELA: PeixeCliente (Relacionamento N:N)
CREATE TABLE PeixeCliente (
    Id_cliente INT,
    Id_peixeCapturado INT,
    PRIMARY KEY (Id_cliente, Id_peixeCapturado),
    FOREIGN KEY (Id_cliente) REFERENCES Cliente(Id_cliente),
    FOREIGN KEY (Id_peixeCapturado) REFERENCES PeixeCapturado(Id_peixeCapturado)
);

-- TABELA: Especie
CREATE TABLE Especie (
    Id_especie INT PRIMARY KEY,
    Nome_especie VARCHAR(100),
    Valor_especie DECIMAL(10,2),
    Fornecedor_especie VARCHAR(100)
);

-- TABELA: Lagos
CREATE TABLE Lagos (
    Id_lago INT PRIMARY KEY,
    Nome_lago VARCHAR(100)
);

-- TABELA: EspecieLago (Relacionamento N:N)
CREATE TABLE EspecieLago (
    Id_especie INT,
    Id_lago INT,
	Qtd_peixes INT
    PRIMARY KEY (Id_especie, Id_lago),
    FOREIGN KEY (Id_especie) REFERENCES Especie(Id_especie),
    FOREIGN KEY (Id_lago) REFERENCES Lagos(Id_lago)
);

-- TABELA: Pesqueiro
CREATE TABLE Pesqueiro (
    Id_pesqueiro INT PRIMARY KEY,
    Nome VARCHAR(100),
    Email VARCHAR(100),
    Telefone VARCHAR(20),
    Latitude VARCHAR(50),
    Longitude VARCHAR(50),
    Fotos TEXT
);

-- TABELA: Comentarios
CREATE TABLE Comentarios (
    Id_comentario INT PRIMARY KEY,
    Texto VARCHAR(500),
    Avaliacao INT,
    IdPesqueiro INT,
    FOREIGN KEY (IdPesqueiro) REFERENCES Pesqueiro(Id_pesqueiro)
);

-- TABELA: ClienteComentario (Relacionamento N:N)
CREATE TABLE ClienteComentario (
    Id_comentario INT,
    Id_cliente INT,
    PRIMARY KEY (Id_comentario, Id_cliente),
    FOREIGN KEY (Id_comentario) REFERENCES Comentarios(Id_comentario),
    FOREIGN KEY (Id_cliente) REFERENCES Cliente(Id_cliente)
);

-- TABELA: Favoritos (Relacionamento N:N entre Pesqueiro e Cliente)
CREATE TABLE Favoritos (
    Id_pesqueiro INT,
    Id_cliente INT,
    PRIMARY KEY (Id_pesqueiro, Id_cliente),
    FOREIGN KEY (Id_pesqueiro) REFERENCES Pesqueiro(Id_pesqueiro),
    FOREIGN KEY (Id_cliente) REFERENCES Cliente(Id_cliente)
);

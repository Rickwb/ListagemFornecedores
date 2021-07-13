CREATE DATABASE ProjetoEmpresas

CREATE TABLE Empresa(
Id int primary key identity,
NomeFantasia varchar(100),
CNPJ varchar(14) not null,
UF varchar(2))

CREATE TABLE FornecedorPJ(
ID int primary key identity,
EmpresaId int,
FornecedorNome varchar(100),
FornecedorCNPJ varchar(14),
DataCadastro DateTime,
Telefone varchar(20),
foreign key (EmpresaId) references Empresa(ID))

CREATE TABLE FornecedorPF(
ID int primary key identity,
EmpresaId int,
FornecedorNome varchar(100),
FornecedorCPF varchar(11),
FornecedorRG varchar(11),
DataNascimento Date,
DataCadastro DateTime,
Telefone varchar(20),
foreign key (EmpresaId) references Empresa(ID))






)
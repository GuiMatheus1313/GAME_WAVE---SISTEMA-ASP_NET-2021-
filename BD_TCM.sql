CREATE database BDLojaJogos_tcm;
USE BDLojaJogos_tcm;

##drop database BDLojaJogos_tcm;


CREATE TABLE TBEstado (
    id_uf INT PRIMARY KEY auto_increment,
    nome_uf VARCHAR(2) NOT NULL 
);

CREATE TABLE TBCidade (
    iD_Cidade INT PRIMARY KEY auto_increment,
    nome_Cidade VARCHAR(50) NOT NULL
);

CREATE TABLE TBBairro (
    id_bairro INT PRIMARY KEY auto_increment,
    nome_bairro VARCHAR(100) NOT NULL
);

CREATE TABLE TBCep (
    cep VARCHAR(11) PRIMARY KEY,
    logradouro VARCHAR(100) NOT NULL,
    fk_Estado_Id_uf INT NOT NULL,
    fk_Cidade_ID_Cidade INT NOT NULL,
    fk_Bairro_Id_bairro INT NOT NULL,
    CONSTRAINT fK_Cep_Estado FOREIGN KEY (fk_Estado_Id_uf)REFERENCES TBEstado (id_uf),
    CONSTRAINT fK_Cep_Cidade FOREIGN KEY (fk_Cidade_ID_Cidade)REFERENCES TBCidade (iD_Cidade),
    CONSTRAINT fK_Cep_Bairro FOREIGN KEY (fk_Bairro_Id_bairro) REFERENCES TBBairro (id_bairro)
);

CREATE TABLE TBCupom (
    cupom_cod VARCHAR(20) PRIMARY KEY,
    descontoCupom float NOT NULL
);


CREATE TABLE TBCliente (
    cli_cpf varchar(14) PRIMARY KEY,
    cli_Nome VARCHAR(100) NOT NULL,
    cli_NumEnd INT NOT NULL,
    cli_email VARCHAR(100) NOT NULL,
    cli_tel long NOT NULL,
    fk_Cep_cep VARCHAR(11) NOT NULL,
    CONSTRAINT FK_Cliente_Cep FOREIGN KEY (fk_Cep_cep) REFERENCES TBCep (cep)
);

CREATE TABLE TBFuncionario (
    func_Cod INT PRIMARY KEY auto_increment,
    func_Nome VARCHAR(100) NOT NULL,
    func_CPF varchar(14) unique NOT NULL,
    func_Tel long NOT NULL,
    func_Email VARCHAR(100) NOT NULL,
    func_DataNasc DATE NOT NULL,
    func_Num_End INT NOT NULL,
    func_Cargo VARCHAR(30) NOT NULL,
    func_senha varchar(10) not null,
    fk_Cep_cep VARCHAR(11) NOT NULL,
    CONSTRAINT FK_Funcionario_Cep FOREIGN KEY (fk_Cep_cep) REFERENCES TBCep (cep)
);


CREATE TABLE TBProduto (
    cod_Prod INT PRIMARY KEY auto_increment,
    prod_Nome VARCHAR(100) unique NOT NULL,
    prod_Tipo VARCHAR(50) NOT NULL,
    prod_Quant_Estoque INT NOT NULL,
    prod_Desc TEXT NOT NULL,
    prod_AnoLanc VARCHAR(4) NOT NULL,
    prod_FaixaEta VARCHAR(10) NOT NULL,
    prod_Valor float NOT NULL 
);


CREATE TABLE TBTeste (
    agen_Cod int PRIMARY KEY auto_increment,
    age_DtRetirada DATE NOT NULL,
    age_Desc VARCHAR(120),
    fk_Cliente_Cli_cpf varchar(14) NOT NULL,
    fk_Produto_Cod_Prod int NOT NULL,
    CONSTRAINT fK_Teste_Cliente FOREIGN KEY (fk_Cliente_Cli_cpf) REFERENCES TBCliente (cli_cpf),
    CONSTRAINT fK_Teste_Produto FOREIGN KEY (fk_Produto_Cod_Prod) REFERENCES TBProduto (cod_Prod)
);


CREATE TABLE TBServico (
    cod_Serv INT PRIMARY KEY auto_increment,
    desc_Serv VARCHAR(150) NOT NULL,
    prod_Serv VARCHAR(50)NOT NULL,
    dateEntre DATETIME NOT NULL,
    dateSaida DATE NOT NULL,
    valor_servico float NOT NULL,
    fk_Funcionario_Func_Cod INT NOT NULL,
    CONSTRAINT fK_Servico_Func FOREIGN KEY (fk_Funcionario_Func_Cod) REFERENCES TBFuncionario (func_Cod)
);

CREATE TABLE TBVenda (
	ven_Cod INT PRIMARY KEY auto_increment,
    parcelas INT NOT NULL,
    forma_Pag VARCHAR(30) NOT NULL,
    valorTotal DECIMAL(7,2) NOT NULL,
    fk_Cliente_Cli_cpf varchar(14) NOT NULL,
    fk_Cupom_cupom_cod VARCHAR(20),
    CONSTRAINT fK_Cupom_venda FOREIGN KEY (fk_Cupom_cupom_cod) REFERENCES tbCupom (cupom_cod),
    CONSTRAINT fK_Venda_Cliente FOREIGN KEY (fk_Cliente_Cli_cpf) REFERENCES TBCliente (cli_cpf)
);

CREATE TABLE TBItemPedido (
    qtn INT NOT NULL,
    valorUni DECIMAL(7,2) NOT NULL,
    total DECIMAL(7,2) NOT NULL,
    fk_Produto_Cod_Prod INT NOT NULL,
    fk_Venda_Ven_Cod INT NOT NULL,
    PRIMARY KEY (fk_Produto_Cod_Prod, fk_Venda_Ven_Cod),
    CONSTRAINT fK_ItemPedido_Produto FOREIGN KEY (fk_Produto_Cod_Prod) REFERENCES TBProduto (cod_Prod),
    CONSTRAINT fK_ItemPedido_Venda FOREIGN KEY (fk_Venda_Ven_Cod) REFERENCES TBVenda (ven_Cod),
    CHECK(Qtn>0)
);
CREATE TABLE TBItemServico (
    fk_Servico_Cod_Serv INT NOT NULL,
    fk_Venda_Ven_Cod INT NOT NULL,
    PRIMARY KEY (fk_Servico_Cod_Serv, fk_Venda_Ven_Cod),
    CONSTRAINT fK_ItemServico_Servico FOREIGN KEY (fk_Servico_Cod_Serv)REFERENCES TBServico (cod_Serv),
	CONSTRAINT fK_ItemServico_Venda FOREIGN KEY (fk_Venda_Ven_Cod)REFERENCES TBVenda (ven_Cod)
);

CREATE TABLE TBDelivery (
    deli_Cod INT PRIMARY KEY NOT NULL auto_increment,
    deli_Data DATETIME NOT NULL,
    fk_Cliente_Cli_cpf varchar(14) NOT NULL,
    fk_Venda_Ven_Cod INT NOT NULL,
    CONSTRAINT FK_Delivery_Cliente FOREIGN KEY (fk_Cliente_Cli_cpf) REFERENCES TBCliente (cli_cpf),
    CONSTRAINT FK_Delivery_Venda FOREIGN KEY (fk_Venda_Ven_Cod) REFERENCES TBVenda (ven_Cod)
);

##cUPOM
insert into TBCupom  values('MENOS10', 10),
("MENOS1", 1),
("MENOS5", 5);


 ###################################################### VIEWS ######################################
 
 ##CLINTES
 CREATE VIEW vw_cliente AS
	SELECT  TBEstado.nome_uf, TBCidade.nome_Cidade, TBBairro.nome_bairro, TBCep.cep, TBCep.logradouro,
		    TBCliente.cli_cpf, TBCliente.cli_Nome, TBCliente.cli_NumEnd, TBCliente.cli_email, TBCliente.cli_tel,
			(select count(fk_Cliente_Cli_cpf ) from TBVenda where TBCliente.cli_cpf=TBVenda.fk_Cliente_cli_cpf ) AS 'NumCompras' 
            from TBCliente inner join TBCep on TBCep.cep = TBCliente.fk_Cep_cep  
            inner join TBEstado on TBEstado.id_uf = TBCep.fk_Estado_Id_uf
            inner join TBCidade  on TBCidade .iD_Cidade  = TBCep.fk_Cidade_ID_Cidade 
            inner join TBBairro  on TBBairro .id_bairro  = TBCep.fk_Bairro_Id_bairro; 
         
##FUNCIONARIO
 CREATE VIEW vw_Funcinario AS
	SELECT  TBEstado.nome_uf, TBCidade.nome_Cidade, TBBairro.nome_bairro, TBCep.cep, TBCep.logradouro, TBFuncionario.func_Num_End,
		    TBFuncionario.func_Cod , TBFuncionario.func_Nome , TBFuncionario.func_CPF , TBFuncionario.func_Tel , 
            TBFuncionario.func_Email , TBFuncionario.func_DataNasc, TBFuncionario.func_Cargo  
            from TBFuncionario  inner join TBCep on TBCep.cep = TBFuncionario.fk_Cep_cep  
            inner join TBEstado on TBEstado.id_uf = TBCep.fk_Estado_Id_uf
            inner join TBCidade  on TBCidade.iD_Cidade  = TBCep.fk_Cidade_ID_Cidade 
            inner join TBBairro  on TBBairro.id_bairro  = TBCep.fk_Bairro_Id_bairro;
            
##teste
CREATE VIEW vw_Testes AS
	SELECT TBTeste.agen_Cod , TBTeste.age_DtRetirada,  TBTeste.age_Desc, 
    TBProduto.prod_Nome, TBProduto.cod_Prod,  TBCliente.cli_cpf, TBCliente.cli_Nome  
    from TBTeste inner join TBProduto on TBProduto.cod_Prod = TBTeste.fk_Produto_Cod_Prod 
    inner join TBCliente on TBCliente.cli_cpf = TBTeste.fk_Cliente_Cli_cpf;
    
##servico
CREATE VIEW vw_Sevico AS
	SELECT TBServico.cod_Serv, TBServico.desc_Serv, TBServico.prod_Serv, TBServico.dateEntre, TBServico.dateSaida, TBServico.valor_servico,  
     TBFuncionario.func_Cod , TBFuncionario.func_Nome,  TBFuncionario.func_Cargo
     FROM TBServico inner join TBFuncionario on TBFuncionario.func_Cod = TBServico.fk_Funcionario_Func_Cod; 

##venda
CREATE VIEW vw_Venda AS
	SELECT TBVenda.ven_Cod , TBVenda.parcelas, TBVenda.forma_Pag, TBVenda.valorTotal, TBCliente.cli_cpf, TBCliente.cli_Nome 
    from TBVenda  inner join TBCliente on TBCliente.cli_cpf = TBVenda.fk_Cliente_Cli_cpf;
    
    
##todos os itens
delimiter $$
CREATE PROCEDURE SPMostraItens(vCodVenda INT)
begin
	SELECT TBItemPedido.fk_Venda_Ven_Cod, TBItemPedido.fk_Produto_Cod_Prod, TBProduto.prod_Nome, TBItemPedido.qtn, TBItemPedido.valorUni,  TBItemPedido.total  FROM TBItemPedido inner join TBProduto on TBProduto.cod_Prod = TBItemPedido.fk_Produto_Cod_Prod where fk_Venda_Ven_Cod= vCodVenda; 
    SELECT TBItemServico.fk_Venda_Ven_Cod, TBItemServico.fk_Servico_Cod_Serv, TBServico.desc_Serv, TBServico.valor_servico  FROM TBItemServico inner join TBServico on TBServico.cod_Serv = TBItemServico.fk_Servico_Cod_Serv where fk_Venda_Ven_Cod=1;
    
     select (select Sum(TBServico.valor_servico) from TBServico inner join TBItemServico on TBItemServico.fk_Venda_Ven_Cod = TBServico.cod_Serv where fk_Venda_Ven_Cod= vCodVenda) + 
			(select Sum(TBItemPedido.total) from TBItemPedido where fk_Venda_Ven_Cod= vCodVenda) As 'Total';
end
$$

################################################ Inserts ##########################################
##CADASTRO CLIENTE

delimiter $$
CREATE PROCEDURE SPInsertCliente(vNome_uf VARCHAR(2), vNome_Cidade VARCHAR(50), vNome_bairro VARCHAR(100), vCep VARCHAR(11), 
								vLogradouro VARCHAR(100), vCli_cpf varchar(14), vCli_Nome VARCHAR(100), vCli_NumEnd INT, 
                                vCli_email VARCHAR(100), vCli_tel long)
begin
	if  not exists(select nome_uf from TBEstado where nome_uf  = vNome_uf LIMIT 1) then 
		insert into tbEstado (nome_uf) Values(vNome_uf);
      End If;
      
      if  not exists (select nome_Cidade  from TBCidade where nome_Cidade   = vNome_Cidade LIMIT 1) then 
		insert into TBCidade (nome_Cidade) Values(vNome_Cidade);
      End If;
      
      if  not exists (select nome_bairro   from TBbairro where nome_bairro  = vNome_bairro LIMIT 1 ) then 
		insert into TBbairro (nome_bairro) Values(vNome_bairro);
      End If;
      
      if  not exists (select cep  from TBCep  where cep    = vCep ) then 
		insert into TBCep (cep ,logradouro, fk_Estado_Id_uf , fk_Cidade_ID_Cidade , fk_Bairro_Id_bairro  )
              values(vCep, vLogradouro,(select id_uf  from tbEstado where nome_uf = vNome_uf LIMIT 1),
									   (select iD_Cidade  from TBCidade where nome_Cidade  = vNome_Cidade LIMIT 1),
									   (select id_bairro  from TBbairro where Nome_bairro  = vNome_bairro LIMIT 1));
	End If;
                                       
	insert into TBCliente values(vCli_cpf, vCli_Nome, vCli_NumEnd, vCli_email, vCli_tel,vCep);
end;
$$

##CADASTRO FUNCIONARIO
delimiter $$
CREATE PROCEDURE SPInsertFunc(vNome_uf VARCHAR(2), vNome_Cidade VARCHAR(50), vNome_bairro VARCHAR(100), vCep VARCHAR(11), 
								vLogradouro VARCHAR(100), vFunc_Nome VARCHAR(100), vFunc_CPF varchar(14), vFunc_Tel long,
								vFunc_Email VARCHAR(100), vFunc_DataNasc DATE, vFunc_Num_End INT, vFunc_Cargo VARCHAR(30), vFunc_senha varchar(10))
begin
	if  not exists(select nome_uf from TBEstado where nome_uf  = vNome_uf ) then 
		insert into tbEstado (nome_uf) Values(vNome_uf);
      End If;
      
      if  not exists (select nome_Cidade  from TBCidade where nome_Cidade   = vNome_Cidade ) then 
		insert into TBCidade (nome_Cidade) Values(vNome_Cidade);
      End If;
      
      if  not exists (select nome_bairro   from TBbairro where nome_bairro    = vNome_bairro ) then 
		insert into TBbairro (nome_bairro) Values(vNome_bairro);
      End If;
      
      if  not exists (select cep  from TBCep  where cep    = vCep ) then 
		insert into TBCep (cep ,logradouro, fk_Estado_Id_uf , fk_Cidade_ID_Cidade , fk_Bairro_Id_bairro)
              values(vCep, vLogradouro,(select id_uf  from tbEstado where nome_uf = vNome_uf LIMIT 1),
									   (select iD_Cidade  from TBCidade where nome_Cidade  = Nome_Cidade LIMIT 1),
									   (select id_bairro  from TBbairro where nome_bairro  = vNome_bairro LIMIT 1));
      End If;
                                       
	insert into TBFuncionario (func_Nome, func_CPF, func_Tel, func_Email, func_DataNasc, func_Num_End, func_Cargo, func_senha, fk_Cep_cep) values(vFunc_Nome, vFunc_CPF, vFunc_Tel, vFunc_Email, vFunc_DataNasc, vFunc_Num_End, vFunc_Cargo, vFunc_senha ,vCep);
end;
$$


##Cadastro produto
delimiter $$
CREATE PROCEDURE SPInsertProduto(vProd_Nome VARCHAR(100), vProd_Tipo VARCHAR(50), vProd_Quant_Estoque INT, 
								vProd_Desc TEXT, vProd_AnoLanc VARCHAR(4), vProd_FaixaEta VARCHAR(10),
                                vProd_Valor float)
begin
INSERT INTO TBProduto (prod_Nome, prod_Tipo, prod_Quant_Estoque, prod_Desc, prod_AnoLanc, prod_FaixaEta, prod_Valor) 
			values(vProd_Nome, vProd_Tipo, vProd_Quant_Estoque, vProd_Desc, vProd_AnoLanc,vProd_FaixaEta,vProd_Valor);
end;
$$      
 
 ##TESTE
delimiter $$
CREATE PROCEDURE SPInsertTeste(vRetirada date, vAge_Desc VARCHAR(120), vCli_cpf varchar(14) ,vCod_Prod int)
begin
INSERT INTO TBTeste  (age_DtRetirada , age_Desc , fk_Cliente_Cli_cpf , fk_Produto_Cod_Prod) 
			values(vRetirada, vAge_Desc, vCli_cpf, vCod_Prod);
end;
$$  


 ##INSERT servico
 delimiter $$
CREATE PROCEDURE SPInsertServico( vDesc_Serv VARCHAR(150), vProd_Serv VARCHAR(50), 
								vDateSaida DATE, vValor float, vFunc_Cod INT)
begin
INSERT INTO TBServico (desc_Serv , prod_Serv , dateEntre , dateSaida , valor_servico,fk_Funcionario_Func_Cod ) 
			values(vDesc_Serv, vProd_Serv, (SELECT CURRENT_TIMESTAMP()), vDateSaida, vValor, vFunc_Cod);
end;
$$     


#inicia venda
 delimiter $$
CREATE PROCEDURE SPInsertiniciaVenda(vCli_cpf varchar(11))
begin
INSERT INTO TBVenda  (Parcelas, Forma_Pag, ValorTotal,fk_Cliente_Cli_cpf) 
			values(1, 'Dinheiro', 00.00, vCli_cpf);
end;
$$ 

##Adicona cupom a venda
 delimiter $$
CREATE PROCEDURE SPCupomVenda(vVen_Cod INT, vCupom_cod VARCHAR(20))
begin
update TBVenda set fk_Cupom_cupom_cod =vCupom_cod where ven_Cod=vVen_Cod;
end;
$$ 

#delivey
 delimiter $$
CREATE PROCEDURE SPInsertDelivey(vCli_cpf varchar(11),vVen_Cod INT)
begin
INSERT INTO TBDelivery(deli_Data , fk_Cliente_Cli_cpf , fk_Venda_Ven_Cod) 
			values((SELECT CURRENT_TIMESTAMP()),vCli_cpf , vVen_Cod);

update TBVenda set valorTotal =ValorTotal+5.00  where Ven_Cod =vVen_Cod;
end;
$$ 

###item venda
delimiter $$
CREATE PROCEDURE SPInsertItemVendaProd(vQtn INT, vCod_Prod INT, vVen_Cod INT)
begin
INSERT INTO TBItemPedido(qtn, valorUni, total, fk_Produto_Cod_Prod, fk_Venda_Ven_Cod) 
			values(vQtn, (select Prod_Valor from TBProduto where Cod_Prod = vCod_Prod limit 1), (select Prod_Valor * vQtn from TBProduto where Cod_Prod = vCod_Prod limit 1), vCod_Prod, vVen_Cod);
            
UPDATE TBProduto SET prod_Quant_Estoque= (prod_Quant_Estoque-vQtn) WHERE cod_Prod = vCod_Prod;
end;
$$ 


###item SERVIÇO
delimiter $$
CREATE PROCEDURE SPInsertItemVendaServ(vCod_Serv INT, vVen_Cod INT)
begin
INSERT INTO TBItemServico (fk_Servico_Cod_Serv,fk_Venda_Ven_Cod) 
			values(vCod_Serv, vVen_Cod);
end;
$$ 

##atualiza Total venda
delimiter $$
CREATE PROCEDURE SPUpdateTotalvenda(vVen_Cod INT)
begin
update TBVenda set ValorTotal = (select Sum(TBServico.valor_servico) from TBServico inner join TBItemServico on TBItemServico.fk_Venda_Ven_Cod =TBServico.cod_Serv) + 
			(select Sum(TBItemPedido.total) from TBItemPedido) where ven_Cod =vVen_Cod ;
 
end;
$$ 


##clinte
call SPInsertCliente('SP', 'São Paulo', 'Lapa', 05312298, 'Rua general Algusto', '20624341038', 'Luiz Gama Souza', 54, 'Luis.gama@gmail.com','11968324486');
call SPInsertCliente('SP', 'Osasco', 'Novo Osasco', 53170430, 'Rua Atenas', '36065138797', 'Lucca Matheus Fernandes', 769, 'LuCCa.MF@gmail.com','12981559857');

##funcionario
call SPInsertFunc('SP', 'São Paulo', 'Mooca', 42231612, 'Quadra QNP 16 Conjunto M', 'Antonio Carlos Lima', 39746133071, 61929850375, 'giovannibento72@gmail.com','1989-12-09', 127, 'Tecnico', 'guiguiba');

##produto
call SPInsertProduto('Jogo da Vida Estrela', 'tabuleiro', 10,
'No jogo da vida, o dia-a-dia novas casas e muita emoção! A busca pelo sucesso continua com grandes surpresas pelo caminho! De médico a artista, você deve estar preparado para momentos de sorte e azar.
 Invista na bolsa, encontre petróleo, atravesse o canal da mancha e tenha filhos', '1960', 'Livre', 99.99);
 call SPInsertProduto('FIFA 22', 'Jogo eletronico', 21,
'Desenvolvido pela Electronic Arts a recriação de goleiros e goleiras leva mais compostura e consistência à posição mais importante do campo, uma nova física da bola reimagina cada passe, finalização e 
gol e corridas explosivas fazem você sentir a aceleração dos jogadores e jogadoras de futebol com mais velocidade no jogo.', '2021', '+10', 159.99);
 
 ##teste
 call SPInsertTeste('Test Do Jogo Da vida',20624341038,1);
 
 #serviço
 call SPInsertServico('Video game não liga', 'PS4','2021-11-05',129.00, 1);
 
 ##Abre venda
 call SPInsertiniciaVenda(20624341038);
 
 ##delivery
 call SPInsertDelivey(20624341038,1);
 
 ##item Prod
call SPInsertItemVendaProd(2,1,1);
call SPInsertItemVendaProd(1,2,1);
 
 ##item servico
 call SPInsertItemVendaServ(1,1);
 
 ##aualiza total venda
 call SPUpdateTotalvenda(1);
 

select * from vw_cliente;
select *from vw_Funcinario;
select * from TBProduto;
select * from vw_Testes;
select * from vw_Sevico;
select * from vw_Venda;
call SPMostraItens(1);



####delete
delimiter $$
CREATE PROCEDURE SPDeleteCliente(vCpf VARCHAR(14))
begin
	delete from TBCliente WHERE cli_cpf=vCpf;
end;
$$


delimiter $$
CREATE PROCEDURE SPDeleteFunc(Vfunc_Cod  INT)
begin
	delete from TBFuncionario  WHERE func_Cod=Vfunc_Cod;
end;
$$

delimiter $$
CREATE PROCEDURE SPDeleteProd(vCod_Prod INT)
begin
	delete from TBProduto   WHERE Cod_Prod=vCod_Prod;
end;
$$

delimiter $$
CREATE PROCEDURE SPDeleteServ(Vcod_Serv  INT)
begin
	delete from TBServico    WHERE cod_Serv = Vcod_Serv ;
end;
$$

delimiter $$
create PROCEDURE SPDeleteCupom(vCod_cupom varchar(20))
begin
	delete from TBCupom where cupom_cod = vCod_cupom;
end;
$$


##remove cupom
delimiter $$
CREATE PROCEDURE SPRemoveCupom(vVen_Cod   INT)
begin
	update TBVenda set  fk_Cupom_cupom_cod =default where ven_Cod=vVen_Cod;
end;
$$
##remove item venda 
delimiter $$
CREATE PROCEDURE SPRemoveItemVenda(vVen_Cod INT, Vcod_Prod int)
begin
	delete from TBItemPedido  WHERE fk_Venda_Ven_Cod  = vVen_Cod AND fk_Produto_Cod_Prod =Vcod_Prod ;
end;
$$

##remove item serviço 
delimiter $$
CREATE PROCEDURE SPRemoveItemVenda(vVen_Cod INT, vCod_Serv  int)
begin
	delete from TBItemServico   WHERE fk_Venda_Ven_Cod  = vVen_Cod AND fk_Servico_Cod_Serv =vCod_Serv  ;
end;
$$



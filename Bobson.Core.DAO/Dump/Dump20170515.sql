CREATE DATABASE  IF NOT EXISTS `bobson01` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `bobson01`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bobson01
-- ------------------------------------------------------
-- Server version	5.5.55-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `aros_cliente`
--

DROP TABLE IF EXISTS `aros_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aros_cliente` (
  `codigo_cliente` int(11) NOT NULL,
  `nome_cliente` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codigo_cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aros_equipamento`
--

DROP TABLE IF EXISTS `aros_equipamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aros_equipamento` (
  `codigo_equipamento` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_cliente` int(11) NOT NULL,
  `codigo_banheiro` int(11) NOT NULL,
  `uf` varchar(2) NOT NULL,
  `local` varchar(50) DEFAULT NULL,
  `tipo` varchar(10) DEFAULT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `hora_liga` time DEFAULT NULL,
  `hora_desliga` time DEFAULT NULL,
  `aroma` varchar(20) DEFAULT NULL,
  `ultima_troca` datetime DEFAULT NULL,
  `peso_refil` int(11) DEFAULT NULL,
  `nevoa_solta` time DEFAULT NULL,
  `nevoa_para` time DEFAULT NULL,
  PRIMARY KEY (`uf`,`codigo_cliente`,`codigo_banheiro`),
  UNIQUE KEY `codigo_equipamento_UNIQUE` (`codigo_equipamento`)
) ENGINE=InnoDB AUTO_INCREMENT=2671 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aros_filiais`
--

DROP TABLE IF EXISTS `aros_filiais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aros_filiais` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `email` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aros_registro`
--

DROP TABLE IF EXISTS `aros_registro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aros_registro` (
  `codigo_registro` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_cliente` int(11) DEFAULT NULL,
  `codigo_equipamento` int(11) DEFAULT NULL,
  `acontecimento` varchar(1) DEFAULT NULL COMMENT 'Troca Motor\nTroca Maquina\nRefil Cheio',
  `peso_refil` varchar(45) DEFAULT NULL,
  `observacoes` varchar(45) DEFAULT NULL,
  `data_ocorrencia` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `uf` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`codigo_registro`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aros_remessa`
--

DROP TABLE IF EXISTS `aros_remessa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aros_remessa` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero_controle` varchar(45) DEFAULT NULL,
  `origem` int(11) DEFAULT NULL,
  `destino` int(11) DEFAULT NULL,
  `forma_envio` int(11) DEFAULT NULL,
  `descricao_objeto` varchar(100) DEFAULT NULL,
  `data_envio` datetime DEFAULT NULL,
  `responsavel_envio` varchar(45) DEFAULT NULL,
  `data_recebimento` datetime DEFAULT NULL,
  `responsavel_recebimento` varchar(45) DEFAULT NULL,
  `observacoes` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aros_transportes`
--

DROP TABLE IF EXISTS `aros_transportes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aros_transportes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `url_rastreio` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`),
  CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`),
  CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`),
  CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  `IdUsuario` int(11) DEFAULT '0',
  `Nome` varchar(50) DEFAULT NULL,
  `TipoPessoa` varchar(1) DEFAULT NULL,
  `CpfCnpj` varchar(14) DEFAULT NULL,
  `Rg` varchar(20) DEFAULT NULL,
  `DataNascimento` date DEFAULT NULL,
  `EstadoCivil` varchar(20) DEFAULT NULL,
  `Nascionalidade` varchar(20) DEFAULT NULL,
  `Profissao` varchar(20) DEFAULT NULL,
  `Sexo` varchar(1) DEFAULT NULL,
  `Cep` varchar(8) DEFAULT NULL,
  `Logradouro` varchar(100) DEFAULT NULL,
  `Numero` varchar(10) DEFAULT NULL,
  `Complemento` varchar(20) DEFAULT NULL,
  `Bairro` varchar(50) DEFAULT NULL,
  `Cidade` varchar(50) DEFAULT NULL,
  `Uf` varchar(2) DEFAULT NULL,
  `TelefoneResidencial` varchar(20) DEFAULT NULL,
  `TelefoneCelular` varchar(20) DEFAULT NULL,
  `TelefoneComercial` varchar(20) DEFAULT NULL,
  `Status` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UK_UserName` (`UserName`),
  UNIQUE KEY `UK_Email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `debug`
--

DROP TABLE IF EXISTS `debug`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `debug` (
  `info` varchar(500) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=350 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `modelo_categoria`
--

DROP TABLE IF EXISTS `modelo_categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modelo_categoria` (
  `id` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `modelo_documento`
--

DROP TABLE IF EXISTS `modelo_documento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modelo_documento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `html` mediumtext NOT NULL,
  `nome` varchar(100) NOT NULL,
  `id_categoria` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_categ_idx` (`id_categoria`),
  KEY `fk_categs_idx` (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `proposta_historico`
--

DROP TABLE IF EXISTS `proposta_historico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proposta_historico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT NULL,
  `usuario` varchar(128) DEFAULT NULL,
  `email_assunto` varchar(100) DEFAULT NULL,
  `email_corpo` varchar(2000) DEFAULT NULL,
  `email_cliente` varchar(256) DEFAULT NULL,
  `email_copia` varchar(256) DEFAULT NULL,
  `view_name` varchar(25) DEFAULT NULL,
  `view_model` varchar(1000) DEFAULT NULL,
  `id_modelo` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'bobson01'
--

--
-- Dumping routines for database 'bobson01'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_banheiros` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_banheiros`(IN in_uf varchar(2), IN in_codigo_cliente INT)
BEGIN

select 
    aros_equipamento.codigo_cliente,
    aros_equipamento.codigo_equipamento,
    aros_equipamento.descricao as descricao_equipamento,    
    aros_equipamento.local,
    aros_equipamento.tipo,
    aros_equipamento.hora_liga,
    aros_equipamento.hora_desliga,
    aros_equipamento.aroma,
    aros_equipamento.nevoa_solta,
    aros_equipamento.nevoa_para
from 
   aros_equipamento
where 
   aros_equipamento.uf = in_uf and aros_equipamento.codigo_cliente = in_codigo_cliente 
order by
   aros_equipamento.tipo;
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_cadastro` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_cadastro`(
  IN in_uf varchar(2),
  IN in_codigo_cliente int(11),
  IN in_codigo_banheiro int(11),
  IN in_local varchar(50),
  IN in_tipo varchar(10),
  IN in_descricao varchar(45),
  IN in_hora_liga time,
  IN in_hora_desliga time,
  IN in_aroma varchar(20),
  IN in_ultima_troca datetime,
  IN in_peso_refil varchar(45),
  IN in_nevoa_solta time,
  IN in_nevoa_para time)
BEGIN
   insert into aros_equipamento 
   (uf, 
   codigo_cliente, 
   codigo_banheiro,    
   local, 
   tipo,
   descricao, 
   hora_liga, 
   hora_desliga, 
   aroma, 
   ultima_troca, 
   peso_refil, 
   nevoa_solta, 
   nevoa_para) 
   values 
   (in_uf, 
   in_codigo_cliente, 
   in_codigo_banheiro,    
   in_local, 
   in_tipo,
   in_descricao, 
   in_hora_liga, 
   in_hora_desliga, 
   in_aroma, 
   in_ultima_troca, 
   in_peso_refil, 
   in_nevoa_solta, 
   in_nevoa_para)
   on duplicate key update 
	   local      	= in_local, 
	   tipo       	= in_tipo,
	   descricao  	= in_descricao, 
	   hora_liga  	= in_hora_liga, 
	   hora_desliga = in_hora_desliga,
	   aroma		= in_aroma,  
	   ultima_troca	= in_ultima_troca,
	   peso_refil	= in_peso_refil, 
	   nevoa_solta	= in_nevoa_solta,
	   nevoa_para	= in_nevoa_para; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_delete_remessa` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_delete_remessa`(in in_id int)
BEGIN
     update aros_remessa set id = id * -1 where id = in_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_editar_remessa` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_aros_editar_remessa`(in in_id int, in in_numero_controle varchar(45))
BEGIN
    update aros_remessa set numero_controle = in_numero_controle where id = in_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_filiais` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_filiais`()
BEGIN
	select * from aros_filiais;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_listar_remessas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_listar_remessas`(
IN in_local int,
in in_data_inicio date,
in in_data_fim date

)
BEGIN
   select 
    id,
    numero_controle,
	origem,
    (select nome from aros_filiais where id = origem) as desc_origem,
	destino,
    (select nome from aros_filiais where id = destino) as desc_destino,
	forma_envio,
    (select nome from aros_transportes where id = forma_envio) as desc_forma_envio,
	descricao_objeto,
	data_envio,
	responsavel_envio,
	data_recebimento,
	responsavel_recebimento,
    observacoes
   from aros_remessa 
   where id > 0 and (  (aros_remessa.origem = in_local or aros_remessa.destino = in_local ) and (date(aros_remessa.data_envio) between in_data_inicio and in_data_fim or date(aros_remessa.data_recebimento) between in_data_inicio and in_data_fim) );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_maquinas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_maquinas`(
IN in_uf varchar(2),
IN in_codigo_cliente int,
IN in_local varchar(50), in in_tipo varchar(10) )
BEGIN
select 
    aros_equipamento.codigo_cliente,
    aros_equipamento.codigo_equipamento,
    aros_equipamento.descricao as descricao_equipamento,    
    aros_equipamento.local,
    aros_equipamento.tipo,
    aros_equipamento.hora_liga,
    aros_equipamento.hora_desliga,
    aros_equipamento.aroma,
    aros_equipamento.nevoa_solta,
    aros_equipamento.nevoa_para
from 
   aros_equipamento
where 
   aros_equipamento.codigo_cliente = in_codigo_cliente and aros_equipamento.uf = in_uf and local = in_local and tipo = in_tipo
order by
   aros_equipamento.tipo;   
   
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_nova_remessa` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_nova_remessa`(
IN in_numero_controle varchar(45),
in in_origem int,
in in_destino int,
in in_forma_envio int,
in in_descricao_objeto varchar(100),
in in_responsavel_envio varchar(45),
in in_observacoes varchar(500),
out out_id int)
BEGIN
	insert into aros_remessa (
	numero_controle,
	origem,
	destino,
	forma_envio,
	descricao_objeto,
	data_envio,
	responsavel_envio,
    observacoes
) 
	values (
	in_numero_controle,
	in_origem,
	in_destino,
	in_forma_envio,
	in_descricao_objeto,
	now(),
	in_responsavel_envio,
    in_observacoes); 
    
    set out_id = LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_receber_remessa` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_receber_remessa`(in in_id int, in in_responsavel varchar(45))
BEGIN
    update aros_remessa set responsavel_recebimento = in_responsavel, data_recebimento = NOW() where id = in_id;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_registro` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_registro`(
IN in_uf varchar(2),
IN in_codigo_cliente INT,
IN in_codigo_equipamento INT,
IN in_acontecimento varchar(1),
IN in_peso_refil varchar(45),
IN in_observacoes varchar(45)
)
BEGIN

insert into aros_registro (uf, codigo_cliente, codigo_equipamento, acontecimento, peso_refil, observacoes)
values (in_uf, in_codigo_cliente, in_codigo_equipamento, in_acontecimento, in_peso_refil, in_observacoes);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_report` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_report`(IN in_codigo_equipamento int(11))
BEGIN

select 
	aros_registro.codigo_cliente, 
	aros_equipamento.descricao as descricao_equipamento, 
    CASE aros_registro.acontecimento 
		WHEN 'R' THEN 'TROCA MOTOR'
        WHEN 'M' THEN 'TROCA MAQUINA'
        WHEN 'F' THEN 'REFIL CHEIO'
        ELSE 'ERRO'
    END as acontecimento, 
    aros_registro.peso_refil, 
    aros_registro.observacoes,
    aros_equipamento.local,
    aros_equipamento.tipo,
    aros_equipamento.descricao,
    aros_registro.data_ocorrencia
from 
   aros_registro
join 
   aros_equipamento on aros_equipamento.codigo_equipamento = aros_registro.codigo_equipamento
where 
   aros_equipamento.codigo_equipamento = in_codigo_equipamento
order by
   aros_registro.observacoes,
   aros_registro.data_ocorrencia;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_transportes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_transportes`()
BEGIN
   select * from aros_transportes;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_aros_uf` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`bobson01`@`%` PROCEDURE `sp_aros_uf`()
BEGIN
   select distinct uf from aros_equipamento;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-15  3:34:52
